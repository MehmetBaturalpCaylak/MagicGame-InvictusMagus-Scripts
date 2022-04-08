using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningEffect : MonoBehaviour
{
    public GameObject fire_to_p1;
    public GameObject fire_to_p2;
    public void spawnfireObject(Transform pos,string todmg)
    {
        if (todmg == "p1")
        {
            Instantiate(fire_to_p1, new Vector3(pos.position.x, pos.position.y, 0),Quaternion.identity);
        }
        else if (todmg == "p2")
        {
            Instantiate(fire_to_p2, new Vector3(pos.position.x, pos.position.y, 0), Quaternion.identity);

        }
    }
}
