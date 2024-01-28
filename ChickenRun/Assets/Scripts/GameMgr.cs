using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameMgr : MonoBehaviour
{
    public Text resultText;
    public PlayerController playerController;

    public float gameSpeed = 5f;


    void Start()
    {

        PlayerSingleton.instance.Lobby();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        LBGMManager.instance.PlayBgm("Game");
        
    }


    void Update()
    {
        resultText.text = playerController.score.ToString();
        
    }

}
