using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixRotation : MonoBehaviour {

    public float rotationSpeed = 60f;
    private bool isRotating = false;
    private Vector3 lastMousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)) {
            isRotating = false;
        }

        if (isRotating) {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            float rotationAmount = mouseDelta.x * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, rotationAmount);

            lastMousePosition = Input.mousePosition;
        }
    }
}
