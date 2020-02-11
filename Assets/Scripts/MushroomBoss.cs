using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBoss : MonoBehaviour
{
    //public int Health = 3;

    public SpriteRenderer spriteRenderer;
    public List<Sprite> sprites; 


    private bool leftFire;
    private bool rightFire;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enflame(int hand)
    {
        if (hand == 0)
        {
            if (!leftFire)
            {
                if (rightFire)
                {
                    //both hands
                    spriteRenderer.sprite = sprites[2];
                }
                else
                {
                    //jsut left hand
                    spriteRenderer.sprite = sprites[0];
                }
            }
            leftFire = true;
        }else if (hand ==1 )
        {
            if (!rightFire)
            {
                if (leftFire)
                {
                    //both hands
                    spriteRenderer.sprite = sprites[2];
                }
                else
                {
                    //jsut right  hand
                    spriteRenderer.sprite = sprites[1];
                }
            }
            rightFire = true;
        }
    }


    /*
    void takeDamage()
    {
        Health--;
        if (Health<=0)
        {
            Destroy(gameObject);
        }
    }
    */
}
