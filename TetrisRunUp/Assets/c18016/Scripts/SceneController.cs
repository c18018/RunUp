using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickStart()
    {
        SceneManager.LoadScene("Proto_c18016");
    }

    public void OnClickAgain()
    {
        SceneManager.LoadScene("Proto_c18016");
    }

    public void OnClickTitle()
    {
        SceneManager.LoadScene("Title_test");
    }
}
