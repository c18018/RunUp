using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    PlayerCollider playerCol;
    SliderController sliderCtrl;

    Animator roboAni;
    AudioSource jumpSE;
    public AudioClip jump, highjump;

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
    bool jumpAni = true;

    Vector3 playermovePos;
    Vector3 distan;

    int distanX;
    int distanY;

    GameObject energyOb;
    public static bool destroyed = false;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        rigid = gameObject.GetComponent<Rigidbody>();
        playerCol = GetComponentInChildren<PlayerCollider>();
        sliderCtrl = GameObject.FindGameObjectWithTag("GameCtrl").GetComponent<SliderController>();
        jumpSE = GameObject.FindGameObjectWithTag("GameCtrl").GetComponent<AudioSource>();
        roboAni = GetComponent<Animator>();
	}
    

    RaycastHit hit;
	// Update is called once per frame
	void FixedUpdate() {
            Invoke("PlayerMove", 0.1f);

        if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity))
        {
            Destroy(hit.collider.gameObject);
        }
        //Debug.Log(playerCol.isJump());
    }

    void PlayerMove()
    {
        //Animation Walk
        
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (playerCol.isJump())
        {
            Jump();
        }
        else
        {
            jumpAni = true;
        }

        if (isJump)
        {
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
        jumpSE.PlayOneShot(jump);
        if (jumpAni)
        {
            roboAni.SetTrigger("Jump");
            jumpAni = false;
        }
       
        transform.Translate(transform.up * Time.deltaTime * speed);
        rigid.AddForce(transform.up * forceUp);
    }

    void ButtonJump()
    {
        jumpSE.PlayOneShot(highjump);
        transform.Translate(transform.up * Time.deltaTime * speed);
        rigid.AddForce((transform.up - rigid.velocity) * forceUp * 3);
    }

    public void OnJBDown()
    {
        if (sliderCtrl.sliderValue() > 0)
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


    public GameObject pausePanel;

    public void PauseButton()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
    
}
