using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food" && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(other.gameObject);
        }
    }
}
