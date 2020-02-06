using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

    public GameObject[] playerUI;
    private GameObject[] heartContainers;
    private GameObject[] manaContainers;


    public Sprite Heart;
    public Sprite EmptyHeart;

    public Sprite Mana;
    public Sprite EmptyMana;

    int[] maxHearts = new int[2];
    int[] maxMana = new int[2];
    

    void Start()
    {
        playerUI = new GameObject[2];
        heartContainers = new GameObject[2];
        manaContainers = new GameObject[2];
        playerUI[0] = gameObject.transform.GetChild(0).gameObject;
        playerUI[1] = gameObject.transform.GetChild(1).gameObject;
        heartContainers[0] = playerUI[0].gameObject.transform.GetChild(1).gameObject;
        heartContainers[1] = playerUI[1].gameObject.transform.GetChild(1).gameObject;
        manaContainers[0] = playerUI[0].gameObject.transform.GetChild(2).gameObject;
        manaContainers[1] = playerUI[1].gameObject.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void limitHearts(int player, int amt)
    {
        
        maxHearts[player] = amt;



        for (int i = 0; i < maxHearts[player]; i++)
        {
            heartContainers[player].transform.GetChild(i).gameObject.SetActive(true);
        }

        setHearts(player, amt);
        
    }

    public void limitMana(int player, int amt)
    {

        maxMana[player] = amt;



        for (int i = 0; i < maxMana[player]; i++)
        {
            manaContainers[player].transform.GetChild(i).gameObject.SetActive(true);
        }

        setMana(player, amt);

    }


    public void setHearts(int player, int amt)
    {
        //set players hearts
        for (int i = 0; i < amt; i++)
        {
            heartContainers[player].transform.GetChild(i).gameObject.GetComponent<Image>().sprite = Heart;

        }
        for (int i = amt; i < maxHearts[player]; i++)
        {
            heartContainers[player].transform.GetChild(i).gameObject.GetComponent<Image>().sprite = EmptyHeart;

        }

    }

    public void setMana(int player, int amt)
    {
        //set players mana
        for (int i = 0; i < amt; i++)
        {
            manaContainers[player].transform.GetChild(i).gameObject.GetComponent<Image>().sprite = Mana;

        }
        for (int i = amt; i < maxHearts[player]; i++)
        {
            manaContainers[player].transform.GetChild(i).gameObject.GetComponent<Image>().sprite = EmptyMana;

        }

    }

















    public void updateHearts(int player, int amt)
    {
        //change players hearts by amt .. can be +/-
    }

    public void updateMana(int player, int amt)
    {
        //change players hearts by amt .. can be +/-
    }


}
