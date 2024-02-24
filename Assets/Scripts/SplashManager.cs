using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashManager : MonoBehaviour {

    [SerializeField] private Transform splashTransform;
    private readonly float maxSize = 1.1f;
    private readonly float minSize = 0.9f;


    private void Start() {
        Ball.Instance.OnBallHitPlatform += Ball_OnBallHitPlatform;
    }

#pragma warning disable IDE0060 // Remove unused parameter
    private void Ball_OnBallHitPlatform(object sender, Ball.BallHitPlatformEventArgs e) {

        SpawnSplash(e.position, e.transform);

    }
#pragma warning restore IDE0060 // Remove unused parameter

    private void SpawnSplash(Vector3 position, Transform parent) {
        float splashSize = Random.Range(minSize, maxSize);
        float randomRotation = Random.Range(0f, 360f);

        Transform splashTransfrm = Instantiate(splashTransform, position, Quaternion.Euler(0f, randomRotation, 0f));
        splashTransfrm.localScale = new Vector3(splashSize, splashSize, splashSize);

        splashTransfrm.SetParent(parent);
    }

}
