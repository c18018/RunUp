using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map : MonoBehaviour {

    public GameObject cube1;
    public GameObject cube2;

    int state = 0;

    float delta = 6;
    float speed = 1.0f;

    public int mapX;
    public int mapY;

    public int[,] map = new int[19,20];

    public int[,] AppearBlc = new int[4,4];

    void Start () {
        Appearance();
	}

    void random()
    {
        int i;
        i = UnityEngine.Random.Range(0, 7);
        state = i;

        switch (state)
        {
            case 0:
                int[,] Iblock = { { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 } };
                Array.Copy(Iblock, AppearBlc, Iblock.Length);
                break;

            case 1:
                int[,] Oblock = { { 0, 1, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
                Array.Copy(Oblock, AppearBlc, Oblock.Length);
                break;

            case 2:
                int[,] Tblock = { { 0, 0, 1, 0 }, { 0, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
                Array.Copy(Tblock, AppearBlc, Tblock.Length);
                break;

            case 3:
                int[,] Lblock = { { 0, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } };
                Array.Copy(Lblock, AppearBlc, Lblock.Length);
                break;

            case 4:
                int[,] Jblock = {{ 0, 0, 1, 1 },{ 0, 0, 1, 0},{ 0, 0, 1, 0},{ 0, 0, 0, 0 } };
                Array.Copy(Jblock, AppearBlc, Jblock.Length);
                break;

            case 5:
                int[,] Zblock = { { 0, 1, 1, 0 }, { 0, 0, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
                Array.Copy(Zblock, AppearBlc, Zblock.Length);
                break;

            case 6:

                int[,] Sblock = { { 0, 0, 1, 1 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
                Array.Copy(Sblock, AppearBlc, Sblock.Length);
                break;
        }
        Debug.Log(i + "番");
    }

    void Update () {
        delta -= Time.deltaTime;
        if(delta <= 0)
        {
            Appearance();
            delta = 6;
        }

        Fall();
    }


    void Fall()
    {
        speed -= Time.deltaTime;

        if (speed <= 0)
        {
            speed = 1.0f;

            GameObject[] obj = GameObject.FindGameObjectsWithTag("cube1");

            foreach (GameObject i in obj)
            {
                Destroy(i);
            }

            cube2Up();

            MapForm();
        }
    }

    void Appearance()
    {
        random();

            int x = 0;
            int y = 0;

            foreach (int i in AppearBlc)
            {
                map[15+y,10+x] = AppearBlc[y,x];
                x++;
                if (x > 3)
                {
                    x = 0;
                    y++;
                }
            }
    }

    void cube2Up()
    {
        int x = 0;
        int y = 0;

        foreach (int i in map)
        {
            if (i == 1 && y > 0 && (map[y - 1, x] == 2 || map[y - 1, x] == 3))
            {
                map[y, x] = 2;
            }

            if (map[y, x] == 1 && y > 0)
            {
                map[y - 1, x] = map[y, x];
                map[y, x] = 0;
            }

            x++;
            if (x > mapX - 1)
            {
                x = 0;
                y++;
            }
        }
    }

    void MapForm()
    {
        int x = 0;
        int y = 0;

        foreach (int i in map)
        {
            if (map[y,x] == 1)
            {
                Instantiate(cube1, new Vector3(x, y, 0), Quaternion.identity);
            }
            if(i==2)
            {
                Instantiate(cube2, new Vector3(x, y, 0), Quaternion.identity);
                map[y,x] = 3;
            }

            x++;
            if (x > mapX - 1)
            {
                x = 0;
                y++;
            }
        }
    }
    
}
