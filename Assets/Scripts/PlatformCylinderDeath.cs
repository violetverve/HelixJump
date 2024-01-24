using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCylinderDeath : MonoBehaviour {
    
    private void OnCollisionExit(Collision other) {
        HelixGameManager.Instance.GameOver();
    }

}

