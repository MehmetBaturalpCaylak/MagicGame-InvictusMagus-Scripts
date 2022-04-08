using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour
{ 
    public void SelectMap1()
    {
        SceneManager.LoadScene(1);
    }

    public void SelectMap2()
    {
        SceneManager.LoadScene(2);
    }
}
