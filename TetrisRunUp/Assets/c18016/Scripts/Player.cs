using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    PlayerCollider playerCol;

    //Player move speed
    public float speed;

    //Player Rigidbody
    private Rigidbody rigid;
    public float forceUp;
    public float jumpWaitTime;

    //Player position
    Vector3 playerPos;
    //Vector3 playerJampPos;
    
    /*
    private float x = 0;
    private float y = 0;
    private float z = 0;
    */

    //int countJump = 0;

    //private bool isTouch = false;
    private bool isJump;

    Vector3 playermovePos;
    Vector3 distan;

    int distanX;
    int distanY;

    // Use this for initialization
    void Start () {
        rigid = gameObject.GetComponent<Rigidbody>();
        playerCol = GetComponentInChildren<PlayerCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("PlayerMove", 0.1f);
        //Debug.Log(playerJampPos);
    }

    void PlayerMove()
    {
        //playerPos = new Vector3(x, y, z) * speed;
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (playerCol.isJump())
        {
            Jump();
        }

        if (isJump && playerCol.isHighJump())
        {
            //Jump();
            Invoke("ButtonJump", jumpWaitTime);
            //ButtonJump();
        }

        if (FollowCamera.count > 5)
        {
            playerPos = new Vector3(1, 1, 0);
            SceneManager.LoadScene("ScoreResult_test");
        }
    }

    void Jump()
    {
        transform.Translate(transform.up * Time.deltaTime * speed);
        rigid.AddForce(transform.up * forceUp);
        //rigid.AddForce(transform.right * forceRight);
    }

    void ButtonJump()
    {
        transform.Translate(transform.up * Time.deltaTime * speed);
        rigid.AddForce((transform.up - rigid.velocity) * forceUp * 3);
    }

    public void OnJBDown()
    {
        if (playerCol.isHighJump())
        {
            isJump = true;
        }
    }

    public void OnJBUp()
    {
            isJump = false;
    }
}
