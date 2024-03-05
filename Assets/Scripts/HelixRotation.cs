using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixRotation : MonoBehaviour {
    private float rotationSpeed = 60f;
    private float inertiaDuration = 0.3f;
    private bool isRotating = false;
    private Vector3 lastMousePosition;
    private float dpiScale;
    private float rotationVelocity;
    private float lastRotationAmount;
    private float inertiaCounter;
    private const float standardDPI = 96f;

    private void Start()
    {
        if (Screen.dpi < 1) dpiScale = 1;
        else dpiScale = Mathf.Log(Screen.dpi / standardDPI + 1);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
            inertiaCounter = 0;
        }

        if (Input.GetMouseButtonUp(0)) {
            isRotating = false;
            inertiaCounter = inertiaDuration;
        }

        if (isRotating) {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            float rotationAmount = -mouseDelta.x * rotationSpeed * dpiScale * Time.deltaTime;
            lastRotationAmount = rotationAmount;
            transform.Rotate(Vector3.up, rotationAmount);
            lastMousePosition = Input.mousePosition;
        }
        else if (inertiaCounter > 0) {
            transform.Rotate(Vector3.up, lastRotationAmount);
            lastRotationAmount *= inertiaCounter / inertiaDuration;
            inertiaCounter -= Time.deltaTime;
        }
    }
}
