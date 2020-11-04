using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public string objectEnabler;
    public AudioClip sound;
    public int coinsToAdd;
    public Animator animator;
    private bool isInRange;
    private Text interactUI;
    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OpenChest();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int objectEnablerIndex = InteractionUI.instance.enabledBy.IndexOf(objectEnabler);
            if (objectEnablerIndex > -1)
            {
                InteractionUI.instance.enabledBy.RemoveAt(objectEnablerIndex);
            }
            interactUI.enabled = false;
            isInRange = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InteractionUI.instance.enabledBy.Add(objectEnabler);
            isInRange = true;
        }

    }
    private void OpenChest()
    {
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddCoins(coinsToAdd);
        AudioManager.instance.PlayClipAt(sound, transform.position);
        GetComponent<BoxCollider2D>().enabled = false;
        int objectEnablerIndex = InteractionUI.instance.enabledBy.IndexOf(objectEnabler);
        if (objectEnablerIndex > -1)
        {
            InteractionUI.instance.enabledBy.RemoveAt(objectEnablerIndex);
        }
        interactUI.enabled = false;
    }
}
