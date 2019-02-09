using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {

    Slider slider;
    PlayerCollider playerCollider;

    float timer;

    float jumpEnergy;

	// Use this for initialization
	void Start () {
        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        playerCollider = GameObject.FindGameObjectWithTag("Collider").GetComponent<PlayerCollider>();
        jumpEnergy = slider.maxValue;
	}
	
	// Update is called once per frame
	void Update () {
        if(Player.isJump && playerCollider.isHighJump())
        {
            timer += 1 * Time.deltaTime;
            Debug.Log((int)timer);

            if(timer > 2 && playerCollider.isHighJump())
            {
                jumpEnergy -= 20 * Time.deltaTime;
                if(jumpEnergy < slider.minValue || !playerCollider.isHighJump())
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
            jumpEnergy = slider.maxValue;
            timer = 0;
        }

        slider.value = jumpEnergy;
        
	}

}
