using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health;
    public int Attack;

    public float speed;

    public Transform target;

    private Vector2 movement;
    private Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target){
            Vector3 Direction = target.position - transform.position;
            Direction.Normalize();
            movement = Direction;
        }
    }

    private void FixedUpdate(){
        if(target){
            move(movement);
        }
    } 

    void move(Vector2 dir){
        rb.MovePosition((Vector2) transform.position + (dir * speed * Time.deltaTime));
    }

    public void takeDmg(int amt){
        Health -= amt;
        Debug.Log("HP" + Health);
        if(Health<=0) Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Sword" && collision.gameObject.GetComponent<sword>().swing){
            takeDmg(2);
        }else if(collision.gameObject.name == "FireBall(Clone)"){
            takeDmg(1);
        }
        else{
            Debug.Log(collision.gameObject.name);
        }

    }

    void OnTriggerEnter2D(Collider2D collision){
        if(!target && collision.gameObject.tag == "Player"){
            target = collision.gameObject.transform;
        }
        
    }
}
