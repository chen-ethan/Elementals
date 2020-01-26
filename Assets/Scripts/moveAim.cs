using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAim : MonoBehaviour
{
    public bool canAim;
    // Start is called before the first frame update

    private SpriteRenderer reticle;

    //private Rigidbody2D rb;

    public Vector2 aimVec;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        canAim = false;
        reticle = GetComponent<SpriteRenderer>();
        reticle.enabled = false;
        aimVec = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {

        if (canAim) //& far enough from user
        {
            reticle.enabled = true;
            Move(aimVec);
        }
        else
        {
            reticle.enabled = false;
        }
    }

    public void Move(Vector2 val)
    {
        //rb.MovePosition(rb.position + val  * Time.fixedDeltaTime);
        Vector3 tmp = new Vector3(val[0], val[1], 0f) * Time.fixedDeltaTime;
        gameObject.transform.Translate(tmp);
    }

}
