using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public GameObject player;

    //player follow
    private Vector3 cameVec;

    //kamera position
    //private Vector3 camePos;

    //player to camera no kyori
    private Vector3 offset;

    //player start position
    private Vector3 playerPos;

    //player ugoita kyori
    private Vector3 playerDistan;

    //player.y camera.y kyori 
    private Vector3 distan;

    float x;
    float y;
    float z;

    int count;

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
        //playerPos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //playerDistan = player.transform.position - playerPos;
        //Debug.Log(offset);
        Debug.Log(count);
	}

    private void LateUpdate()
    {
        //transform.position = player.transform.position - offset;

        x = player.transform.position.x + offset.x;
        y = transform.position.y;
        z = transform.position.z;

        cameVec = new Vector3(x, y, z);
        
        transform.position = cameVec;

        distan.y = cameVec.y - player.transform.position.y; 

        count = (int)distan.y;

        if (count < 1)
        {
            y = transform.position.y + 4;

            cameVec = new Vector3(x, y, z);            
            transform.position = cameVec;

            Debug.Log("up!!");
        }

        
    }
}
