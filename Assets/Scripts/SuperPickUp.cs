using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPickUp : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {

        Ball ball = other.GetComponent<Ball>();

        if (ball != null) {
            ball.SetState(SuperState.Instance);
            Destroy(gameObject);
        }
    }

}