using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    PlayerCollider playerCol;
    SliderController sliderCtrl;

    Animator roboAni;
    AudioSource jumpSE;
    public AudioClip jump, highjump,decision,fallOcean;

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
    bool jumpAni = false;
    bool isSound = false;

    Vector3 playermovePos;
    Vector3 distan;

    int distanX;
    int distanY;

    GameObject energyOb;
    public static bool destroyed = false;

    float timer = 0.0f;
    float interval = 0.5f;

    float timer2 = 1.0f;
    float interval2 = 1.0f;

    // Use this for initialization
    void Start () {
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
        //Debug.Log(timer);
        Debug.Log(isSound);
    }

    void PlayerMove()
    {
        //Animation Walk
        
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        timer += Time.deltaTime;
        if (timer > interval)
        {
            TimeInterval();
            timer = 0;
        }

        if (playerCol.isJump())
        {
            jumpAni = true;
            Jump();
        }

        if (isJump)
        {
            Invoke("ButtonJump", jumpWaitTime);
        }

        if (FollowCamera.count > 5)
        {
            isSound = true;
            timer2 += Time.deltaTime;
            if (timer2 > interval2)
            {
                TimeInterval2();
                timer2 = 0;
            }
            
            //playerPos = new Vector3(1, 1, 0);
            
            Invoke("ResultScene", 1.0f);
        }
    }

    void TimeInterval2()
    {
        if (isSound)
        {
            jumpSE.PlayOneShot(fallOcean);
            isSound = false;
        }
    }

    void ResultScene()
    {
        SceneManager.LoadScene("Result");
    }

    void Jump()
    {
        
        /*if (jumpAni)
        {
            roboAni.SetTrigger("Jump");
            jumpAni = false;
            jumpSE.PlayOneShot(jump);
        }*/
       
        transform.Translate(transform.up * Time.deltaTime * speed);
        rigid.AddForce(transform.up * forceUp);
    }

    void ButtonJump()
    {
        transform.Translate(transform.up * Time.deltaTime * speed);
        rigid.AddForce((transform.up - rigid.velocity) * forceUp * 3);
    }

    void TimeInterval()
    {
        if (jumpAni)
        {
            roboAni.SetTrigger("Jump");
            jumpSE.PlayOneShot(jump);
            jumpAni = false;
        }
    }

    public void OnJBDown()
    {
        if (sliderCtrl.sliderValue() > 0)
        {
            isJump = true;
            jumpSE.PlayOneShot(highjump);
            roboAni.SetTrigger("Transformers1");
        }
    }

    public void OnJBUp()
    {
        jumpSE.Stop();
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
            jumpSE.PlayOneShot(decision);
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else
        {
            jumpSE.PlayOneShot(decision);
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
    
}
