using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map : MonoBehaviour {

    public GameObject cube1;
    public GameObject cube2;

    int state = 0;

    int pattern = 0;
    int kind = 0;

    bool next = true;
    
    int down = 0;
    float delta = 1.0f;

    public int mapX;
    public int mapY;

    public int[,,] map = new int[1,19,20];

    public int[,,] AppearBlc = new int[4,4,4];

    void Start () {
	}

    void random()
    {
        if (next)
        {
            kind = UnityEngine.Random.Range(0, 7);
            pattern = UnityEngine.Random.Range(0, 4);
            state = kind;
        }
        
        switch (state)
        {
            case 0:
                int[,,] Iblock = { 
                    { { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 } },
                    { { 0, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 } },
                    { { 0, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }
                };
                Array.Copy(Iblock, AppearBlc, Iblock.Length);
                break;

            case 1:
                int[,,] Oblock = { 
                    { { 0, 1, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 1, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 1, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 1, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }
                };
                Array.Copy(Oblock, AppearBlc, Oblock.Length);
                break;

            case 2:
                int[,,] Tblock = {
                    { { 0, 0, 1, 0 }, { 0, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 }, { 0, 0, 1, 1 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 0, 0 }, { 0, 1, 1, 1 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } }
                };
                Array.Copy(Tblock, AppearBlc, Tblock.Length);
                break;

            case 3:
                int[,,] Lblock = { 
                    { { 0, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 0, 1 }, { 0, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 1 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 0, 0 }, { 0, 1, 1, 1 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 } }
                };
                Array.Copy(Lblock, AppearBlc, Lblock.Length);
                break;

            case 4:
                int[,,] Jblock = {
                    { { 0, 0, 1, 1 },{ 0, 0, 1, 0},{ 0, 0, 1, 0},{ 0, 0, 0, 0 } },
                    { { 0, 0, 0, 0 },{ 0, 1, 1, 1},{ 0, 0, 0, 1},{ 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 },{ 0, 0, 1, 0},{ 0, 1, 1, 0},{ 0, 0, 0, 0 } },
                    { { 0, 1, 0, 1 },{ 0, 1, 1, 1},{ 0, 0, 0, 0},{ 0, 0, 0, 0 } }
                };
                Array.Copy(Jblock, AppearBlc, Jblock.Length);
                break;

            case 5:
                int[,,] Zblock = {
                    { { 0, 1, 1, 0 }, { 0, 0, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 0, 1 }, { 0, 0, 1, 1 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 1, 1, 0 }, { 0, 0, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 0, 1 }, { 0, 0, 1, 1 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } }
                };
                Array.Copy(Zblock, AppearBlc, Zblock.Length);
                break;

            case 6:

                int[,,] Sblock = {
                    { { 0, 0, 1, 1 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 }, { 0, 0, 1, 1 }, { 0, 0, 0, 1 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 1 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 }, { 0, 0, 1, 1 }, { 0, 0, 0, 1 }, { 0, 0, 0, 0 } }
                };
                Array.Copy(Sblock, AppearBlc, Sblock.Length);
                break;
        }
    }

    void Update () {
        if(next)
        {
            random();
            down = 0;
            next = false;
        }

        delta -= Time.deltaTime;
        if(delta <= 0)
        {
            delta = 1.0f;
            Appearance();
        }
    }


    /*void Fall()
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
    }*/

    void Appearance()
    {
        random();

        Debug.Log(kind + "番　" + pattern);

        int x = 0;
        int y = 0;

        for(int i=0; i<16; i++)
        {
            map[0, 15+y-down, 10+x] = AppearBlc[pattern, y, x];

            x++;
            if (x > 3)
            {
                x = 0;
                y++;
            }
        }

        down++;

        MapForm();
    }

    /*void cube2Up()
    {
        int x = 0;
        int y = 0;

        foreach (int i in map)
        {
            if (i == 1 && y > 0 && (map[y - 1, x,0] == 2 || map[y - 1, x,0] == 3))
            {
                map[y, x,0] = 2;
            }

            if (map[y, x,0] == 1 && y > 0)
            {
                map[y - 1, x,0] = map[y, x,0];
                map[y, x,0] = 0;
            }

            x++;
            if (x > mapX - 1)
            {
                x = 0;
                y++;
            }
        }
    }*/

    void MapForm()
    {
        int x = 0;
        int y = 0;

        GameObject[] obj = GameObject.FindGameObjectsWithTag("cube1");
        foreach (GameObject i in obj)
        {
            Destroy(i);
        }

        foreach (int i in map)
        {
            if (map[0, y, x] == 1)
            {
                Instantiate(cube1, new Vector3(x, y, 0), Quaternion.identity);
            }
            /*if(i==2)
            {
                Instantiate(cube2, new Vector3(x, y, 0), Quaternion.identity);
                map[y,x,0] = 3;
            }*/

            x++;
            if (x > mapX - 1)
            {
                x = 0;
                y++;
            }
        }
    }

    public void RotaButton()
    {
        pattern++;

        if (pattern > 3
            /*kind == 1 || 
            ((kind == 0 || kind == 5 || kind == 6) && pattern > 1) ||
            ((kind == 2 || kind == 3 || kind == 4) && pattern > 3)*/)
        {
            pattern = 0;
        }

        Appearance();
    }
    
}
