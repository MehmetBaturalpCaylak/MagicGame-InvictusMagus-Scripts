using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD_hitpointEnblem : MonoBehaviour
{
    private char_oop p1;
    private char_oop2 p2;

    public Sprite lightning;
    public Sprite flame;
    public Sprite wind;
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
                    gameObject.GetComponent<Image>().sprite = lightning;
                    break;
                case 2:
                    gameObject.GetComponent<Image>().sprite = flame;
                    break;
                case 3:
                    gameObject.GetComponent<Image>().sprite = wind;
                    break;
                default:
                    Debug.LogWarning("ID missmatch");
                    break;
            }
        }
        else if (gameObject.tag == "selectp2")
        {
            switch (p2.getID())
            {
                case 1:
                    gameObject.GetComponent<Image>().sprite = lightning;
                    break;
                case 2:
                    gameObject.GetComponent<Image>().sprite = flame;
                    break;
                case 3:
                    gameObject.GetComponent<Image>().sprite = wind;
                    break;
                default:
                    Debug.LogWarning("ID missmatch");
                    break;
            }

        }
    }

}
