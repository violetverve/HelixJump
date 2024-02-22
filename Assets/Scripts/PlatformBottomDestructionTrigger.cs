using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBottomDestructionTrigger : MonoBehaviour {
private PlatformDestruction platformDestruction;

    private void Awake() {
        platformDestruction = GetComponentInParent<PlatformDestruction>();
    }

    private void OnTriggerExit(Collider other) {
        
        PlatformsManager.Instance.IncrementPlatformIndex();

        platformDestruction.DestroyPlatform();

        gameObject.SetActive(false);
    }
}
