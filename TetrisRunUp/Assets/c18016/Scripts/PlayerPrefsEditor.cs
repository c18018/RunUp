using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerPrefsEditor : MonoBehaviour {

    [MenuItem("Tools/PlayerPrefs/DeleteAll")]
    static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs Delete!!!");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
