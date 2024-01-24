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
        
        platformDestruction.DestroyPlatform();
    }
}