using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTopDestructionTrigger : MonoBehaviour
{
    private PlatformDestruction platformDestruction;
    private float destructionForce = 1000f;

    private void Awake() {
        platformDestruction = GetComponentInParent<PlatformDestruction>();
    }

    private void OnTriggerExit(Collider other) {

        if (Ball.Instance.GetState() is SuperState && SuperState.Instance.IsDestroying()) {

            SuperState.Instance.IncrementPlatformsHitWithSuper();

            platformDestruction.SetPlatformMaterial(BallVisual.Instance.GetBallCurrentMaterial());

            platformDestruction.DestroyPlatform(destructionForce);

            gameObject.SetActive(false);
        }

    }
}
