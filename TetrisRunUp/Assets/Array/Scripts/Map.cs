using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map : MonoBehaviour {
    
    int speedX = 0;

    public GameObject cube1;

    int state = 0;

    int pattern = 0;
    int kind = 0;

    bool normal = true;
    bool next = true;
    bool rankUp = false;
    
    int down = 0;
    float delta = 1.0f;

    public int mapX;
    public int mapY;

    public int[,,] map = new int[1,19,30];

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
                    { { 1, 1, 1, 1 }, { 0, 0, 0, 0 },  { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 } },
                    { { 1, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }
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
                    { { 0, 1, 1, 1 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } }
                };
                Array.Copy(Tblock, AppearBlc, Tblock.Length);
                break;

            case 3:
                int[,,] Lblock = { 
                    { { 0, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 0, 1 }, { 0, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 1 }, { 0, 0, 0, 0 } },
                    { { 0, 1, 1, 1 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }
                };
                Array.Copy(Lblock, AppearBlc, Lblock.Length);
                break;

            case 4:
                int[,,] Jblock = {
                    { { 0, 0, 1, 1 },{ 0, 0, 1, 0},{ 0, 0, 1, 0},{ 0, 0, 0, 0 } },
                    { { 0, 1, 1, 1},{ 0, 0, 0, 1},{ 0, 0, 0, 0 },{ 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 },{ 0, 0, 1, 0},{ 0, 1, 1, 0},{ 0, 0, 0, 0 } },
                    { { 0, 1, 0, 0 },{ 0, 1, 1, 1},{ 0, 0, 0, 0},{ 0, 0, 0, 0 } }
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

        if (cube1.GetComponent<Block>().Next())
        {
            down = 0;
            next = true;
            Debug.Log("ok");
        }

        if (next)
        {
            random();
            next = false;
        }


        if (normal) {
            delta -= Time.deltaTime;
        }
        
        if(delta <= 0)
        {
            delta = 1.0f;

            Appearance();
        }
        
    }

    void Appearance()
    {
            Read();

            down++;

            MapForm();
    }

    void Read()
    {
        random();


        if (down > 14)
        {
            Debug.Log(down);
            down = 0;
            //rankUp = true;
            //cubeUp();
            next = true;
        }

       
        int x = 0;
        int y = 0;

        for (int i = 0; i < 16; i++)
        {
            map[0, 15 + y - down , 10 + x + speedX] = AppearBlc[pattern, y, x];

            x++;
            if (x > 3)
            {
                x = 0;
                y++;
            }

        }
    }

    void cubeUp()
    {
        int x = 0;
        int y = 0;
        int count = 0;

        foreach (int i in map)
        {
            if (i == 1 && y > 0 && (map[0, y - 1, x] == 2 || map[0, y - 1, x] == 3))
            {
                rankUp = true;
            }

            if(i == 1 && map[0, y, x] == 0 && count < 20)
            {
                count++;
                rankUp =  true;
            }
            
            x++;
            if (x > mapX - 1)
            {
                x = 0;
                y++;
            }
        }

        if (rankUp)
        {
            int xBlc = 0;
            int yBlc = 0;
            foreach(int i in AppearBlc)
            {
                if(i == 1)
                {
                    AppearBlc[pattern, yBlc, xBlc] = 2;
                }

                xBlc++;
                if(xBlc > 3)
                {
                    xBlc = 0;
                    yBlc++;
                }
            }
            rankUp = false;
        }
    }

    void MapForm()
    {
        int x = 0;
        int y = 0;

       GameObject[] obj = GameObject.FindGameObjectsWithTag("cube1");
        foreach (GameObject i in obj)
        {
            Destroy(i);
        }

        int k = 0;
        foreach (int i in map)
        {
            if (map[0, y, x] == 1)
            {
                Instantiate(cube1, new Vector3(x, y, 0), Quaternion.identity);
                map[0, y, x] = 0;
            }

            x++;
            k++;
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

        if (pattern > 3)
        {
            pattern = 0;
        }

        Read();
        MapForm();
    }

    public void RightButton()
    {
        speedX++;
        Read();
        MapForm();
    }

    public void LeftButton()
    {
        speedX--;
        Read();
        MapForm();
    }

    public void DownButton()
    {
        down++;
        Read();
        MapForm();
    }
    
}
