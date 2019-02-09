using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockExit : MonoBehaviour {

    //画面の外にブロックが出たら消す
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
