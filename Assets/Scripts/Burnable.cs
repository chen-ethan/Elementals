using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burnable : MonoBehaviour
{

    private bool burning;


    // Start is called before the first frame update
    void Start()
    {
        burning = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void burn(){
        burning = true;
        this.GetComponent<SpriteRenderer>().color = new Color(255,0,0);
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.name == "Sword"){
        
            if(col.GetComponent<sword>().swing){
                if(col.tag=="Flame" || burning){
                    Destroy(gameObject);
                }
            }
        }else if(col.tag=="Flame"){
            burn();
        }
        //Debug.Log("burning:" + burning + "\t "+ col.name + col.GetComponent<sword>().swing);
        
    }
    void OnTriggerStay2D(Collider2D col){
        if(col.name == "Sword"){
        
            if(col.GetComponent<sword>().swing){
                if(col.tag=="Flame" || burning){
                    Destroy(gameObject);
                }
            }
        }else if(col.tag=="Flame"){
            burn();
        }
        //Debug.Log("burning:" + burning + "\t "+ col.name + col.GetComponent<sword>().swing);
        
    }
}
