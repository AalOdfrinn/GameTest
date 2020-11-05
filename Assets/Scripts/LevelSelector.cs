using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    public void LoadLevelPassed(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
