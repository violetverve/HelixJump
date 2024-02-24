using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private const string CURRENT_LEVEL = "CurrentLevel";
    private const string PLATFORMS_NUMBER = "PlatformsNumber";
    private const int SCENE_INDEX = 0;
    public static LevelManager Instance { get; private set; }

    public event System.EventHandler OnLevelChanged;
    public event System.EventHandler OnLevelReset;

    private int currentLevel;
    private int numberOfPlatforms;
    private int platformsIncrement = 2;

    private void Awake() {
        Instance = this;

        currentLevel = PlayerPrefs.GetInt(CURRENT_LEVEL, 1);

        numberOfPlatforms = PlayerPrefs.GetInt(PLATFORMS_NUMBER, 20);
    }

    public int GetCurrentLevel() {
        return currentLevel;
    }

    public int GetPlatformsNumber() {
        return numberOfPlatforms;
    }

    public void LoadNextLevel() {
        Time.timeScale = 1f;
        
        currentLevel++;
        numberOfPlatforms += platformsIncrement;

        OnLevelChanged?.Invoke(this, System.EventArgs.Empty);

        PlayerPrefs.SetInt(CURRENT_LEVEL, currentLevel);
        PlayerPrefs.SetInt(PLATFORMS_NUMBER, numberOfPlatforms);

        PlayerPrefs.Save();

        SceneManager.LoadScene(SCENE_INDEX);
    }

    public void ResetCurrentLevel() {
        Time.timeScale = 1f;
        OnLevelReset?.Invoke(this, System.EventArgs.Empty);
        SceneManager.LoadScene(SCENE_INDEX);
    }
}
