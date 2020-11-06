using UnityEngine.UI;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private string objectEnabler = "dialog";
    public Dialog dialog;
    public bool isInRange;
    void Update()
    {
       if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialog();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = true;
            InteractionUI.instance.enabledBy.Add(objectEnabler);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = false;
            int objectEnablerIndex = InteractionUI.instance.enabledBy.IndexOf(objectEnabler);
            if(objectEnablerIndex > -1)
            {
                InteractionUI.instance.enabledBy.RemoveAt(objectEnablerIndex); 
            }
            DialogManager.instance.EndDialog();
        }
        
    }
    private void TriggerDialog()
    {
        DialogManager.instance.StartDialog(dialog);

    }
}
