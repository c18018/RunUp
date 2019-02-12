using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    PlayerCollider playerCol;
    SliderController sliderCtrl;

    Animator roboAni;

    //Player move speed
    public float speed;

    //Player Rigidbody
    private Rigidbody rigid;
    public float forceUp;
    public float jumpWaitTime = 1;

    //Player position
    //private Vector3 playerPos;

    //private bool isTouch = false;
    public static bool isJump;

    Vector3 playermovePos;
    Vector3 distan;

    int distanX;
    int distanY;

    GameObject energyOb;
    public static bool destroyed = false;

    // Use this for initialization
    void Start () {
        rigid = gameObject.GetComponent<Rigidbody>();
        playerCol = GetComponentInChildren<PlayerCollider>();
        sliderCtrl = GameObject.FindGameObjectWithTag("GameCtrl").GetComponent<SliderController>();
        roboAni = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("PlayerMove", 0.1f);
        //Debug.Log(playerCol.isJump());
    }

    void PlayerMove()
    {
        //Animation Walk
        
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (playerCol.isJump())
        {
            //Animation Jump
            Jump();
        }

        if (isJump && playerCol.isHighJump())
        {
            //Animation HighJump
            
            Invoke("ButtonJump", jumpWaitTime);
            //ButtonJump();
        }

        if (FollowCamera.count > 5)
        {
            //playerPos = new Vector3(1, 1, 0);
            SceneManager.LoadScene("ScoreResult_test");
        }
    }

    void Jump()
    {
        roboAni.SetTrigger("Jump");
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
        if (playerCol.isHighJump() && sliderCtrl.sliderValue() > 0)
        {
            isJump = true;
            roboAni.SetTrigger("Transformers1");
        }
    }

    public void OnJBUp()
    {
            isJump = false;
        roboAni.SetTrigger("Transformers3");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Energy")
        {
            energyOb = other.gameObject;
            OnDestroy();
        }
    }

    private void OnDestroy()
    {
        destroyed = true;
        Destroy(energyOb);
    }
}
