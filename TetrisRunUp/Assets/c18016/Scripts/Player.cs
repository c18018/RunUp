using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    //Player move speed
    public float speed;

    //Player Rigidbody
    private Rigidbody rigid;
    public float forceSpeed;

    //Player position
    private Vector3 playerPos;

    private float x = 0;
    private float y = 0;
    private float z = 0;

    public static bool isTouch;
    public static bool isDestroy;

    // Use this for initialization
    void Start () {
        rigid = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
        //Debug.Log(isTouch);
    }

    void PlayerMove()
    {
        //x = Input.GetAxis("Vertical");
        //z = Input.GetAxis("Vertical");
        x = 1.0f;

        playerPos = new Vector3(x, y, z) * speed;
        transform.Translate(playerPos * Time.deltaTime);

        if (isTouch == true)
        {
            rigid.AddForce(transform.up * forceSpeed);
        }
    }
}
