﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    private BoxCollider2D playerCollider;

    [SerializeField]
    private BoxCollider2D platformCollider;
    [SerializeField]
    private BoxCollider2D platformTrigger;
    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GameObject.Find("Soldier").GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(platformCollider,platformTrigger,true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Soldier")
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Soldier")
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
        }
    }


}
