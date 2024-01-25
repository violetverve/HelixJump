using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour {

    public static Ball Instance { get; private set; }
    public event EventHandler<BallHitPlatformEventArgs> OnBallHitPlatform;

    private Vector3 startPosition;

    public class BallHitPlatformEventArgs : EventArgs {
        public Vector3 position;
        public Transform transform;
    }

    private readonly float bounceForce = 4f;
    private Rigidbody rb;
    private bool hasBounced = false;

    private void Awake() {
        Instance = this;

        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    private void Start() {
        LevelManager.Instance.OnLevelChanged += LevelManager_OnLevelChanged;
        LevelManager.Instance.OnLevelReset += LevelManager_OnLevelReset;
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

    private void OnCollisionEnter(Collision collision) {
        if (hasBounced) return;

        Vector3 bounceDirection = Vector3.up;

        rb.velocity = Vector3.zero;
        rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);

        hasBounced = true;

        OnBallHitPlatform?.Invoke(this, new BallHitPlatformEventArgs {
            position = transform.position,
            transform = collision.transform
        });
    }

    private void OnCollisionExit(Collision collision) {
        hasBounced = false;
    }
}