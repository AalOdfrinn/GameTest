using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsWindow;
    public string levelToLoad;
    public void StartGame()
    {
       SceneManager.LoadScene(levelToLoad); 
    }
    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
}
