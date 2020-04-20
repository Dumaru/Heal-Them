using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


/// <summary>
/// Manages navigation through the menu system
/// </summary>
public static class MenuManager
{
    /// <summary>
    /// Goes to the menu with the given name
    /// </summary>
    /// <param name="name">name of the menu to go to</param>
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Difficulty:
                // Go to DifficultyMenu scene
                // deactivate MainMenuCanvas and instantiate prefab
                GameObject mainMenuCanv = GameObject.Find("MainMenuCanvas");
                if (mainMenuCanv != null)
                {
                    mainMenuCanv.SetActive(false);
                }
                Object.Instantiate(Resources.Load("DifficultyMenu"));
                break;
            case MenuName.HighScore:

                // deactivate MainMenuCanvas and instantiate prefab
                GameObject mainMenuCanvas = GameObject.Find("MainMenuCanvas");
                if (mainMenuCanvas != null)
                {
                    mainMenuCanvas.SetActive(false);
                }
                Object.Instantiate(Resources.Load("HighScoreMenu"));
                break;
            case MenuName.Main:
                // go to MainMenu scene
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Pause:
                // instantiate prefab
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuName.GameOver:
                // instantiate prefab
                Object.Instantiate(Resources.Load("GameOverMenu"));
                break;
            case MenuName.Credits:
                // instantiate prefab
                Object.Instantiate(Resources.Load("CreditsMenu"));
                break;
        }
    }
}
