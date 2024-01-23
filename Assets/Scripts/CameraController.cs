using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private Transform targetTransform;
    private Vector3 offset;
    private float smoothSpeed = 0.125f;

    private void Awake() {
        offset = transform.position - targetTransform.position;
    }

    private void Update() {
        Vector3 newPosition = new Vector3.Lerp(transform.position, targetTransform.position + offset, smoothSpeed);
        transform.position = newPosition;
    }
}