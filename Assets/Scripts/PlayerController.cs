using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float aimSpeed;
    public float aimRange;

    private float moveUD;
    private float moveLR;

    private Vector2 moveInput;

    private Vector2 aimInput;

    private GameObject aimChild;



    private Rigidbody2D rb;

    private GameObject PIM;

    private int player_num;


    


    private bool aiming;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("p1 start");

        PIM = GameObject.Find("PlayerInputManager");
        player_num = PIM.GetComponent<playerAssign>().numPlayers;
        characterSetup(player_num);

    }

    void characterSetup(int i)
    {
        //knight = 1; dragon = 2;
        rb = GetComponent<Rigidbody2D>();
        if (i == 1)
        {
            //gameObject = new KnightController;
        }
        else if (i == 2)
        {
            aimChild = gameObject.transform.GetChild(0).gameObject;
            aiming = false;
            //range of dragon
            aimChild.GetComponent<moveAim>().radius = aimRange;
        }

    }

    // Update is called once per frame
    void Update()
    {


    }



    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }


    private void OnMove(InputValue value)
    {
        //Debug.Log("moving");
        moveInput = value.Get<Vector2>();
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
        if (player_num == 1)
        {
            //knight
        }
        else if (player_num == 2)
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
        if (player_num == 1)
        {
            //knight
        }
        else if (player_num == 2)
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

        if (player_num == 1)
        {
            //knight -- slash in current direction.

        }
        else if (player_num == 2)
        {
            //dragon  draw fireball to aim point

        }
            Debug.Log("nothing");


    }
}
