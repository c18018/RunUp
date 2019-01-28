using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            Player.isTouch = true;
            //Debug.Log(Player.isTouch);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            if (Player.isDestroy == true)
            {
                Destroy(other.gameObject);
                Player.isTouch = false;
                Player.isDestroy = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player.isTouch = false;
    }

    //DB = DestroyButton
    public void PointerUp()
    {
        Player.isDestroy = false;
    } 

    public void PointerDown()
    {
        Player.isDestroy = true;
    }
}
