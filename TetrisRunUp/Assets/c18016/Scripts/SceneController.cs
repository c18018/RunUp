﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public Text highscoreText;
    public Text scoreText;
    public Player playercs;

    AudioSource click;
    public AudioClip Decision,scoreSound;
    //bool onClick;

    int score;
    int highscore;
    float timer = 0.0f;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        click = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        IsScene();
	}

    public void OnClickStart()
    {
        click.PlayOneShot(Decision);
        Invoke("MainScene", 0.4f);
    }

    void MainScene()
    {
        Destroy(AudioController.game_ob);
        SceneManager.LoadScene("Main");
    }

    public void OnClickAgain()
    {
        click.PlayOneShot(Decision);
        Invoke("MainScene", 0.4f);
    }

    public void OnClickTitle()
    {
        Debug.Log("title");
        click.PlayOneShot(Decision);
        Invoke("TitleScene", 0.4f);
    }

    void TitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnClickResult()
    {
        click.PlayOneShot(Decision);
        SceneManager.LoadScene("Result");
        //Invoke("ResultScene", 0.4f*Time.deltaTime);
    }
    

    /*public void OnClickJump()
    {
        Debug.Log("Jump!!");
        playercs.Jump();
    }*/


    void IsScene()
    {
        if (SceneManager.GetActiveScene().name == "Result")
        {
            timer += Time.deltaTime;
            if(timer <0.2)
            {
                TimeInterval();
                Debug.Log("hai");
                timer = 1.0f;
            }
            score = Score.score;
            if(PlayerPrefs.GetInt("HighScore") <score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            scoreText.text = "Score : " + score;

            highscore = PlayerPrefs.GetInt("HighScore", score);

            highscoreText.text = "HighScore : " + highscore;
        }
        else
        {
            highscoreText = null;
        }
    }

    void TimeInterval()
    {
        click.PlayOneShot(scoreSound);
    }
}
