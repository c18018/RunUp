using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockExit : MonoBehaviour {

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
