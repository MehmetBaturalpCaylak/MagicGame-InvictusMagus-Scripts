using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Dropdown dropdown1;
    public Dropdown dropdown2;
    [HideInInspector]
    public static int player1sel;
    public static int player2sel;
    public static int player1RaundRemain;
    public static int player2RaundRemain;

    public AudioSource but;
    private void Awake()
    {
        player1sel = 1;
        player2sel = 2;
        player1RaundRemain = 3;
        player2RaundRemain = 3;
    }
    public void characterSelGettingData()
    {
        but.Play();
        if (dropdown1.value == 0)
        {
            player1sel = 1;
        }
        else if (dropdown1.value == 1)
        {
            player1sel = 2;
        }
        else if (dropdown1.value == 2)
        {
            player1sel = 3;
        }

        if (dropdown2.value == 0)
        {
            player2sel = 1;
        }
        else if (dropdown2.value == 1)
        {
            player2sel = 2;
        }
        else if (dropdown2.value == 2)
        {
            player2sel = 3;
        }
    }
}
