using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float thrust = 100f;
    private GameManager gameManager;
    //private EnemyHealth eHealth;
    public Player soldier;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        soldier = GameObject.FindWithTag("Player").GetComponent<Player>();
        rb2d = GetComponent<Rigidbody2D>();
        DestroyObjectDelayed();
        transform.rotation.Set(0f, 0f, 0f, 0);
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (soldier.facingRight == true)
            rb2d.AddForce(transform.right * thrust);
        if (soldier.facingRight == !true)
            rb2d.AddForce(transform.right * -thrust);
        Debug.Log("Object thrust");
        DestroyObjectDelayed();
    }
    private void DestroyObjectDelayed()
    {
        Destroy(gameObject, 0.75f);
        Debug.Log("Object Destroyed");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
           other.gameObject.SetActive(false);
        }
    }
}
