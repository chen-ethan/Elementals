using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public bool swing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        //Debug.Log("Sword");
        if(collider.tag == "Flame"){
            tag = "Flame";
            Debug.Log(tag);
        }
    }
}
