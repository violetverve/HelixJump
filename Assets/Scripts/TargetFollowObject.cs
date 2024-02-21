using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollowObject : MonoBehaviour {

    Vector3 startPosition;
    Vector3 targetPosition;


     private void Awake() {

        startPosition = transform.position;
        targetPosition = startPosition;
    }

    private void Start() {
        PlatformsManager.Instance.OnPlatformIndexChanged += PlatformsManager_OnPlatformIndexChanged;
    }

    private void OnDestroy() {
        PlatformsManager.Instance.OnPlatformIndexChanged -= PlatformsManager_OnPlatformIndexChanged;
    }

    private void PlatformsManager_OnPlatformIndexChanged(object sender, System.EventArgs e) {
        Vector3 platformPosition = PlatformsManager.Instance.GetCurrentPlatformPosition();
        targetPosition = startPosition + platformPosition;
    }


    private void LateUpdate() {
        transform.position = targetPosition;
    }
}