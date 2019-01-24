using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public GameObject cube;

    public int[,] map = new int[,] {
        {0,0,0,0},
        {0,1,1,0},
        {0,0,0,0},
        {0,0,0,0}
    };

    int[,] copy = {
        {0,0,0,0},
        {0,0,0,0},
        {0,0,0,0},
        {0,0,0,0}
    };

void Start () {
        MapForm();
	}

	void Update () {
        //Fall();
	}

    void MapForm()
    {
        int x = -1;
        int y = 0;

        foreach (int i in map)
        {
            x ++;

            if(x > 3)
            {
                x = 0;
                y++;
            }

            if (map[y,x] == 1)
            {
                Instantiate(cube, new Vector3(x, y, 0), Quaternion.identity);
            }

            copy[y, x] = map[y, x];

            Debug.Log(i + "  " + copy[y,x]);
        }
    }

    void Fall()
    {
        float delta = 0.0f;

        int x = -1;
        int y = 0;

        delta -= Time.deltaTime;
        if (delta <= 0)
        {
            delta = 1.0f;

            foreach(int i in map)
            {
                x++;

                if (x > 3)
                {
                    x = 0;
                    y++;
                }

                if (y == 0)
                {
                    map[y,x] = 0;
                }

                int z = y - 1;

                map[y, x] = copy[z,x];
            }

            MapForm();
        }
    }
}
