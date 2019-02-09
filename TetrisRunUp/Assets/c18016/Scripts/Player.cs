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
    public float jumpWaitTime = 1;

    //Player position
    private Vector3 playerPos;

    //private bool isTouch = false;
    public static bool isJump;

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
        //Animation Walk

        //playerPos = new Vector3(x, y, z) * speed;
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (playerCol.isJump())
        {
            //Animation Jump
            Jump();
        }

        if (isJump && playerCol.isHighJump())
        {
            //Animation HighJump

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
