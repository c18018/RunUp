﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public GameObject player;
    public GameObject energy;
    int x;
    int maxX;
    int y;
    int maxY;

    public Text scoreText;

    public static int score;
    public static int highscore;

	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        ScoreCal();
        //Debug.Log(Player.isDestroyed);
        scoreText.text = "" + score;
	}

    int count = 1;
    int energyPps = 0;
    void ScoreCal()
    {
        x = (int)player.transform.position.x;
        y = (int)player.transform.position.y;

        if (x < 1)
        {
            x = 1;
        }else if(x > maxX)
        {
            maxX = x;
        }

        if (y < 1)
        {
            y = 1;
        }else if (y > maxY)
        {
            maxY = y;
        }
        
        score = maxX * maxY;

        energyPps = Random.Range(10, 20);

        if(y > 4 * count)
        {
            count++;
            Instantiate(energy, new Vector3(x + energyPps, y + 4 + 0.5f, 0), Quaternion.Euler(-20,-90,0));
        }

        /*if(FollowCamera.count > 7)
        {
            if(highscore < score)
            PlayerPrefs.SetInt("HighScore", score);
        }*/
    }
}
