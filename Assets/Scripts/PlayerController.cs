using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float aimSpeed;

    private float moveUD;
    private float moveLR;

    private Vector2 moveInput;

    private Vector2 aimInput;

    private GameObject aimChild;

    private Rigidbody2D rb;


    private bool aiming;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aimChild = gameObject.transform.GetChild(0).gameObject;
        aiming = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //moveUD = Input.GetAxis("Vertical");
        //moveLR = Input.GetAxis("Horizontal");
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveInput = moveInput.normalized * speed;


        aimInput = new Vector2(Input.GetAxis("RightHorizontal"), Input.GetAxis("RightVertical"));
        aimInput = aimInput.normalized * speed;

        //Debug.Log("UP: " + moveUD + "\t RT: " + moveLR);
        //Debug.Log(aimInput);
        //Debug.Log("move" + moveInput);

        //rb.transform.Translate();

        Debug.Log(Input.GetAxis("A Button"));
        
        if (!aiming && Input.GetAxis("A Button")>0)
        {
            aiming = true;
            Debug.Log("aiming");
            aimChild.GetComponent<moveAim>().canAim = true;
        }
        else if(aiming && Input.GetAxis("A Button") == 0)
        {
            aiming = false;
            Debug.Log(" not aiming");

            aimChild.GetComponent<moveAim>().canAim = false;
        }

    */

        
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
        Debug.Log(value.Get<float>());

        aiming = !aiming;

        Debug.Log("aiming:" + aiming);
        if (aiming)
        {
            aimChild.GetComponent<moveAim>().canAim = true;
        }
        else
        {
            aimChild.GetComponent<moveAim>().canAim = false;
        }

        

    }

    private void OnAim(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
        aimChild.GetComponent<moveAim>().aimVec = value.Get<Vector2>() * aimSpeed;
        /*
        if (aiming)
        {
            aimInput = value.Get<Vector2>() * aimSpeed;
            aimChild.GetComponent<moveAim>().Move(aimInput);
        }
        */
    }

}
