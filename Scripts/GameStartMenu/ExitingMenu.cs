using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitingMenu : MonoBehaviour
{
    public Image image;
    public Animator animator;
    private float scenePassTime;
    private bool scenepassActivated;
    private bool scenepassActivated1;
    void Awake()
    {
        image.enabled = false;
        scenePassTime = 0f;
        scenepassActivated = false;
        scenepassActivated1 = false;
        
    }
    public void Update()
    {
        if (scenePassTime > 0)
        {
            scenePassTime -= Time.deltaTime;
        }
        else if (scenePassTime <= 0)
        {
            if (scenepassActivated)
            {
                SceneManager.LoadScene("FirstMapScene");
            }
            else if (scenepassActivated1)
            {
                SceneManager.LoadScene("SecondMapScene");
            }
        }
    }

    public void selectM1()
    {
        scenepassActivated = true;
        animator.SetBool("Start", true);
        scenePassTime = 1f;

    }

    public void selectM2()
    {
        scenepassActivated1 = true;
        animator.SetBool("Start", true);
        scenePassTime = 1f;
    }

}
