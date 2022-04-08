using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windJump : MonoBehaviour
{
    private Animator anim;
    private float animstart = 0f;
    public char_movement p1;
    public char_movement2 p2;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "selectp1")
        {
            if (p1.iDthreejumpkeyPressed)
            {
                anim.SetBool("start", true);
                animstart = 0.2f;
                p1.iDthreejumpkeyPressed = false;
            }
            if (animstart > 0)
            {
                animstart -= Time.deltaTime;
            }
            else if (animstart <= 0)
            {
                anim.SetBool("start", false);
            }
        }
        else if(gameObject.tag == "selectp2")
        {
            if (p2.iDthreejumpkeyPressed)
            {
                anim.SetBool("start", true);
                animstart = 0.2f;
                p2.iDthreejumpkeyPressed = false;
            }
            if (animstart > 0)
            {
                animstart -= Time.deltaTime;
            }
            else if (animstart <= 0)
            {
                anim.SetBool("start", false);
            }
        }
    }
}
