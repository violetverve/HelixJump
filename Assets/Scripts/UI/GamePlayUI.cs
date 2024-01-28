using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI nextLevelText;

    private void Awake() {
        scoreText.text = "0";
        progressBar.value = 0f;
    }

    public void Start() {
        ScoreManager.Instance.OnScoreChanged += ScoreManager_OnScoreChanged;

        HelixGameManager.Instance.OnGameOver += HelixGameManager_OnGameOver;
        HelixGameManager.Instance.OnLevelComplete += HelixGameManager_OnLevelComplete;

        int currentLevel = LevelManager.Instance.GetCurrentLevel();
        currentLevelText.text = currentLevel.ToString();
        nextLevelText.text = (currentLevel + 1).ToString();
    }


    private void HelixGameManager_OnLevelComplete(object sender, System.EventArgs e) {
        Hide();
    }

    private void HelixGameManager_OnGameOver(object sender, System.EventArgs e) {
        Hide();
    }

    private void ScoreManager_OnScoreChanged(object sender, System.EventArgs e) {
        scoreText.text = ScoreManager.Instance.GetScore().ToString();

        progressBar.value = ScoreManager.Instance.GetScoreNormalized();
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }


}
