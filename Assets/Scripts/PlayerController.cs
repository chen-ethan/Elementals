using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public int health;
    public int mana;
    public float speed;
    public float aimSpeed;
    public float aimRange;

    private Vector2 moveInput;

    private Vector2 aimInput;

    private GameObject aimChild;



    private Rigidbody2D rb;

    private GameObject PIM; //player input manager

    private int player_num;



    // UI ---------------------------------------------
    private GameObject UI;
    private UImanager UIscript;



   

    private bool aiming;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("p1 start");

        PIM = GameObject.Find("PlayerInputManager");
        UI = GameObject.Find("UI");
        UIscript = UI.GetComponent<UImanager>();
        player_num = PIM.GetComponent<playerAssign>().numPlayers-1;
        characterSetup(player_num);

    }

    void characterSetup(int i)
    {
        //knight = 1; dragon = 2;
        rb = GetComponent<Rigidbody2D>();
        if (i == 0)
        {
            health = 8;
            mana = 5;
            //gameObject = new KnightController;
        }
        else if (i == 1)
        {
            health = 15;
            mana = 12;
            aimChild = gameObject.transform.GetChild(0).gameObject;
            aiming = false;
            //range of dragon
            aimChild.GetComponent<moveAim>().radius = aimRange;
        }

        UIscript.limitHearts(player_num,health);
        UIscript.limitMana(player_num, mana);

    }

    // Update is called once per frame
    void Update()
    {


    }



    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DmgPlayer"))
        {
            health -= 1;
            Debug.Log("Health: " + health);
            UIscript.setHearts(player_num, health);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DmgPlayer"))
        {
            health -= 1;
            Debug.Log("Health: " + health);
            UIscript.setHearts(player_num, health);

        }
    }


    private void OnMove(InputValue value)
    {
        //Debug.Log("moving");
        moveInput = value.Get<Vector2>();
        //Debug.Log("facing: " + moveInput);
        //rb.MovePosition(rb.position + moveInput * Time.fixedDeltaTime);
    }
    /*
    private void OnA(InputValue value)
    {
        if (value.Get<float>() > 0) aiming = true; else aiming = false;
        if (aiming)
        {
            aimChild.GetComponent<moveAim>().canAim = true;
        }
        else
        {
            aimChild.GetComponent<moveAim>().canAim = false;
        }
        
    }
    */

    private void OnLT(InputValue value)
    {
        //Debug.Log(value.Get<float>());
        if (player_num == 0)
        {
            //knight
        }
        else if (player_num == 1)
        {
            //dragon
            aiming = !aiming;

            //Debug.Log("aiming:" + aiming);
            if (aiming)
            {
                aimChild.GetComponent<moveAim>().canAim = true;
            }
            else
            {
                aimChild.GetComponent<moveAim>().canAim = false;
            }
        }
        



    }

    private void OnAim(InputValue value)
    {
        if (player_num == 0)
        {
            //knight
        }
        else if (player_num == 1)
        {
            //dragon
            //Debug.Log(value.Get<Vector2>());
            aimChild.GetComponent<moveAim>().aimVec = value.Get<Vector2>() * aimSpeed;
        }
            /*
        if (aiming)
        {
            aimInput = value.Get<Vector2>() * aimSpeed;
            aimChild.GetComponent<moveAim>().Move(aimInput);
        }
        */
    }

    private void OnFire(InputValue value)
    {

        if (player_num == 0)
        {
            //knight -- slash in current direction.

        }
        else if (player_num == 1)
        {
            //dragon  draw fireball to aim point

        }
            Debug.Log("nothing");


    }
}
