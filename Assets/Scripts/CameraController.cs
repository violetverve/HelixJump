using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private Transform targetTransform;
    private Vector3 offset;
    private readonly float smoothSpeed = 0.04f;

    private void Awake() {
        offset = transform.position - targetTransform.position;
    }

    private void LateUpdate() {
        Vector3 newPosition = Vector3.Lerp(transform.position, targetTransform.position + offset, smoothSpeed);
        transform.position = newPosition;    
    }
}