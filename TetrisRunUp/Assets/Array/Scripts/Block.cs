using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Block : MonoBehaviour {
    

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cube2")
        {
            gameObject.tag = "cube2";
        }
    }*/

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "cube2")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
        }
    }
}
