using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCountered : MonoBehaviour
{
    public GameObject counterEffect;
    public void spawncounter(Transform pos)
    {
        Instantiate(counterEffect, new Vector3(pos.position.x, pos.position.y - 0.3f, 10), Quaternion.identity,pos);
    }
}
