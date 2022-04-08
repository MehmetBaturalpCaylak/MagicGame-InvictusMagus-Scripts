using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeffendEffect : MonoBehaviour
{
    public char_movement p1;
    public char_movement2 p2;
    public char_oop p1oop;
    public char_oop2 p2oop;
    private int selectedID;
    private Animator anim;
    private bool doitonce;
    private float ligntingCounterTime;
    // Start is called before the first frame update
    void Start()
    {
        doitonce = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        anim = gameObject.GetComponent<Animator>();
        if (gameObject.tag == "selectp1")
        {
            selectedID = p1oop.charID;
        }   
        else if (gameObject.tag == "selectp2")
        {
            selectedID = p2oop.charID;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "selectp1")
        {
            if (p1.deffendKeyPressed)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                if (doitonce)
                {
                    if (selectedID == 1)
                    {
                        anim.SetBool("LightningDef", true);
                        ligntingCounterTime = 0.5f;
                        doitonce = false;
                    }
                }
                
                if (ligntingCounterTime > 0)
                {
                    ligntingCounterTime -= Time.deltaTime;
                }
                else if (ligntingCounterTime <= 0)
                {
                    anim.SetBool("LightningDef", false);
                    anim.SetBool("LCounterEnded", true);
                }

                switch (selectedID)
                {
                    case 2:
                        anim.SetBool("FireDef", true);
                        break;
                    case 3:
                        anim.SetBool("WindDef", true);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                doitonce = true;
                switch (selectedID)
                {
                    case 1:
                        anim.SetBool("LightningDef", false);
                        anim.SetBool("LCounterEnded", false);
                        break;
                    case 2:
                        anim.SetBool("FireDef", false);
                        break;
                    case 3:
                        anim.SetBool("WindDef", false);
                        break;
                    default:
                        break;
                }
            }
        }
        else if (gameObject.tag == "selectp2")
        {
            if (p2.deffendKeyPressed)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                if (doitonce)
                {
                    if (selectedID == 1)
                    {
                        anim.SetBool("LightningDef", true);
                        ligntingCounterTime = 0.5f;
                        doitonce = false;
                    }
                }

                if (ligntingCounterTime > 0)
                {
                    ligntingCounterTime -= Time.deltaTime;
                }
                else if (ligntingCounterTime <= 0)
                {
                    anim.SetBool("LightningDef", false);
                    anim.SetBool("LCounterEnded", true);
                }

                switch (selectedID)
                {
                    case 2:
                        anim.SetBool("FireDef", true);
                        break;
                    case 3:
                        anim.SetBool("WindDef", true);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                doitonce = true;
                switch (selectedID)
                {
                    case 1:
                        anim.SetBool("LightningDef", false);
                        anim.SetBool("LCounterEnded", false);
                        break;
                    case 2:
                        anim.SetBool("FireDef", false);
                        break;
                    case 3:
                        anim.SetBool("WindDef", false);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
