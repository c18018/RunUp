using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Block : MonoBehaviour {

    bool next;
    Rigidbody gravity;

    private void Start()
    {
        gravity = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cube2")
        {
            gameObject.tag = "cube2";
            next = true;
        }
    }

    public bool Next()
    {
        return next;
    }
}
