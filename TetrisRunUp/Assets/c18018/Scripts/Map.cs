﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour {
    
    int speedX = 0;

    AudioSource blokMove;

    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube0;

    public Sprite[] nextBlock = new Sprite[28];
    public Image[] nextImage = new Image[2];
    int kind1;
    int kind2;
    int pattern1;
    int pattern2;
    int numSp;
    
    public GameObject cameraPos;

    int state = 0;

    int pattern = 0;
    int kind = 0;
    
    bool rankUp = false;
    
    bool next = true;
    
    int down = 0;
    float delta = 0.5f;

    public int mapX;
    public int mapY;

    //　シーン上に高さ２１幅２５の配列を作る
    public int[,,] map = new int[1,21,25];

    public int[,,] AppearBlc = new int[4,4,4];
    

    private void Start()
    {
        for (int i = 0; i < mapX; i++)
        {
            map[0, 0, i] = 3;
            map[0, 1, i] = 2;
        }
        MapForm();

        NextBlock();
        nextImage[0].sprite = nextBlock[numSp];
        kind1 = kind2;
        pattern1 = pattern2;
        NextBlock();
        
        blokMove = GetComponent<AudioSource>();
    }


    // 生成されるブロックの種類
    void random()
    {
        switch (state)
        {
            case 0:
                int[,,] Iblock = { 
                    { { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 } },
                    { { 1, 1, 1, 1 }, { 0, 0, 0, 0 },  { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 } },
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
                    { { 0, 1, 0, 0}, { 0, 1, 1, 0}, { 0, 1, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 1, 1, 1 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } }
                };
                Array.Copy(Tblock, AppearBlc, Tblock.Length);
                break;

            case 3:
                int[,,] Jblock = { 
                    { { 0, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 1, 1, 1 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 1 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 0, 1 }, { 0, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }
                    
                };
                Array.Copy(Jblock, AppearBlc, Jblock.Length);
                break;

            case 4:
                int[,,] Lblock = {
                    { { 0, 1, 1, 0 },{ 0, 1, 0, 0},{ 0, 1, 0, 0},{ 0, 0, 0, 0 } },
                    { { 0, 1, 0, 0 },{ 0, 1, 1, 1},{ 0, 0, 0, 0},{ 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 },{ 0, 0, 1, 0},{ 0, 1, 1, 0},{ 0, 0, 0, 0 } },
                    { { 0, 1, 1, 1},{ 0, 0, 0, 1},{ 0, 0, 0, 0 },{ 0, 0, 0, 0 } }
                };
                Array.Copy(Lblock, AppearBlc, Lblock.Length);
                break;

            case 5:
                int[,,] Sblock = {
                    { { 0, 1, 1, 0 }, { 0, 0, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 }, { 0, 1, 1, 0 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 1, 1, 0 }, { 0, 0, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 0 }, { 0, 1, 1, 0 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 } }
                };
                Array.Copy(Sblock, AppearBlc, Sblock.Length);
                break;

            case 6:

                int[,,] Zblock = {
                    { { 0, 0, 1, 1 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 1, 0, 0 }, { 0, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 0, 1, 1 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                    { { 0, 1, 0, 0 }, { 0, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } }
                };
                Array.Copy(Zblock, AppearBlc, Zblock.Length);
                break;
        }
    }


    // ブロックをランダムに選ぶ、次のブロックイメージをだす
    void NextBlock()
    {
        kind2 = UnityEngine.Random.Range(0, 7);
        pattern2 = UnityEngine.Random.Range(0, 4);

        numSp = 4 * kind2 + pattern2;

        nextImage[1].sprite = nextBlock[numSp];
    }

    
    bool auto = true;
    int offset = 0;
    public GameObject player;
    int playerPosX = 0;
    int count = 2;

    void Update ()
    {
        //　プレイヤーX　小数点以下を切り捨てる
        playerPosX = (int)Math.Truncate(player.transform.position.x);
        //　プレイヤーY　四捨五入　と　このオブジェクトY　切り捨て　の差
        offset = Mathf.RoundToInt(player.transform.position.y) - (int)Math.Truncate(transform.position.y);
        
        //　プレイヤーXが前の座標より１進んでいたら、配列の座標も１つ進める
        if(count < playerPosX)
        {
            screenSlidePlus();
            count = playerPosX;
        }

       //　プレイヤーXが前の座標より１下がっていたら、配列の座標も１つ下げる
        if(count > playerPosX)
        {
            screenSlideMinus();
            count = playerPosX;
        }


        //　プレイヤーYとこのオブジェクトYの差が５以上だったら配列を１つ上げる
        if(offset > 5)
        {
            screenUp();
        }


        //　次のブロックを出していい状態になったら、これから出るブロック画を入れ替える
        if (next)
        {
            kind = kind1;
            pattern = pattern1;
            kind1 = kind2;
            pattern1 = pattern2;
            nextImage[0].sprite = nextBlock[numSp];
            NextBlock();
            state = kind;
            random();
            down = 0;
            speedX = 0;
            next = false;
        }

        //　一秒を測る
        if (auto)
        {
            delta -= Time.deltaTime;
        }
        
        //　一秒ごとにブロックYを１つ下げる
        if(delta <= 0)
        {
            delta = 0.5f;
            down++;
            down = Mathf.Clamp(down, 0, 16);
            Read();
        }

    }


    //マップに移す所にブロックがあるか確認する
    bool buttonTF = true;
    void check()
    {
        int x = 0;
        int y = 0;

        for (int i = 0; i < 16; i++)
        {
            if (map[0, 17 + y - down, 10 + x + speedX] > 1)
            {
                buttonTF = false;
                break;
            }

            x++;
            if (x > 3)
            {
                x = 0;
                y++;
            }

        }

        Read();
    }


    //ランダムに生成したブロックをマップ配列に移す
    void Read()
    {
        for (int i = 0; i < mapX; i++)
        {
            if (map[0, 15, i] == 3)
            {
                SceneManager.LoadScene("Result");
            }
        }
        int x = 0;
        int y = 0;
        for (int i = 0; i < 16; i++)
        {
            if (AppearBlc[pattern, y, x] == 1)
            {
                map[0, 17 + y - down, 10 + x + speedX] = AppearBlc[pattern, y, x];
            }

            x++;
            if (x > 3)
            {
                x = 0;
                y++;
            }
        }
        stopCheck();
    }


    //下にブロックがある場合は、動かないブロックに変える。
    void stopCheck()
    {
        int x = 0;
        int y = 0;

        foreach (int i in map)
        {
            if (y > 0 && i == 1 && map[0, y - 1, x] == 3)
            {
                rankUp = true;  
                break;
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
            int xblc = 0;
            int yblc = 0;

            foreach(int i in map)
            {
                if (i == 1)
                {
                    map[0, yblc, xblc] = 2;
                }

                xblc++;
                if (xblc > mapX - 1)
                {
                    xblc = 0;
                    yblc++;
                }
            }
            rankUp = false;
        }
        MapForm();
    }
    

    //一回cube1タグのオブジェクトを消す。マップ配列の数字の通りにブロックを生成する。
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
                Instantiate(cube1, new Vector3(x + playerPosX, y + up-1, 0), Quaternion.identity);
                map[0, y, x] = 0;
            }

            if(map[0, y, x] == 2)
            {
                Instantiate(cube2, new Vector3(x + playerPosX, y+up-1, 0), Quaternion.identity);
                map[0, y, x] = 3;
                next = true;
            }

            x++;
            if (x > mapX - 1)
            {
                x = 0;
                y++;
            }
        }
    }


    //cameraがhighrより大きくなるとマップを下げる、playerが１進むとマップが左に１よる
    int up = 0;
    void screenUp()
    {
        Array.Copy(map, mapX, map, 0, map.Length - mapX);
        transform.position = new Vector3(transform.position.x,
            transform.position.y + 1,
            transform.position.z);
        up = (int)Math.Truncate(transform.position.y);
        down++;
        for (int i = 0; i < mapX; i++)
        {
            map[0, 0, i] = 3;
        }
    }


    // 配列を右に１つずらす
    void screenSlidePlus()
    {
        for (int i = 0; i < mapY; i++)
        {
            Array.Copy(map, mapX * i + 1, map, mapX * i, mapX - 1);
        }
        speedX--;
        speedX = Mathf.Clamp(speedX, -9, 10);
        Read();
    }
     

    //　配列を左に１つずらす
    void screenSlideMinus()
    {
        for (int i = 0; i < mapY; i++)
        {
            Array.Copy(map, mapX * i, map, mapX * i + 1, mapX - 1);
        }
        speedX++;
        speedX = Mathf.Clamp(speedX, -9, 10);
        Read();
    }


    //　緑のボタンを押すとブロックを回転させる
    public void RotaButton()
    {
        pattern++;

        if (pattern > 3)
        {
            pattern = 0;
        }
        Read();
        blokMove.PlayOneShot(blokMove.clip);
    }


    //　右のボタンを押すとブロックを右に移動させる
    public void RightButton()
    {
        check();
        if (buttonTF)
        {
            speedX++;
            speedX = Mathf.Clamp(speedX, -9, 10);
            blokMove.PlayOneShot(blokMove.clip);
        }
        Read();
        buttonTF = true;
    }


    //　左のボタンを押すとブロックを左に移動させる
    public void LeftButton()
    {
        check();
        if (buttonTF)
        {
            speedX--;
            speedX = Mathf.Clamp(speedX, -9, 10);
            blokMove.PlayOneShot(blokMove.clip);
        }
        Read();
        buttonTF = true;
    }


    //　下のボタンを押すとブロックを下に移動させる
    public void DownButton()
    {
        auto = false;
        down++;
        down = Mathf.Clamp(down, 0, 16);
        blokMove.PlayOneShot(blokMove.clip);
        Read();
        auto = true;
    }
}
