using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public bool isClimbing;
    private float verticalMovement;
    private float horizontalMovement;
    public Transform groundCheck;
    public LayerMask collisionLayers;
    public float groundCheckRadius;
    public SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private bool isJumping;
    public float jumpForce;
    public float climbSpeed;
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public CapsuleCollider2D playerCollider;
    private Vector3 velocity = Vector3.zero;

    public static PlayerMovement instance;

    private void Awake()
    {
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de player movement dans la scène");
            return;
        }
        instance = this;
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded && !isClimbing)
        {
            isJumping = true;
        }

        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("isClimbing",isClimbing);

    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.deltaTime;
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        MovePlayer(horizontalMovement, verticalMovement);

    }
    void MovePlayer(float _horizontalMovement,float _verticalMovement )
    {
        if (!isClimbing)
        {
            Vector3 targetVolocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVolocity, ref velocity, .05f);

            if (isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }
        else
        {
            //Déplacement vertical

            Vector3 targetVolocity = new Vector2(0, _verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVolocity, ref velocity, .05f);
        }
    }
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
            spriteRenderer.flipX = true;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
