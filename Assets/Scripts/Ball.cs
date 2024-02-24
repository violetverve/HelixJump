using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour {

    public static Ball Instance { get; private set; }

    public event EventHandler<BallHitPlatformEventArgs> OnBallHitPlatform;
    public event EventHandler OnBallStateChanged;

    public class BallHitPlatformEventArgs : EventArgs {
        public Vector3 position;
        public Transform transform;
    }
    [SerializeField] private float bounceForce = 4f;
    [SerializeField] private float gravityMultiplier = 6f;

    private IBallState ballState;
    private Rigidbody rb;

    private Vector3 bounceDirection = Vector3.up;
    
    private float collisionCooldown = 0.2f;
    private float lastCollisionTime = -1;
    
    private void Awake() {
        Instance = this;

        rb = GetComponent<Rigidbody>();

        ballState = NormalState.Instance;
    }

    private void Start() {
        LevelManager.Instance.OnLevelChanged += LevelManager_OnLevelChanged;
        LevelManager.Instance.OnLevelReset += LevelManager_OnLevelReset;
    }

    private void OnDestroy() {
        LevelManager.Instance.OnLevelChanged -= LevelManager_OnLevelChanged;
        LevelManager.Instance.OnLevelReset -= LevelManager_OnLevelReset;
    }

    private void LevelManager_OnLevelChanged(object sender, System.EventArgs e) {
        ResetBall();
    }

    private void LevelManager_OnLevelReset(object sender, System.EventArgs e) {
        ResetBall();
    }

    private void ResetBall() {

        ResetStates();
    }

    void FixedUpdate() {
        rb.AddForce(Physics.gravity * rb.mass * (gravityMultiplier - 1));
    }


    private void OnCollisionEnter(Collision collision) {

        float timeSinceLastCollision = Time.time - lastCollisionTime;
        if (timeSinceLastCollision < collisionCooldown) return;


        ballState.HandleCollisionEnter(this, collision);

        if (ballState is SuperState) {
            return;
        }

        OnBallHitPlatform?.Invoke(this, new BallHitPlatformEventArgs {
            position = transform.position,
            transform = collision.transform
        });

        lastCollisionTime = Time.time;
    }

    public void SetVelocity(Vector3 velocity) {
        rb.velocity = velocity;
    }

    public void AddBounceForce() {
        rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
    }

    public void SetState(IBallState ballState) {
        this.ballState = ballState;

        OnBallStateChanged?.Invoke(this, EventArgs.Empty);
    }

    public IBallState GetState() {
        return ballState;
    }

    private void ResetStates() {
        NormalState.Instance.ResetNormalState();
        SuperState.Instance.ResetSuperState();
    }
}