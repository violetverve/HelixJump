using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour {

    public static Ball Instance { get; private set; }
    public event EventHandler<BallHitPlatformEventArgs> OnBallHitPlatform;

    public class BallHitPlatformEventArgs : EventArgs {
        public Vector3 position;
        public Transform transform;
    }

    private readonly float bounceForce = 3f;
    private Rigidbody rb;
    private bool hasBounced = false;

    private void Awake() {
        Instance = this;

        rb = GetComponent<Rigidbody>();
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