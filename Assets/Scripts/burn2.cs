using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burn2 : MonoBehaviour
{

    public GameObject Boss;
    private MushroomBoss Boss_script;
    public int hand;    
    
    // Start is called before the first frame update
    void Start()
    {
        Boss_script = Boss.GetComponent<MushroomBoss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Flame")
        {
            Boss_script.enflame(hand);
        }
        //Debug.Log("burning:" + burning + "\t "+ col.name + col.GetComponent<sword>().swing);

    }
    void OnTriggerStay2D(Collider2D col)
    {
       if (col.tag == "Flame")
        {
            Boss_script.enflame(hand);
        }
        //Debug.Log("burning:" + burning + "\t "+ col.name + col.GetComponent<sword>().swing);

    }
}
