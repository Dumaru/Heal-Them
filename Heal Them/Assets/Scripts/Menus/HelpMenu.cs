using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public void HandleMainMenuButtonClicked()
    {
        MenuManager.GoToMenu(MenuName.Main);
        Destroy(this.gameObject);
    }
}