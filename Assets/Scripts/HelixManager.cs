using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour {

    public static HelixManager Instance { get; private set; }
    [SerializeField] private List<Transform> helixMiddleLevels;
    [SerializeField] private Transform helixTopLevel;
    [SerializeField] private Transform helixBottomLevel;
    private int numberOfMiddleLevels;
    private readonly float levelDistance = 4f;
    private float yPos;

    private void OnAwake() {
        Instance = this;
        HelixGameManager.Instance.OnGameOver += HelixGameManager_OnGameOver;
    }

    private void HelixGameManager_OnGameOver(object sender, System.EventArgs e) {
        DestroyLevels();
        SpawnLevels();
    }

    private void Start() {
        yPos = transform.position.y;

        numberOfMiddleLevels = LevelManager.Instance.GetPlatformsNumber();

        LevelManager.Instance.OnLevelChanged += LevelManager_OnLevelChanged;
        LevelManager.Instance.OnLevelReset += LevelManager_OnLevelReset;

        SpawnLevels();
    }

    private void LevelManager_OnLevelChanged(object sender, System.EventArgs e) {
        numberOfMiddleLevels = LevelManager.Instance.GetPlatformsNumber();

        DestroyLevels();
        SpawnLevels();
    }

    private void LevelManager_OnLevelReset(object sender, System.EventArgs e) {
        DestroyLevels();
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

    private void DestroyLevels() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }

}
