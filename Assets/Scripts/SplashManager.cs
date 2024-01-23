using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashManager : MonoBehaviour {

    [SerializeField] private Transform splashTransform;
    private readonly float maxSize = 1.1f;
    private readonly float minSize = 0.7f;


    private void Start() {
        Ball.Instance.OnBallHitPlatform += Ball_OnBallHitPlatform;
    }

    private void Ball_OnBallHitPlatform(object sender, Ball.BallHitPlatformEventArgs e) {

        float splashSize = Random.Range(minSize, maxSize);
        float randomRotation = Random.Range(0f, 360f);

        Transform splashTransfrm = Instantiate(splashTransform, e.position, Quaternion.Euler(0f, randomRotation, 0f));
        splashTransfrm.localScale = new Vector3(splashSize, splashSize, 1f);

        splashTransfrm.SetParent(e.transform);
    }

}
