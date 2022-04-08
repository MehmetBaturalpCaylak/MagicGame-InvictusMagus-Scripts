using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public Image[] p1roundWinImage;
    public Image[] p2roundWinImage;
    private char_oop p1;
    private char_oop2 p2;


    private Camera mainCam;
    public Collider2D camColliderUp;
    public Collider2D camColliderLeft;
    public Collider2D camColliderRight;
    public Collider2D camColliderDown;
    
    private bool gameoverTimeopenned = false;
    private bool gamegetsmaller;

    private bool doitOnce6;
    private bool doitOnce5;

    private float gametime;
    private float gamegetsmallerTime;
    public float gametimeStart;

    public Text gameoverMessage;
    public Text newRoundMessage;
    public Text gametimeText;

    public GameObject endGamePanel;

    // Start is called before the first frame update
    void Start()
    {
        
        doitOnce6 = true;
        doitOnce5 = true;
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        gametime = gametimeStart;

        gameoverMessage.enabled = false;
        newRoundMessage.enabled = false;

        gamegetsmaller = false;
        gamegetsmallerTime = 0f;
        p1 = GameObject.Find("P1").GetComponent<char_oop>();
        p2 = GameObject.Find("P2").GetComponent<char_oop2>();

        int c = 0;
        while (c < 3)
        {
            p1roundWinImage[c].enabled = false;
            p2roundWinImage[c].enabled = false;
            c += 1;
        }

        for(int i = 3; i > CharacterSelect.player1RaundRemain; i -= 1)
        {
            p2roundWinImage[3 - i].enabled = true;
        }
        for (int i = 3; i > CharacterSelect.player2RaundRemain; i -= 1)
        {
            p1roundWinImage[3 - i].enabled = true;
        }



    }

    // Update is called once per frame
    void Update()
    {

        if (gameoverTimeopenned)
        {
            return;
        }
        if (gamegetsmaller)
        {
            if(gamegetsmallerTime > 0)
            {
                gamegetsmallerTime -= Time.deltaTime;
            }
            else if (gamegetsmallerTime <= 0)
            {
                moveCam();
            }
        }
        if(gametime > 0)
        {            
            gametimeText.text = ((int)gametime).ToString();
            gametime -= Time.deltaTime;
        }
        else if (gametime <= 0)
        {
            gamegetsmaller = true;
        }
    }
    public void gameover(int wholost)
    {
        endGamePanel.SetActive(true);
        if (wholost == 1)
        {
            gameoverMessage.text = "Player " + (wholost + 1).ToString() + " has won";
        }
        else if (wholost == 2)
        {
            gameoverMessage.text = "Player " + (wholost - 1).ToString() + " has won";
        }
        gameoverMessage.enabled = true;
        gameoverTimeopenned = true;
    }
    public void p1RoundLost()
    {
        newRoundMessage.text = "Player 2 has won the round";
        p2roundWinImage[3 - CharacterSelect.player1RaundRemain].enabled = true;
        CharacterSelect.player1RaundRemain -= 1;
        if (CharacterSelect.player1RaundRemain == 0)
        {
            gameover(1);
            return;
        }
        newRound();
    }
    public void p2RoundLost()
    {
        newRoundMessage.text = "Player 1 has won the round";
        p1roundWinImage[3 - CharacterSelect.player2RaundRemain].enabled = true;
        CharacterSelect.player2RaundRemain -= 1;
        if (CharacterSelect.player2RaundRemain == 0)
        {
            gameover(2);
            return;
        }
        newRound();
    }
    public void newRound()
    {
        gameoverTimeopenned = true;
        StartCoroutine(newRoundRoutine());
    }
    IEnumerator newRoundRoutine()
    {
        newRoundMessage.enabled=true;
        yield return new WaitForSeconds(1.5f);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    private void moveCam()
    {
        if (mainCam.orthographicSize <= 4f)
        {
            return;
        }
        mainCam.orthographicSize -= 0.005f;
        camColliderUp.transform.position = new Vector2(camColliderUp.transform.position.x, camColliderUp.transform.position.y - 0.005f);
        camColliderRight.transform.position = new Vector2(camColliderRight.transform.position.x - 0.01f, camColliderRight.transform.position.y);
        camColliderLeft.transform.position = new Vector2(camColliderLeft.transform.position.x + 0.01f, camColliderLeft.transform.position.y);
        camColliderDown.transform.position = new Vector2(camColliderDown.transform.position.x, camColliderDown.transform.position.y + 0.005f);
        if (mainCam.orthographicSize <= 6f && doitOnce6)
        {
            gamegetsmallerTime = 3f;
            doitOnce6 = false;
        }
        else if(mainCam.orthographicSize <= 5f && doitOnce5)
        {
            gamegetsmallerTime = 3f;
            doitOnce5 = false;
        }
    }
    public bool getGameoverTimeOppened()
    {

        return this.gameoverTimeopenned;
    }
}
