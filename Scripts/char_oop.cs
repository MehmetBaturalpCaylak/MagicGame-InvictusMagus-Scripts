using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class char_oop : MonoBehaviour
{
    public float maxhp;
    public int attackPower;
    public float mainSpeed;
    public float jumpPower;
    public float cooldownAttack;
    public float cooldownDash;
    public int exJump;
    public int charID;

    private float speed;

    private float currenthp;

    private float burnTime;
    private bool burning;
    private float burndmgTime;

    private float slowTime;
    private bool slowing;


    public Text hitpointText;
    public Image hitpointImage;
    private GameController gm;

    public AudioSource getHit;

    private void Awake()
    {
        charID = CharacterSelect.player1sel;

        //gm is gameController acces
        gm = GameObject.Find("GameController").GetComponent<GameController>();

        currenthp = maxhp;
        speed = mainSpeed;
        if (charID == 3)
        {
            exJump = 2;
        }
        else
        {
            exJump = 1;
        }
    }
    private void Start()
    {
        burnTime = 0f;
        burning = false;
        burndmgTime = 0f;


        slowTime = 0f;
        slowing = false;
        hitpointText.text = currenthp.ToString();
        hitpointImage.fillAmount = currenthp / maxhp;
    }
    private void Update()
    {
        if (gm.getGameoverTimeOppened())
        {
            return;
        }
        //statics
        if (burning)
        {
            if (burnTime > 0)
            {
                if (burndmgTime > 0)
                {
                    burndmgTime -= Time.deltaTime;
                }
                else if (burndmgTime <= 0)
                {
                    setHP(-2);
                    burndmgTime = 1f;
                }
                burnTime = -Time.deltaTime;
            }
            else if (burnTime <= 0)
            {
                burning = false;
            }
        }
        if (slowing)
        {
            speed = (mainSpeed * 3) / 4;
            if (slowTime > 0)
            {
                slowTime -= Time.deltaTime;
            }
            else if (slowTime <= 0)
            {
                slowing = false;
            }
        }
    }
    public void setHP(float tempHP)
    {
        getHit.Play();
        currenthp += tempHP;
        hitpointText.text = currenthp.ToString();
        hitpointImage.fillAmount = currenthp / maxhp;
        if (currenthp <= 0)
        {
            gm.p1RoundLost();
        }
    }
    public float getHP()
    {
        return this.currenthp;
    }
    public int getID()
    {
        return this.charID;
    }
    public void burnit()
    {
        if (burning)
        {
            return;
        }
        else
        {
            burning = true;
            burnTime = 3.1f;
            burndmgTime = 1f;
        }
    }
    public bool getBurning()
    {
        return this.burning;
    }
    public void slowit()
    {
        if (slowing)
        {
            return;
        }
        else
        {
            slowing = true;
            slowTime = 1.25f;
        }
    }
    public void purify()
    {
        burning = false;
        slowing = false;
    }
    public float getSpeed()
    {
        return this.speed;
    }
}
