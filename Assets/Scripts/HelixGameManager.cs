using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class HelixGameManager : MonoBehaviour {

    public static HelixGameManager Instance { get; private set; }

    public event EventHandler OnGameOver;
    public event EventHandler OnLevelComplete;

    private void Awake() {
        Instance = this;
    }

    public void GameOver() {
        Time.timeScale = 0f;

        OnGameOver?.Invoke(this, EventArgs.Empty);
    }

    public void LevelComplete() {
        Time.timeScale = 0f;

        OnLevelComplete?.Invoke(this, EventArgs.Empty);
    }

}