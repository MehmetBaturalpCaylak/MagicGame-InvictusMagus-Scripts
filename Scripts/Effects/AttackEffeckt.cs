using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffeckt : MonoBehaviour
{
    public char_movement father;
    public char_movement2 father2;
    public char_oop fatherOop;
    public char_oop2 fatherOop2;
    private int selectedID;
    private float lightninganimStart = 0f;
    private float fireattackanimStart = 0f;
    private float windattackanimStart = 0f;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        if (gameObject.tag == "selectp1")
        {
            selectedID = fatherOop.getID();
        }
        else if (gameObject.tag == "selectp2")
        {
            selectedID = fatherOop2.getID();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "selectp1")
        {
            if (father.attackKeyPressed)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                Debug.Log("Key pressed");
                switch (selectedID)
                {
                    case 1:
                        anim.SetBool("lightning", true);
                        lightninganimStart = 0.16f;
                        break;
                    case 2:
                        anim.SetBool("fireball", true);
                        fireattackanimStart = 0.2f;
                        break;
                    case 3:
                        anim.SetBool("windattack", true);
                        windattackanimStart = 0.16f;
                        break;
                    default:
                        break;
                }
                father.attackKeyPressed = false;
            }
            switch (selectedID)
            {
                case 1:
                    if (lightninganimStart > 0)
                    {
                        lightninganimStart -= Time.deltaTime;
                    }
                    else
                    {
                        gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        anim.SetBool("lightning", false);
                    }
                    break;
                case 2:
                    if (fireattackanimStart > 0)
                    {
                        fireattackanimStart -= Time.deltaTime;
                    }
                    else
                    {
                        gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        anim.SetBool("fireball", false);
                    }
                    break;
                case 3:
                    if (windattackanimStart > 0)
                    {
                        windattackanimStart -= Time.deltaTime;
                    }
                    else
                    {
                        gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        anim.SetBool("windattack", false);
                    }
                    break;
                default:
                    break;
            }
        }
        else if (gameObject.tag == "selectp2")
        {
            if (father2.attackKeyPressed)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                Debug.Log("Key pressed");
                switch (selectedID)
                {
                    case 1:
                        anim.SetBool("lightning", true);
                        lightninganimStart = 0.16f;
                        break;
                    case 2:
                        anim.SetBool("fireball", true);
                        fireattackanimStart = 0.2f;
                        break;
                    case 3:
                        anim.SetBool("windattack", true);
                        windattackanimStart = 0.16f;
                        break;
                    default:
                        break;
                }
                father2.attackKeyPressed = false;
            }
            switch (selectedID)
            {
                case 1:
                    if (lightninganimStart > 0)
                    {
                        lightninganimStart -= Time.deltaTime;
                    }
                    else
                    {
                        gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        anim.SetBool("lightning", false);
                    }
                    break;
                case 2:
                    if (fireattackanimStart > 0)
                    {
                        fireattackanimStart -= Time.deltaTime;
                    }
                    else
                    {
                        gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        anim.SetBool("fireball", false);
                    }
                    break;
                case 3:
                    if (windattackanimStart > 0)
                    {
                        windattackanimStart -= Time.deltaTime;
                    }
                    else
                    {
                        gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        anim.SetBool("windattack", false);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
