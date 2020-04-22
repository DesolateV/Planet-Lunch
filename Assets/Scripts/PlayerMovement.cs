using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rgbd;
    private Animator anim;
    [SerializeField]
    private float maxSpeed;
    public bool facingRight;

    [SerializeField]
    private Transform[] groundPoints;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    //int whatIsGround;
    private bool isGrounded;
    private bool jump;
    [SerializeField]
    private float jumpForce;

    void Start()
    {
        facingRight = true;
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Jump();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Playermovement(horizontal);
        isGrounded = IsGrounded();
        Flip(horizontal);
        ResetValues();
    }
    private void Playermovement(float horizontal)
    {
        if (isGrounded && jump)
        {
            Debug.Log("Jumping");
            rgbd.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }
        rgbd.velocity = new Vector2(horizontal * maxSpeed, rgbd.velocity.y);
    }
    private void Jump()
    {
        if (Input.GetAxisRaw("Jump") > 0)
        {
            Debug.Log("Space");
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
        if (rgbd.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius);// whatIsGround

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        Debug.Log("IsGrounded");
        return false;
    }
}

