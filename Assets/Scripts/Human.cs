using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private Rigidbody2D rgbd;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Food")
        {
            Destroy(gameObject);
          }
    }
}
