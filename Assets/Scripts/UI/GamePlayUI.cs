using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider progressBar;

    private void Awake() {
        scoreText.text = "0";
        progressBar.value = 0f;
    }

    public void Start() {
        ScoreManager.Instance.OnScoreChanged += ScoreManager_OnScoreChanged;
    }

    private void ScoreManager_OnScoreChanged(object sender, System.EventArgs e) {
        scoreText.text = ScoreManager.Instance.GetScore().ToString();

        progressBar.value = (float)ScoreManager.Instance.GetScore() / ScoreManager.Instance.GetMaxScore();
    }

}
