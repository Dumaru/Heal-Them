using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    #region Fields
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textScoreDeads;

    private static int currentLevel = 0;
    #endregion
    void Start()
    {
        // Pauses the game
        // AudioManager.Play(AudioClipName.GameOver);
        Time.timeScale = 0;
        textScore.text = "Score: " + PlayerPrefs.GetInt("score", 0);
        textScoreDeads.text = "Deads: " + PlayerPrefs.GetInt("deads", 0);
    }

    public void HandleNextButtonClicked()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        // Resumes the game time
        Time.timeScale = 1;
        SceneManager.LoadScene("Level");

    }
    public void HandleMainMenuButtonClicked()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        // Resumes the game time
        Time.timeScale = 1;
        MenuManager.GoToMenu(MenuName.Main);
        Destroy(this.gameObject);
    }

}
