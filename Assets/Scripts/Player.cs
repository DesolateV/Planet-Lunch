using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Movement
    private Rigidbody2D rgbd;
    private Animator anim;
    [SerializeField]
    private float maxSpeed;
    public bool facingRight;

    //Jumping
    [SerializeField]
    private Transform[] groundPoints;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGrounded;
    private bool jump;
    [SerializeField]
    private float jumpForce;

    //Health
    public int maxHealth = 5;
    public ParticleSystem hitParticle;

    void Start()
    {
        facingRight = true;
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerInputs();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();
        
        PlayerMovement(horizontal);

        Flip(horizontal);

        ResetValues();  
    }

    private void PlayerMovement(float horizontal)
    {
        if(isGrounded && jump)
        {
            isGrounded = false;
            rgbd.AddForce(new Vector2(0, jumpForce));
        }

        rgbd.velocity = new Vector2(horizontal * maxSpeed, rgbd.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(horizontal));

    }

    private void PlayerInputs()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }
    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void ResetValues()
    {
        jump = false;
    }
    private bool IsGrounded()
    {
        if(rgbd.velocity.y <=0)
        {
            foreach(Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {

            Instantiate(hitParticle, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }

        //currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
