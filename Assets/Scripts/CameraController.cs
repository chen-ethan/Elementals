using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CameraHelper2D cameraHelper;
    public float moveSpeed = 0.1f;

    Vector3 randomPos = Vector3.zero;
    float randomTimer = 0f;


    void Update(){
        randomTimer -= Time.deltaTime;

        if(randomTimer<=0f){
            randomTimer = 2f;
            randomPos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f,5f), transform.position.z);

        }
        Vector3 moveDir = (randomPos - cameraHelper.cameraPos).normalized;
        cameraHelper.Move(moveDir * moveSpeed * Time.deltaTime);

    }
}
