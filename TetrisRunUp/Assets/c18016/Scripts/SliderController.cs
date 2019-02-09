using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {

    public static Slider slider;
    PlayerCollider playerCollider;

    float timer;

    float jumpEnergy;

    public float sliderValue()
    {
        return jumpEnergy;
    }

	// Use this for initialization
	void Start () {
        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        playerCollider = GameObject.FindGameObjectWithTag("Collider").GetComponent<PlayerCollider>();
        jumpEnergy = slider.maxValue;
	}
	
	// Update is called once per frame
	void Update () {
        SliderEnergy();
	}

    void SliderEnergy()
    {
        if (Player.isJump && playerCollider.isHighJump())
        {
            Timer();

            if (timer > 2 && playerCollider.isHighJump() /*&& jumpEnergy > 0*/)
            {
                jumpEnergy -= 20 * Time.deltaTime;

                if (jumpEnergy < slider.minValue && playerCollider.isHighJump())
                {
                    Player.isJump = false;
                    Debug.Log("Empty");
                    //jumpEnergy = slider.maxValue;
                    timer = 0;
                }
            }
        }
        else
        {
            //jumpEnergy = slider.maxValue;
            timer = 0;
        }

        slider.value = jumpEnergy;

        if (Player.destroyed)
        {
            jumpEnergy = slider.maxValue;
            Player.destroyed = false;
        }

    }

    void Timer()
    {
        timer += 1 * Time.deltaTime;
        //Debug.Log((int)timer);
    }
}
