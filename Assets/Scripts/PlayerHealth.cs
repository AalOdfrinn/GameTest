using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float invincibilityTimeAfterHit = 3f;
    public float invincibilityFlashDelay = 0.2f;
    public SpriteRenderer graphics;
    public bool isInvincible = false;
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public static PlayerHealth instance;

    private void Awake()
    {
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de player health dans la scène");
            return;
        }
        instance = this;
    }
    void Start()
    {
       currentHealth = maxHealth; 
       healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(60);
        }
        
    }
    public void HealPlayer(int amout)
    {
        if((currentHealth + amout)> maxHealth)
        {
            currentHealth += maxHealth;
        }else{
            currentHealth += amout;
        }
        healthBar.SetHealth(currentHealth);
    }
    public void TakeDamage(int damage)
    {
        if(!isInvincible){
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            // vérifier si le joueur est toujours vivant
            if(currentHealth <=0)
            {
                Die();
                return;
            }

            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }
    public void Respawn()
    {
        PlayerMovement.instance.enabled = true;
        // jouer l'animation de mort
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        // empêcher les intéractions physique avec la scène
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
    public void Die(){
        Debug.Log("Le joueur est mort");
        // bloquer les mouvements
        PlayerMovement.instance.enabled = false;
        // jouer l'animation de mort
        PlayerMovement.instance.animator.SetTrigger("Die");
        // empêcher les intéractions physique avec la scène
        PlayerMovement.instance.rb.velocity = Vector3.zero; 
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
    }

    public IEnumerator InvincibilityFlash()
    {
        while(isInvincible)
        {
            //graphics.color = new Color(1f,1f,1f,0f);
            graphics.enabled=false;
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.enabled=true;
            //graphics.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
