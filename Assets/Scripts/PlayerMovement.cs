using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rgbd;
    [SerializeField]
    private float maxSpeed;

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

    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        PlayerInputs();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        playerMovement(horizontal);
        isGrounded = IsGrounded();
        ResetValues();
    }
    private void playerMovement(float horizontal)
    {
        if (isGrounded && jump)
        {
            isGrounded = false;
            rgbd.AddForce(new Vector2(0, jumpForce));
        }
        rgbd.velocity = new Vector2(horizontal * maxSpeed, rgbd.velocity.y);
    }
    private void PlayerInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
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
}

