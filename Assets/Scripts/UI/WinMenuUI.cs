using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenuUI : MonoBehaviour {

    [SerializeField] private Button nextLevelButton;

    private void Awake()  {

        nextLevelButton.onClick.AddListener(() => {
            LevelManager.Instance.LoadNextLevel();
        });
    }


    private void Start() {
        HelixGameManager.Instance.OnLevelComplete += HelixGameManager_OnLevelComplete;

        Hide();
    }


    private void HelixGameManager_OnLevelComplete(object sender, System.EventArgs e) {
        Show();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void Show() {
        gameObject.SetActive(true);
    }

}