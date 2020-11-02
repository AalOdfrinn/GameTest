using UnityEngine;

public class Ennemy_Patrol : MonoBehaviour
{
    public int damageOnCollision = 20; 
    public SpriteRenderer graphics;
    public float speed;
    public Transform[] waypoint;

    private Transform target;
    private int destPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = waypoint[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position; 
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position)< 0.3f)
        {
            destPoint = (destPoint + 1) % waypoint.Length;
            target = waypoint[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
