using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    public GameManager gm;
    public void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Food") && (Input.GetAxisRaw("Eat") > 0))
        {
            gm.subtractDNAValue();
            //Debug.Log("Eaten");
            Destroy(other.gameObject);
        }
    }
}
