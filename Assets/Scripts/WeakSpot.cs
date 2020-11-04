using System.Data.SqlTypes;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public AudioClip sound;
    public GameObject objectToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound,transform.position);
            Destroy(objectToDestroy);
        }
        
    }
}