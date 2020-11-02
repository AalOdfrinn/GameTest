using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthPoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // rendre de la vie au joueur
            if(PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth)
            {
                PlayerHealth.instance.HealPlayer(healthPoints);
                Destroy(gameObject);
            }
        }
    }
}
