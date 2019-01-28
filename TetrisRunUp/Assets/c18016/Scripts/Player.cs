using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    //Player move speed
    public float speed;

    //Player Rigidbody
    private Rigidbody rigid;

    Vector3 playerPos;
    public float forceSpeed;

    //Player position
    public float x;
    public float y;
    public float z;

    public static bool isTouch;
    public static bool isDestroy;

    // Use this for initialization
    void Start () {
        rigid = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
        Debug.Log(isDestroy);
    }

    void PlayerMove()
    {
        //x = Input.GetAxis("Vertical");
        //z = Input.GetAxis("Vertical");
        z = 1;

        playerPos = new Vector3(x, y, z) * speed;

        transform.Translate(playerPos * Time.deltaTime);

        if (isTouch == true)
        {
            rigid.AddForce(transform.up * forceSpeed);

        }

        if(isDestroy == true)
        {
            
        }
    }
}
