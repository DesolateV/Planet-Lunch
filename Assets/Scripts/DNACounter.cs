using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DNACounter : MonoBehaviour
{
    public GameManager gm; 
    Text DNA;
    void Start()
    {
        DNA = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DNA.text = "Food needed:" + gm.getDNAValue();
    }
}
