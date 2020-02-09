using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;

    public GameObject spawner;
    public Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position+=transform.up * Time.fixedDeltaTime * speed;
        //Debug.Log(Vector2.Distance(transform.position, target));
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D col){
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject != spawner){
            Destroy(gameObject);

        }
    }

}
