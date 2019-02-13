using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public Text highscoreText;
    public Text scoreText;
    public Player playercs;

    int score;
    int highscore;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        IsScene();
	}

    public void OnClickStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClickAgain()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClickTitle()
    {
        SceneManager.LoadScene("Title_test");
    }

    /*public void OnClickJump()
    {
        Debug.Log("Jump!!");
        playercs.Jump();
    }*/


    void IsScene()
    {
        if (SceneManager.GetActiveScene().name == "ScoreResult_test")
        {
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
}
