using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using System;

public class Ladder : MonoBehaviour
{
    public string objectEnabler;
    public BoxCollider2D topCollider;
    private PlayerMovement playerMovement;
    public bool isInRange;
    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = false;
            topCollider.isTrigger=false;
            return;
        }
        if(isInRange && Input.GetKeyDown(KeyCode.E)){
            playerMovement.isClimbing = true;
            topCollider.isTrigger=true;
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int objectEnablerIndex = InteractionUI.instance.enabledBy.IndexOf(objectEnabler);
            if(objectEnablerIndex > -1)
            {
                InteractionUI.instance.enabledBy.RemoveAt(objectEnablerIndex); 
            }
            isInRange = false;
            playerMovement.isClimbing = false;
            topCollider.isTrigger=false;
        }
    }
}
