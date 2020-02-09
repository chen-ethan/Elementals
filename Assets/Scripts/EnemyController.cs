using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health;
    public int Attack;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if(collision.gameObject.name == "Sword"){
            takeDmg(2);
        }else if(collision.gameObject.name == "FireBall(Clone)"){
            takeDmg(1);
        }
        else{
            Debug.Log(collision.gameObject.name);
        }
    }
}
