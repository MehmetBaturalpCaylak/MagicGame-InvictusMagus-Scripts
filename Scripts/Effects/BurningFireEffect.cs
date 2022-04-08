using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningFireEffect : MonoBehaviour
{
    private char_oop p1;
    private char_oop2 p2;
    private float aliveTime;
    // Start is called before the first frame update
    void Awake()
    {
        p1 = GameObject.Find("P1").GetComponent<char_oop>();
        p2 = GameObject.Find("P2").GetComponent<char_oop2>();
        aliveTime = 3.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (aliveTime > 0)
        {
            aliveTime -= Time.deltaTime;
        }
        else if(aliveTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "selectp1")
        {
            if (collision.tag == "p2")
            {
                Debug.Log(collision.tag);
                p2.burnit();
            }
        }
        else if(gameObject.tag == "selectp2")
        {
            if (collision.tag == "p1")
            {
                p1.burnit();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.tag == "selectp1")
        {
            if (collision.tag == "p2")
            {
                p2.burnit();
            }
        }
        else if (gameObject.tag == "selectp2")
        {
            if (collision.tag == "p1")
            {
                p1.burnit();
            }
        }
    }
}
