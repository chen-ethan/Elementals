using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{

    private Camera cam;
    public CameraHelper2D cameraHelper;
    public float moveSpeed = 0.1f;

    Vector3 randomPos = Vector3.zero;
    float randomTimer = 0f;


    public GameObject PIM; 

    public Transform[] targets;
    

    public Vector3 offset;
    bool ready;


    public float smoothTime = .5f;
    private Vector3 velocity;

    public float minZoom;
    public float maxZoom;

    void Start(){
         targets = new Transform[2];
         cam = GetComponent<Camera>();

    }
    void Update(){
        if(!ready &&PIM.GetComponent<playerAssign>().numPlayers==2){
            ready = true;
            Debug.Log("ready!");
            var GOs = GameObject.FindGameObjectsWithTag("Player");
            
            targets[0] = GOs[0].transform;
            targets[1] = GOs[1].transform;
        }

        if(ready){
            Vector3 centerPoint = getCenterPoint();
            centerPoint += offset;
            transform.position = Vector3.SmoothDamp(transform.position,centerPoint, ref velocity, smoothTime);
            zoom();
        
        }
/*
        randomTimer -= Time.deltaTime;

        if(randomTimer<=0f){
            randomTimer = 2f;
            randomPos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f,5f), transform.position.z);

        }
        Vector3 moveDir = (randomPos - cameraHelper.cameraPos).normalized;
        cameraHelper.Move(moveDir * moveSpeed * Time.deltaTime);
*/
    }

    void zoom(){
        float dist = Vector2.Distance(targets[0].position, targets[1].position);
        float newZoom = Mathf.Lerp(minZoom, maxZoom, dist/ 15);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);

    }
  
    Vector3 getCenterPoint(){
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        int sz = targets.Length;
        for(int i = 0; i < sz; ++i){
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

}
