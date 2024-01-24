using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenuUI : MonoBehaviour {

    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button startOverButton;

    private void Awake() {
        startOverButton.onClick.AddListener(() => {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    private void Start() {
        HelixGameManager.Instance.OnGameOver += HelixGameManager_OnGameOver;

        Hide();
    }

    private void HelixGameManager_OnGameOver(object sender, System.EventArgs e) {
        Show();
        scoreText.text = ScoreManager.Instance.GetScore().ToString();
    }

    private void Hide() {
        gameOverMenu.SetActive(false);
    }

    private void Show() {
        gameOverMenu.SetActive(true);
    }

}