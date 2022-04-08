using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterEffect : MonoBehaviour
{
    private float aliveTime;
    private SpriteRenderer spr_counter;
    private float factorA;
    // Start is called before the first frame update
    void Start()
    {
        aliveTime = 0.8f;
        spr_counter = gameObject.GetComponent<SpriteRenderer>();
        factorA = -0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        if(aliveTime > 0)
        {
            aliveTime -= Time.deltaTime;
            spr_counter.color = new Color(spr_counter.color.r, spr_counter.color.g, spr_counter.color.b, spr_counter.color.a + factorA);
        }
        else
        {
            Destroy(gameObject);
        }
        if (spr_counter.color.a == 0.5f || spr_counter.color.a == 1)
        {
            factorA *= -1;
        }
    }
}
