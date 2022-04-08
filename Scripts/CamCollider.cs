using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "leftcamcol")
        {
            if (collision.tag == "p1" || collision.tag == "p2")
            {
                if (collision.tag == "p1")
                {
                    collision.GetComponent<char_oop>().setHP(-10);
                    collision.GetComponent<char_movement>().startSkid(0.2f);
                }
                else if (collision.tag == "p2")
                {
                    collision.GetComponent<char_oop2>().setHP(-10);
                    collision.GetComponent<char_movement2>().startSkid(0.2f);
                }
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 10), ForceMode2D.Impulse);
            }
        }
        else if (gameObject.tag == "rightcamcol")
        {
            if (collision.tag == "p1" || collision.tag == "p2")
            {
                if (collision.tag == "p1")
                {
                    collision.GetComponent<char_oop>().setHP(-10);
                    collision.GetComponent<char_movement>().startSkid(0.2f);
                }
                else if (collision.tag == "p2")
                {
                    collision.GetComponent<char_oop2>().setHP(-10);
                    collision.GetComponent<char_movement2>().startSkid(0.2f);
                }
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 10), ForceMode2D.Impulse);
            }
        }
        else if (gameObject.tag == "upcamcol")
        {
            if (collision.tag == "p1" || collision.tag == "p2")
            {
                if (collision.tag == "p1")
                {
                    collision.GetComponent<char_oop>().setHP(-10);
                    collision.GetComponent<char_movement>().startSkid(0.2f);
                }
                else if (collision.tag == "p2")
                {
                    collision.GetComponent<char_oop2>().setHP(-10);
                    collision.GetComponent<char_movement2>().startSkid(0.2f);
                }
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -5), ForceMode2D.Impulse);
            }
        }
        else if (gameObject.tag == "downcamcol")
        {
            Debug.Log("in");
            if (collision.tag == "p1" || collision.tag == "p2")
            {
                if (collision.tag == "p1")
                {
                    GameObject.Find("P1").GetComponent<char_oop>().setHP(-100);
                }
                else if (collision.tag == "p2")
                {
                    GameObject.Find("P2").GetComponent<char_oop2>().setHP(-100);
                }
            }
        }


    }
}
