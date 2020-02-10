using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Reflection;

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
    public Rigidbody2D DragonProjectile;

    private GameObject swordChild;
    public float swingspeed;

    private bool swing;
    private bool SwordOnFire;



    private Rigidbody2D rb;

    private GameObject PIM; //player input manager

    private int player_num;



    // UI ---------------------------------------------
    private GameObject UI;
    private UImanager UIscript;


    // Movement

    public string direction; // up down left right

    public Vector3 left, right, up, down;
   



    // Animation  ---------------------------------------------
    Animator animator;
    public RuntimeAnimatorController KnightAnim;
    public RuntimeAnimatorController DragonAnim;
    

    [SerializeField]
    private CapsuleCollider2D dragonHorizCol;

    [SerializeField]
    private CapsuleCollider2D dragonVertCol;

    private Collider2D col;

    private bool aiming;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("p1 start");
        animator = this.GetComponent<Animator>();

        PIM = GameObject.Find("PlayerInputManager");
        UI = GameObject.Find("UI");
        UIscript = UI.GetComponent<UImanager>();
        player_num = PIM.GetComponent<playerAssign>().numPlayers-1;
        characterSetup(player_num);



        direction = "up";

        //sword rotations
        right = new Vector3(0,0,225);
        left = new Vector3(0,0,45);
        up = new Vector3(0,0,315);
        down = new Vector3(0,0,135);

        col = dragonHorizCol;
    }

    void characterSetup(int i)
    {
        //knight = 1; dragon = 2;
        rb = GetComponent<Rigidbody2D>();
        if (i == 0)
        {
            health = 8;
            mana = 5;
            swordChild = gameObject.transform.GetChild(1).gameObject;
            //gameObject.AddComponent<KnightController>();
        }
        else if (i == 1)
        {
            health = 15;
            mana = 12;
            aimChild = gameObject.transform.GetChild(0).gameObject;
            aiming = false;
            swordChild = gameObject.transform.GetChild(1).gameObject;
            swordChild.SetActive(false);
            //range of dragon
            aimChild.GetComponent<moveAim>().radius = aimRange;
            Debug.Log("animator: "+ animator);
            animator.runtimeAnimatorController = DragonAnim as RuntimeAnimatorController;

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

        if (swing) {
            //swordChild.GetComponentInChildren<BoxCollider2D>().enabled = true;
            //Quaternion direc = new Quaternion(0,0,.45f,0);
            Vector3 start = (Vector3)this.GetType().GetField(direction).GetValue(this);

            Vector3 target = start + new Vector3(0, 0, 90);
            target.z = target.z%360;
            swordChild.transform.Rotate(target, (Time.fixedDeltaTime * swingspeed * 45));

            //Debug.Log(swordChild.transform.rotation.eulerAngles.z + " > " + target.z);

            if (swordChild.transform.rotation.eulerAngles.z >= target.z && swordChild.transform.rotation.eulerAngles.z - target.z <=10)
            {
                swing = false;
                //swordChild.GetComponentInChildren<BoxCollider2D>().enabled = false;
                swordChild.transform.rotation = Quaternion.Euler(start);
                SwordOnFire = false;
                swordChild.GetComponentInChildren<sword>().swing = false;
                swordChild.transform.GetChild(0).tag = "Untagged";
                swordChild.transform.GetChild(0).gameObject.SetActive(false);

            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
                //Debug.Log("collision");

        if (collision.gameObject.CompareTag("DmgPlayer"))
        {
            health -= 1;
            //Debug.Log("Health: " + health);
            UIscript.setHearts(player_num, health);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Debug.Log("trigger");
        if (collision.IsTouching(col) && collision.gameObject.CompareTag("DmgPlayer"))
        {
            health -= 1;
            //Debug.Log("Health: " + health);
            UIscript.setHearts(player_num, health);

        }
    }


    private void OnMove(InputValue value)
    {
        //Debug.Log("moving");
        moveInput = value.Get<Vector2>();
        //Debug.Log("facing: " + moveInput);
        
        if(moveInput.x > 0){
            if(Mathf.Abs(moveInput.y) < moveInput.x){
                direction = "right";
            }else if(moveInput.y > 0){
                direction = "up";
            }else direction = "down";
        }else if(moveInput.x < 0){
            if(Mathf.Abs(moveInput.y) < -1*moveInput.x){
                direction = "left";
            }else if(moveInput.y > 0){
                direction = "up";
            }else direction = "down";
        }

        if(player_num == 0){
            if(direction == "left"){
                swordChild.transform.eulerAngles = left;
            }else if(direction == "right"){
                swordChild.transform.eulerAngles = right;
            }else if(direction == "down"){
                swordChild.transform.eulerAngles = down;

            }else if(direction == "up"){
                swordChild.transform.eulerAngles = up;
            }
        }else if(player_num == 1){

            if(direction == "left"){
                animator.SetInteger("Direction", 3);
                dragonHorizCol.enabled = true;
                dragonVertCol.enabled = false;
                col = dragonHorizCol;
            }else if(direction == "right"){
                animator.SetInteger("Direction", 1);
                dragonHorizCol.enabled = true;
                dragonVertCol.enabled = false;
                col = dragonHorizCol;
            }else if(direction == "down"){
                animator.SetInteger("Direction", 2);
                dragonHorizCol.enabled = false;
                dragonVertCol.enabled = true;
                col = dragonVertCol;

            }else if(direction == "up"){
                animator.SetInteger("Direction", 0);
                dragonHorizCol.enabled = false;
                dragonVertCol.enabled = true;
                col = dragonVertCol;
            }
        }

        //Debug.Log(direction);
        
        
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
            if(!swing){
            //knight -- slash in current direction.
                swordChild.transform.GetChild(0).gameObject.SetActive(true);
                swing = true;
                swordChild.GetComponentInChildren<sword>().swing = true;
            }

        }
        else if (player_num == 1)
        {
            //dragon draw fireball to aim point
            if(aiming){
                Rigidbody2D clone;
                Vector2 dir = (aimChild.transform.position - transform.position).normalized;
                var angle = Mathf.Atan2(-1*dir.x,dir.y) * Mathf.Rad2Deg;
                clone = Instantiate(DragonProjectile,this.transform.position,Quaternion.Euler(0,0,angle));
                clone.GetComponent<projectile>().target = aimChild.transform.position;
                clone.GetComponent<projectile>().spawner = this.gameObject;


                mana--;
                UIscript.setMana(player_num, mana);

            }else{//slash or whatever melee

            }
        }

    }
}
