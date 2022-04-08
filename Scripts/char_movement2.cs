using UnityEngine;
using System.Collections;
public class char_movement2 : MonoBehaviour
{
    private KeyCode lefto;
    private KeyCode righto;
    private KeyCode jumpo;
    private KeyCode downo;
    private KeyCode dasho;
    private KeyCode attacko;
    private KeyCode defendo;

    //Animation Control
    public Animator anim;

    //movement speed
    private float speed;
    //jump speed
    private float jumpPower;

    //dash speeds and direction
    private float dashHorizontal;

    private int dashTime;

    private float skidtime;
    private float counterAttack;

    private bool grounded;
    private bool canMove;
    private bool dashMove;
    private bool canDash;
    private bool hitable;
    private bool skidActivated;
    private bool canJump;
    private bool canAttack;
    public bool counterAttackbool;

    //this do it once will referenced in collision stay and enter
    private bool doitonce = true;
    private bool doitonceCounter = true;

    private Collider2D char_collider;
    //This variable will give us the attack point
    public GameObject atackP;
    //This one will give us layer of p1
    public LayerMask p1_layer;

    public bool attackKeyPressed;
    public bool deffendKeyPressed;
    public bool counterEnded;
    public bool iDthreejumpkeyPressed;

    private float exjumptime;

    private float lastcooldownofattack;
    private float lastcooldowndash;
    private char_oop2 p2;

    private GameController gm;

    public AudioSource jump;


    // Start is called before the first frame update
    void Start()
    {
        //control for p2:        
        lefto = KeyCode.LeftArrow;
        righto = KeyCode.RightArrow;
        jumpo = KeyCode.UpArrow;
        downo = KeyCode.DownArrow;
        dasho = KeyCode.RightShift;
        attacko = KeyCode.RightControl;
        defendo = KeyCode.Period;
        

        //p1 referenced to p1 object's char_oop
        p2 = gameObject.GetComponent<char_oop2>();

        //controlls will take menu's controlls settings but default will be a.
        /*lefto = KeyCode.A;
        righto = KeyCode.D;
        jumpo = KeyCode.W;
        downo = KeyCode.S;
        dasho = KeyCode.LeftShift;
        attacko = KeyCode.LeftControl;
        defendo = KeyCode.Z;
        */
        //doublejump will take how much char can jump

        //grounded will check if char is grounded.
        grounded = true;

        char_collider = gameObject.GetComponent<Collider2D>();

        //canMove will check if char is in dashing or attacking+"
        canMove = true;

        //canAttack will control skid and defend
        canAttack = true;

        //dashMove check if dash is triggered or not;
        dashMove = false;

        //canJump just controls skidtime nd defend
        canJump = true;

        //canDash check dash once
        canDash = true;

        //hitable checks if char in defend mode or dash mode
        hitable = true;

        //lastcooldownattack will show how much time last before attack lastcooldowndefend goes for defend
        lastcooldownofattack = 0;

        //lastcooldowndash will show how much time last before dash
        lastcooldowndash = 0;

        //skid time is skid after attack
        skidtime = 0;

        //jump power, dash horiznotal and speed will referenced from char oop
        speed = p2.getSpeed();
        jumpPower = p2.jumpPower;
        exjumptime = p2.exJump;

        //gm is gameController acces
        gm = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.getGameoverTimeOppened())
        {
            return;
        }
        if (skidActivated)
        {
            if (skidtime > 0)
            {
                skidtime -= Time.deltaTime;
                canMove = false;
                canDash = false;
                canJump = false;
                canAttack = false;
            }
            else
            {
                canJump = true;
                canMove = true;
                canDash = true;
                canAttack = true;
                skidActivated = false;
            }
        }
        //Controlls
        if (Input.GetKey(lefto))
        {
            Move(-1, speed); //-1 is 'to left'
        }
        if (Input.GetKey(righto))
        {
            Move(1, speed); //1 is 'to right'
        }
        if (Input.GetKeyDown(jumpo))
        {
            Jump();
        }
        if (Input.GetKeyDown(downo))
        {
            Down();
        }
        if (Input.GetKeyDown(dasho))
        {
            Dash();
        }
        if (Input.GetKeyDown(attacko))
        {
            Attack();
        }
        if (Input.GetKey(defendo))
        {
            DefendStart();
        }
        if (Input.GetKeyUp(defendo))
        {
            DefendEnd();
        }
        if (lastcooldownofattack > 0)
        {
            lastcooldownofattack -= Time.deltaTime;
        }
        if (lastcooldowndash > 0)
        {
            lastcooldowndash -= Time.deltaTime;
        }
        //Animation Checks
        if (gameObject.GetComponent<Rigidbody2D>().velocity.x == 0)
        {
            anim.SetBool("isWalk", false);
        }
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            anim.SetBool("isJumpRise", false);
            anim.SetBool("isJumpDescend", true);
        }
        else if (gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            anim.SetBool("isJumpDescend", false);
        }
    }
    private void FixedUpdate()
    {
        if (gm.getGameoverTimeOppened())
        {
            return;
        }
        if (dashMove)
        {
            gameObject.transform.Translate(new Vector2(dashHorizontal, 0));
            dashTime += 1;
            hitable = false;
            if (p2.charID == 2)
            {
                GameObject.Find("ID2DashEffectSpawner").GetComponent<BurningEffect>().spawnfireObject(gameObject.transform, "p1");
            }
            if (dashTime == 5)
            {
                hitable = true;
                dashMove = false;
                canMove = true;
                canDash = true;
                anim.SetBool("isDash", false);
            }
        }
        if (counterAttack > 0)
        {
            counterAttack -= Time.fixedDeltaTime;
            counterAttackbool = true;
        }
        else if (counterAttack <= 0)
        {
            counterAttackbool = false;
        }
    }

    private void Move(int direction, float speed)
    {
        if (canMove)
        {
            anim.SetBool("isWalk", true);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed / 2 * direction, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            gameObject.transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    private void Jump()
    {
        if (canJump)
        {
            if (grounded)
            {
                jump.Play();
                anim.SetBool("isJumpRise", true);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, jumpPower);
            }
            else if (exjumptime > 0)
            {
                jump.Play();
                anim.SetBool("isJumpRise", true);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, jumpPower);
                exjumptime -= 1;
                if (exjumptime == 0 && p2.charID == 3)
                {
                    iDthreejumpkeyPressed = true;
                }
            }
        }
    }

    private void Down()
    {
        if (grounded)
        {
            char_collider.isTrigger = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * 2f;
        }
    }

    private void Dash()
    {
        //while dashing char will be un attackable
        if (lastcooldowndash <= 0)
        {
            if (canDash)
            {
                if (Input.GetKey(lefto))
                {
                    dashHorizontal = -0.5f;
                }
                else if (Input.GetKey(righto))
                {
                    dashHorizontal = +0.5f;
                }
                anim.SetBool("isDash", true);
                dashTime = 0;
                dashMove = true;
                canMove = false;
                lastcooldowndash = p2.cooldownDash;
            }
        }
    }
    private void Attack()
    {
        if (canAttack)
        {
            if (lastcooldownofattack <= 0)//then he can attack
            {
                lastcooldownofattack = p2.cooldownAttack;
                attackKeyPressed = true;

                Transform attP = atackP.transform;
                Collider2D p1finder = Physics2D.OverlapBox(attP.position, attP.localScale, 0, p1_layer);
                switch (p2.getID())
                {
                    case 1:
                        startSkid(0.16f);
                        break;
                    case 2:
                        startSkid(0.2f);
                        break;
                    case 3:
                        startSkid(0.16f);
                        break;
                    default:
                        break;
                }
                if (p1finder == null)
                {
                    return;
                }

                float direction = p1finder.transform.position.x - gameObject.transform.position.x;
                //********************************************************************************
                if (direction < 0)                                                             //*
                {                                                                              //*
                    direction = -1;                                                            //*
                }                                                                              //*
                else if (direction > 0)                                                        //*
                {                                                                              //*
                    direction = 1;                                                             //*
                }                                                                              //*
                else                                                                           //*
                {                                                                              //*
                    direction = 0;                                                             //*
                }                                                                              //*
                //********************************************************************************

                if (p1finder.GetComponent<char_movement>().getHittable())
                {
                    switch (p2.charID)
                    {
                        case 1:
                            p1finder.GetComponent<char_movement>().startSkid(0.6f);
                            p1finder.GetComponent<Rigidbody2D>().AddForce(new Vector2(20 * direction, 10), ForceMode2D.Impulse);
                            p1finder.GetComponent<char_oop>().slowit();
                            p1finder.GetComponent<char_oop>().setHP(-15);
                            break;
                        case 2:
                            p1finder.GetComponent<char_movement>().startSkid(0.6f);
                            p1finder.GetComponent<Rigidbody2D>().AddForce(new Vector2(20 * direction, 10), ForceMode2D.Impulse);
                            p1finder.GetComponent<char_oop>().burnit();
                            p1finder.GetComponent<char_oop>().setHP(-10);
                            break;
                        case 3:
                            p1finder.GetComponent<char_movement>().startSkid(0.6f);
                            p1finder.GetComponent<Rigidbody2D>().AddForce(new Vector2(25 * direction, 15), ForceMode2D.Impulse);
                            p1finder.GetComponent<char_oop>().setHP(-15);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (p1finder.GetComponent<char_movement>().counterAttackbool)
                    {
                        startSkid(0.8f);
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5 * direction, 2.5f), ForceMode2D.Impulse);
                        GameObject.FindGameObjectWithTag("spawnercounter").GetComponent<SpawnerCountered>().spawncounter(gameObject.transform);
                        p2.setHP(-1);
                    }
                    else
                    {
                        startSkid(0.2f);
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5 * direction, 2.5f), ForceMode2D.Impulse);
                        GameObject.FindGameObjectWithTag("spawnerblock").GetComponent<BlockDonePopUpScript>().spawnTemp(p1finder.transform);
                    }
                }
            }

        }
    }
    private void DefendStart()
    {
        if (p2.charID == 1)
        {
            if (doitonceCounter)
            {
                counterAttack = 0.5f;
                doitonceCounter = false;
            }
        }
        deffendKeyPressed = true;
        hitable = false;
        canMove = false;
        canJump = false;
        canAttack = false;
    }
    private void DefendEnd()
    {
        doitonceCounter = true;
        deffendKeyPressed = false;
        hitable = true;
        canMove = true;
        canJump = true;
        canAttack = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "p1")
        {
            if (dashMove)
            {
                if (p2.charID == 3)
                {
                    collision.gameObject.GetComponent<char_movement>().startSkid(0.5f);
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 60), ForceMode2D.Impulse);
                }
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "p1")
        {
            if (doitonce)
            {
                if (dashMove)
                {
                    if (p2.charID == 3)
                    {
                        collision.gameObject.GetComponent<char_movement>().startSkid(0.5f);
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 60), ForceMode2D.Impulse);
                        doitonce = false;
                    }
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "p1")
        {
            doitonce = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(atackP.transform.position, atackP.transform.localScale);
    }
    public void startSkid(float duration)
    {
        skidtime = duration;
        skidActivated = true;
    }

    //tihs function will give the hitable to other player.
    public bool getHittable()
    {
        return this.hitable;
    } 
    
    //this function will set the grounded paramater
    public void setGround(bool temp)
    {
        grounded = temp;
        if (grounded)
        {
            exjumptime = p2.exJump;
            canDash = true;
        }
    }

}