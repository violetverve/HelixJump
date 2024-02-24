using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPickUpManager : MonoBehaviour {

    [SerializeField] private Transform superPickUpTransform;

    private int minPossibleIndex = 3;
    private int maxPossibleIndex;
    private int maxPossibleIndexOffset = 5;
    private float yOffset = 1.1f;
    private float xPosition = 2.2f;
    private float zPosition = 0f;
    private int numberOfSuperPickUps = 2;
    private float levelDistance;


    private void Start() {
        int numberofPlatforms = LevelManager.Instance.GetPlatformsNumber();

        levelDistance = HelixManager.Instance.GetLevelDistance();

        maxPossibleIndex = numberofPlatforms - maxPossibleIndexOffset;

        SpawnSuperPickUps();
    }

    private void SpawnSuperPickUps() {

        for (int i = 0; i < numberOfSuperPickUps; i++) {
            SpawnSuperPickUp();
        }
    }

    private void SpawnSuperPickUp() {
        if (!CanSpawnSuperPickUp()) {
            return;
        }

        int platformIndex = Random.Range(minPossibleIndex, maxPossibleIndex);
        
        float yPosition = -levelDistance * platformIndex;
        Vector3 superPickUpPosition = new Vector3(xPosition, yPosition + yOffset, zPosition);

        Transform superPickUpTransfrm = Instantiate(superPickUpTransform, superPickUpPosition, Quaternion.identity);
        superPickUpTransfrm.SetParent(HelixManager.Instance.transform);

    }

    private bool CanSpawnSuperPickUp() {
        return maxPossibleIndex > minPossibleIndex;
    }


}