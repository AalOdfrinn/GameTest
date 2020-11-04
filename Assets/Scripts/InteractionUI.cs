using Boo.Lang;
using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    // Start is called before the first frame update

    public Text interactUI;
    public List<string> enabledBy = new List<string>();
    public static InteractionUI instance;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<Text>(); 
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de InteractionUI dans la scène");
            return;
        }
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
       if(enabledBy.Count != 0)
        {
            interactUI.enabled = true;
        }
        else
        {
            interactUI.enabled = false;
        }
    }
}
