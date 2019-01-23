using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockIns : MonoBehaviour {

    public GameObject[] block;
    public GameObject insPos;

    int nowBlock;

    int display;

	void Start () {
        nowBlock = Random.Range(0, block.Length);
        InsBlock();
        display = NextBlock();

        Debug.Log(display + " : " + nowBlock);
    }
	
	/*void Update () {
        InsBlock();

        Debug.Log(display + " : " + nowBlock);
	}*/

    int NextBlock()
    {
        int i = Random.Range(0, block.Length);

        return i;
    }

    void InsBlock()
    {
        nowBlock = display;
        Instantiate(block[nowBlock], insPos.transform.position, Quaternion.identity);

        display = NextBlock();
    }
}
