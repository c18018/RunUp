using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour {
    public GameObject[] bgm_ob;
    public static GameObject game_ob;

    //bool onAudio = false;
    
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        IsScene();
    }

    void IsScene()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {

            if(!GameObject.Find("Audio"))
            {
                game_ob = Instantiate(bgm_ob[1], transform.position, Quaternion.identity);

                game_ob.name = "Audio";
            }
        }else if(SceneManager.GetActiveScene().name == "ScoreResult_test" && !GameObject.Find("Audio"))
        {
            game_ob = Instantiate(bgm_ob[0], transform.position, Quaternion.identity);

            game_ob.name = "Audio";
            DontDestroyOnLoad(game_ob);
        }else if(SceneManager.GetActiveScene().name == "Title_test" && !GameObject.Find("Audio"))
        {
            game_ob = Instantiate(bgm_ob[0], transform.position, Quaternion.identity);

            game_ob.name = "Audio";
            
        }
    }
}
