using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTopDestructionTrigger : MonoBehaviour
{
    private PlatformDestruction platformDestruction;

    private void Awake() {
        platformDestruction = GetComponentInParent<PlatformDestruction>();
    }

    private void OnTriggerExit(Collider other) {

        if (Ball.Instance.GetState() == SuperState.Instance) {
            
            SuperState.Instance.IncrementPlatformsHitWithSuper();

            platformDestruction.DestroyPlatform();

            gameObject.SetActive(false);
        }

    }
}
