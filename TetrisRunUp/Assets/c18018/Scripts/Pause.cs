using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject player;
    Rigidbody playerRid;

    Vector3 playerVelocity = Vector3.zero;
    Vector3 playerAnVelo = Vector3.zero;


    private void Start()
    {
        playerRid = player.GetComponent<Rigidbody>();
    }

    public void PauseButton()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            playerVelocity = playerRid.velocity;
            playerAnVelo = playerRid.angularVelocity;
            playerRid.velocity = Vector3.zero;
            playerRid.angularVelocity = Vector3.zero;
            playerRid.useGravity = false;
            pausePanel.SetActive(true);
        }
        else
        {
            playerRid.velocity = playerVelocity;
            playerRid.angularVelocity = playerAnVelo;
            playerRid.useGravity = true;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
}