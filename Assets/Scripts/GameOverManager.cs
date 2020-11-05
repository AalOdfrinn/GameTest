using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameOverManager instance;

    private void Awake()
    {
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de gameover dans la scène");
            return;
        }
        instance = this;
    }
    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }
    public void RetryButton()
    {
        // Recommencer le niveau
        // Recharge la scène
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
        PlayerHealth.instance.Respawn();
    }
    public void MainMenuButton()
    {
        // Retour au main menu
        SceneManager.LoadScene("MainMenu");

    }
    public void QuitButton()
    {
        // Fermer le jeu
        Application.Quit();

    }
}
