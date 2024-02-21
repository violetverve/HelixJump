using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour {

    public static Ball Instance { get; private set; }

    public enum State {
        Normal,
        Super
    }

    public event EventHandler<BallHitPlatformEventArgs> OnBallHitPlatform;
    public event EventHandler OnBallStateChanged;
    private Vector3 startPosition;

    public class BallHitPlatformEventArgs : EventArgs {
        public Vector3 position;
        public Transform transform;
    }
    [SerializeField] private float bounceForce = 4f;
    [SerializeField] private float gravityMultiplier = 6f;

    private Rigidbody rb;
    private bool hasBounced = false;
    private int platformsPassedWithoutCollision = 0;
    private State state = State.Normal;
    private int platformsPassedWithoutCollisionToSuper = 2;
    private Vector3 bounceDirection = Vector3.up;

    private void Awake() {
        Instance = this;

        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
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
        transform.position = startPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void FixedUpdate() {
        if (rb.velocity.y > 0) {
            rb.AddForce(Physics.gravity * rb.mass * (gravityMultiplier - 1));
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (hasBounced) return;

        if (state == State.Super) {
            collision.gameObject.GetComponentInParent<PlatformDestruction>().DestroyPlatform();

            platformsPassedWithoutCollision = 0;
            state = State.Normal;
            OnBallStateChanged?.Invoke(this, EventArgs.Empty);
        }

        rb.velocity = Vector3.zero;
        rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);

        hasBounced = true;

        platformsPassedWithoutCollision = 0;

        OnBallHitPlatform?.Invoke(this, new BallHitPlatformEventArgs {
            position = transform.position,
            transform = collision.transform
        });
    }

    private void OnCollisionExit(Collision collision) {
        hasBounced = false;
    }

    public void IncrementPlatformsPassedWithoutCollision() {
        if (platformsPassedWithoutCollision == platformsPassedWithoutCollisionToSuper) {
            platformsPassedWithoutCollision++;

            state = State.Super;
            OnBallStateChanged?.Invoke(this, EventArgs.Empty);
        } 
        if (platformsPassedWithoutCollision < platformsPassedWithoutCollisionToSuper) {
            platformsPassedWithoutCollision++;
        }
    }

    public State GetState() {
        return state;
    }

}