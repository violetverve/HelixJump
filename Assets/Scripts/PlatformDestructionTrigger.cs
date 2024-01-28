using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestructionTrigger : MonoBehaviour {
private PlatformDestruction platformDestruction;

    private void Awake() {
        platformDestruction = GetComponentInParent<PlatformDestruction>();
    }

    private void OnTriggerExit(Collider other) {
        
        platformDestruction.DestroyPlatform();

        gameObject.SetActive(false);
    }
}
