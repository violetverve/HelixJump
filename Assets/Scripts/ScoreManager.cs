using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager Instance { get; private set; }

    public event EventHandler OnScoreChanged;

    private int currentScore = 0;
    private int maxScore;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        maxScore = LevelManager.Instance.GetPlatformsNumber();

        LevelManager.Instance.OnLevelChanged += LevelManager_OnLevelChanged;
    }

    private void OnDestroy() {
        LevelManager.Instance.OnLevelChanged -= LevelManager_OnLevelChanged;
    }

    private void LevelManager_OnLevelChanged(object sender, EventArgs e) {
        maxScore = LevelManager.Instance.GetPlatformsNumber();
        currentScore = 0;

        OnScoreChanged?.Invoke(this, EventArgs.Empty);
    }

    public void IncrementScore() {
        currentScore++;
        
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetScore() {
        return currentScore;
    }

    public int GetMaxScore() {
        return maxScore;
    }

    public float GetScoreNormalized() {
        return (float)currentScore / maxScore;
    }
}
