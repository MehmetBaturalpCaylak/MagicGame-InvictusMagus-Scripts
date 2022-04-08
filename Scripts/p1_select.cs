using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1_select : MonoBehaviour
{
    private float fatherScaleX = 1f;
    private float tempScale = 1f;
    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "selectp1")
        {
            if (GameObject.Find("P1").transform.localScale.x * tempScale < 0)
            {
                fatherScaleX = -1;
                tempScale = GameObject.Find("P1").transform.localScale.x;
            }
            else if (GameObject.Find("P1").transform.localScale.x * tempScale >= 0)
            {
                fatherScaleX = +1;
                tempScale = GameObject.Find("P1").transform.localScale.x;
            }
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * fatherScaleX, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        else if (gameObject.tag == "selectp2")
        {
            if (GameObject.Find("P2").transform.localScale.x * tempScale < 0)
            {
                fatherScaleX = -1;
                tempScale = GameObject.Find("P2").transform.localScale.x;
            }
            else if (GameObject.Find("P2").transform.localScale.x * tempScale >= 0)
            {
                fatherScaleX = +1;
                tempScale = GameObject.Find("P2").transform.localScale.x;
            }
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * fatherScaleX, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }

    }
}
