using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_HitpointBurningEffect : MonoBehaviour
{
    private char_oop p1;
    private char_oop2 p2;

    // Start is called before the first frame update
    void Start()
    {
        p1 = GameObject.Find("P1").GetComponent<char_oop>();
        p2 = GameObject.Find("P2").GetComponent<char_oop2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p1.getBurning())
        {
            if (gameObject.tag == "selectp1")
            {
                gameObject.GetComponent<Image>().enabled = true;
            }
        }
        else
        {
            if (gameObject.tag == "selectp1")
            {
                gameObject.GetComponent<Image>().enabled = false;
            }
        }
        if (p2.getBurning())
        {
            if (gameObject.tag == "selectp2")
            {
                gameObject.GetComponent<Image>().enabled = true;
            }
        }
        else
        {
            if (gameObject.tag == "selectp2")
            {
                gameObject.GetComponent<Image>().enabled = false;
            }
        }


    }
}
