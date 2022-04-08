using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDonePopUpScript : MonoBehaviour
{
    public GameObject block;

    public void spawnTemp(Transform pos)
    {
        Debug.Log("true");
        Instantiate(block, new Vector3(pos.position.x, pos.position.y + 0.6f, 0), Quaternion.identity);
        Debug.Log("ok");
    }
}
