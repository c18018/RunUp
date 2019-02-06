using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    //Player move speed
    public float speed;

    //Player Rigidbody
    private Rigidbody rigid;
    public float forceUp;
    public float forceRight;

    //Player position
    public Vector3 playerPos;

    private float x = 0;
    private float y = 0;
    private float z = 0;

    //public static bool isTouch;
    //public static bool isDestroy;

    Vector3 playermovePos;
    Vector3 distan;

    int distanX;
    int distanY;

    // Use this for initialization
    void Start () {
        rigid = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("PlayerMove", 0.1f);
        //Debug.Log(transform.position);
        //Jump();
    }

    void PlayerMove()
    {
        x = 1.0f;

        playerPos = new Vector3(x, y, z) * speed;
        transform.Translate(playerPos * Time.deltaTime);

        /*if (isTouch == true)
        {
            rigid.AddForce((transform.up + transform.forward) * forceSpeed);
            
        }*/

        if (FollowCamera.count > 5)
        {
            playerPos = new Vector3(1, 1, 0);
            SceneManager.LoadScene("ScoreResult_test");
        }
    }

    public void Jump()
    {
        /*y = 1.0f;

        playerPos = new Vector3(x, y, z) * speed;
        transform.Translate(playerPos * Time.deltaTime);*/

        rigid.AddForce(transform.up * forceUp);
        rigid.AddForce(transform.right * forceRight);
    }


    public void OnClickJump()
    {
        Debug.Log("Jump!!");
        Jump();
    }


}
