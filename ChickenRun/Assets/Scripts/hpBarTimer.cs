using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class hpBarTimer : MonoBehaviour
{
    public Slider hpBar;
    public PlayerController playerController;
    public GameObject gameOverPanel;
    public eggController eggController;
    public ObstacleController obstacleController;
    public EggMaker eggMaker;
    public ObstacleMaker obstacleMaker;
    public GameObject Player;
    public GameMgr gameMgr;
    public GameObject Bg;
    public BtnMgr btnMgr;
    public ObstacleMakerup obstacleMakerup;

    void Start()
    {
       hpBar = GetComponent<Slider>();
        Player = GameObject.Find("Player");
       playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        btnMgr = GameObject.Find("BtnMgr").GetComponent<BtnMgr>();
        
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = playerController.hp / playerController.maxHp;
        if (hpBar.value > 0.0f)
        {
            playerController.hp -= Time.deltaTime*1.7f;

        }
        
        if(hpBar.value <= 0.0f)
        {
            playerController.playerAnim.SetInteger("PLAYERSTATE", 4);
            gameOverPanel.SetActive(true);
            eggController.eggSpeed = 0;
            obstacleController.obsSpeed = 0;
            eggMaker.curTime = 0;
            obstacleMaker.curTime = 0;
            obstacleMakerup.curTime = 0;
            Player.GetComponent<BoxCollider>().size = new Vector3(0.1f, 0.1f, 0);
            Bg.GetComponent<BGScroll>().offset = 0;
            playerController.isBooster = false;
                
            
                
            

            
                PlayerPrefs.SetInt("Coin", playerController.coinCnt + playerController.coinAmount);
                PlayerPrefs.SetInt("GoldEgg", playerController.goldenEggCnt + playerController.goldEggAmount);
            
        
            
        }
    }
}
