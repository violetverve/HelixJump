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
        maxScore = HelixGameManager.Instance.GetPlatformsNumber();
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
}
