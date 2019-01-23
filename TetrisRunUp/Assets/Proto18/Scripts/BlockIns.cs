using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockIns : MonoBehaviour {

    public GameObject[] block;
    public GameObject insPos;

    int nowBlock;

    // 次のブロックを表示
    int display;

    float timeleft;

    public GameObject player;
    private Vector3 offset;

	void Start () {
        nowBlock = Random.Range(0, block.Length);
        InsBlock();
        display = NextBlock();

        Debug.Log(display + " : " + nowBlock);

        offset = insPos.transform.position - player.transform.position;
    }
	
	void Update () {
        Count();
        insPos.transform.position = player.transform.position + offset;
	}

    void Count()
    {
        timeleft++;

        if (timeleft >= 100)
        {
            InsBlock();
            timeleft = 0;

            Debug.Log(display + " : " + nowBlock);
        }
    }

    void InsBlock()
    {
        nowBlock = display;
        Instantiate(block[nowBlock], insPos.transform.position, Quaternion.identity);

        display = NextBlock();
    }

    int NextBlock()
    {
        int i = Random.Range(0, block.Length);

        return i;
    }

}
