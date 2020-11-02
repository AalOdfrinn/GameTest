using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public int coinsPickedUpInThisSceneCount;
    public bool isPlayerPresentByDefault = false;

    public static CurrentSceneManager instance;

    private void Awake()
    {
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de CurrentSceneManager dans la scène");
            return;
        }
        instance = this;

    }

}
