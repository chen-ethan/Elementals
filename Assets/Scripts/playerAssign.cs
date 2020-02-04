using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAssign : MonoBehaviour
{
    // Start is called before the first frame update

    public int numPlayers;


    void Start()
    {
        numPlayers = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPlayerJoined()
    {
        Debug.Log("joined");
        numPlayers++;
    }

    private void OnPlayerLeft()
    {
        Debug.Log("left");
        numPlayers--;

    }
}
