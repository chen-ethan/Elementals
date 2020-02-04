using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAim : MonoBehaviour
{
    public bool canAim;

    public float radius;
    // Start is called before the first frame update

    private SpriteRenderer reticle;

    GameObject parent;

    //private Rigidbody2D rb;

    public Vector2 aimVec;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        parent = gameObject.transform.parent.gameObject;
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

        float distance = Vector2.Distance(gameObject.transform.position, parent.transform.position);

        Debug.Log("distance: " + distance + "\t radius: "+ radius);

        if (distance>radius)
        {
            Vector3 distV = gameObject.transform.position - parent.transform.position;
            distV *= radius / distance;
            gameObject.transform.position = parent.transform.position + distV;
            Debug.Log("new pos " + gameObject.transform.position);
        }
        else
        {
            Debug.Log("pos " + gameObject.transform.position);
        }
    }

}
