using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundChecker : MonoBehaviour
{
    private char_movement p1;
    private char_movement2 p2;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "selectp1")
        {
            p1 = GameObject.Find("P1").GetComponent<char_movement>();
        }
        else if (gameObject.tag == "selectp2")
        {
            p2 = GameObject.Find("P2").GetComponent<char_movement2>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            if (gameObject.tag == "selectp1")
            {
                p1.setGround(true);
            }
            else if(gameObject.tag == "selectp2")
            {
                p2.setGround(true);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            if (gameObject.tag == "selectp1")
            {
                p1.setGround(true);
            }
            else if (gameObject.tag == "selectp2")
            {
                p2.setGround(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            if (gameObject.tag == "selectp1")
            {
                p1.setGround(false);
            }
            else if (gameObject.tag == "selectp2")
            {
                p2.setGround(false);
            }
        }
    }

}
