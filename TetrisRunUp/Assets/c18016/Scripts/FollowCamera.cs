using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public GameObject player;

    //camera position
    private Vector3 camePos;

    float x;
    float y;
    float z;

    //player camera distance
    private Vector3 offset;
    //player camera move distance 
    private Vector3 distan;

    //determine camera height
    int count;

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(count);
	}

    private void LateUpdate()
    {
        x = player.transform.position.x + offset.x;
        y = transform.position.y;
        z = transform.position.z;

        camePos = new Vector3(x, y, z);
        transform.position = camePos;

        distan.y = camePos.y - player.transform.position.y;
        count = (int)distan.y;

        if (count < 1)
        {
            y = transform.position.y + 4;

            camePos = new Vector3(x, y, z);            
            transform.position = camePos;

            Debug.Log("up!!");
        }

        
    }
}
