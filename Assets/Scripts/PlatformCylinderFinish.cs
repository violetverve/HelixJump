using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCylinderFinish : MonoBehaviour {

    private void OnCollisionEnter(Collision other) {
        HelixGameManager.Instance.LevelComplete();
    }
}
