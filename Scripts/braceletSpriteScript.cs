using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class braceletSpriteScript : MonoBehaviour
{
    public Sprite lightning;
    public Sprite flame;
    public Sprite wind;

    private char_oop p1;
    private char_oop2 p2;

    // Start is called before the first frame update
    private void Awake()
    {
        p1 = GameObject.Find("P1").GetComponent<char_oop>();
        p2 = GameObject.Find("P2").GetComponent<char_oop2>();
    }
    void Start()
    {
        if (gameObject.tag == "selectp1")
        {
            switch (p1.getID())
            {
                case 1:
                    gameObject.GetComponent<SpriteRenderer>().sprite = lightning;
                    break;
                case 2:
                    gameObject.GetComponent<SpriteRenderer>().sprite = flame;
                    break;
                case 3:
                    gameObject.GetComponent<SpriteRenderer>().sprite = wind;
                    break;
                default:
                    Debug.LogWarning("ID Missmatch");
                    break;
            }
        }
        else if (gameObject.tag == "selectp2")
        {
            switch (p2.getID())
            {
                case 1:
                    gameObject.GetComponent<SpriteRenderer>().sprite = lightning;
                    break;
                case 2:
                    gameObject.GetComponent<SpriteRenderer>().sprite = flame;
                    break;
                case 3:
                    gameObject.GetComponent<SpriteRenderer>().sprite = wind;
                    break;
                default:
                    Debug.LogWarning("ID Missmatch");
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
