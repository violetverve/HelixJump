using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCylinderTrigger : MonoBehaviour {

    private PlatformDestruction platformDestruction;

    private void Awake() {
        platformDestruction = GetComponentInParent<PlatformDestruction>();
    }

    private void OnTriggerExit(Collider other) {
        ScoreManager.Instance.IncrementScore();

        if (Ball.Instance.GetState() is NormalState) {
            NormalState.Instance.IncrementPlatformsPassedWithoutCollision();
        }

        PlatformsManager.Instance.IncrementPlatformIndex();
        
        platformDestruction.DestroyPlatform();

        gameObject.SetActive(false);
    }
}