using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public void HandleMainMenuButtonClicked()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Main);
        Destroy(this.gameObject);
    }
}