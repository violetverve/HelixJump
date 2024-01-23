using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private float bounceForce = 3f;
    private Rigidbody rb;
    private bool hasBounced = false;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (hasBounced) return;

        Vector3 bounceDirection = Vector3.up;

        rb.velocity = Vector3.zero;
        rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);

        hasBounced = true;
    }

    private void OnCollisionExit(Collision collision) {
        hasBounced = false;
    }
}