using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDoneScript : MonoBehaviour
{
    private SpriteRenderer spr_block;
    private Transform block_transform;
    // Start is called before the first frame update
    void Start()
    {
        spr_block = gameObject.GetComponent<SpriteRenderer>();
        spr_block.sortingOrder = 5;
        spr_block.color = new Color(spr_block.color.r, spr_block.color.g, spr_block.color.b, 0.5f);

        block_transform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (spr_block.color.a > 0)
        {
            spr_block.color = new Color(spr_block.color.r, spr_block.color.g, spr_block.color.b, spr_block.color.a - 0.005f);
            block_transform.Translate(Vector2.up * 0.005f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
