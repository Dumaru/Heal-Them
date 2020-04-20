using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Listens for the OnClick events for the difficulty menu buttons
/// </summary>
public class DifficultyMenu
{
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
    }
    private void HandleGameStartedEvent(int diff)
    {
        SceneManager.LoadScene("GamePlayLevel1");
    }

    /// <summary>
    /// Handles the on click event from the easy button
    /// </summary>
    public void HandleEasyButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }

    /// <summary>
    /// Handles the on click event from the medium button
    /// </summary>
    public void HandleMediumButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }

    /// <summary>
    /// Handles the on click event from the hard button
    /// </summary>
    public void HandleHardButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }

    /// <summary>
    /// Handles the on click event from the hard button
    /// </summary>
    public void HandleBackButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
