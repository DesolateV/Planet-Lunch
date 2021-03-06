﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float distance;

    private bool movingLeft = true;

    public Transform groundDetection;
   
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundinfo.collider == false )
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }
    }
   public void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Food") && movingLeft == true)
       {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingLeft = false;
            speed = 3.0f;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingLeft = true;
            speed = 3.0f;
        }
        if ((other.gameObject.tag == "Player") && movingLeft == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingLeft = false;
            speed = 7.0f;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingLeft = true;
            speed = 3.0f;
        }
    }
     
}
