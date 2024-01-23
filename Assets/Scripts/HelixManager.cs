using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour {

    [SerializeField] private List<Transform> helixMiddleLevels;
    [SerializeField] private Transform helixTopLevel;
    [SerializeField] private Transform helixBottomLevel;
    private readonly int numberOfMiddleLevels = 10;
    private readonly float levelDistance = 4f;
    private float yPos;

    private void Start() {
        yPos = transform.position.y;

        SpawnLevels();
    }

    private void SpawnLevels() {
        SpawnLevel(helixTopLevel);

        for (int i = 0; i < numberOfMiddleLevels; i++) {
            int randomIndex = Random.Range(0, helixMiddleLevels.Count);
            SpawnLevel(helixMiddleLevels[randomIndex]);
        }

        SpawnLevel(helixBottomLevel);
    }

    private void SpawnLevel(Transform platform) {
        Vector3 spawnPosition = new Vector3(transform.position.x, yPos, transform.position.z);
        Instantiate(platform, spawnPosition, Quaternion.identity, transform);

        yPos -= levelDistance;
    }

}
