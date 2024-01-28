using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BtnMgr : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject player;
    public GameMgr gameMgr;

    
    
    
    public hpBarTimer Hp;
    public PlayerController playerController;
    public string UserName = null;

    [SerializeField]
    InputField userName;

    public void Start()
    {
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        
        
    }
    public void Pause() 
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        playerController.isBooster = false;
        SFXManager.instance.PlaySFX("PlayBtn");

    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        
        SceneManager.LoadScene("GameScene");
        gameOverPanel.SetActive(false);
        SFXManager.instance.PlaySFX("PlayBtn");


    }

    public void PanelOff()
    {
        Time.timeScale = 1.0f;
        gameMgr.gameSpeed = 5;
        SFXManager.instance.PlaySFX("PlayBtn");

        pausePanel.SetActive(false);
        if (player.CompareTag("BoosterMode"))
        {
            playerController.isBooster = true;
        }
    }

    public void StopGame()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        playerController.hp = 0.0f;
        Time.timeScale = 1.0f;
        gameMgr.gameSpeed = 0.0f;
        SFXManager.instance.PlaySFX("PlayBtn");


    }

    public void MoveToLobby()
    {
        Time.timeScale = 1.0f;
        SFXManager.instance.PlaySFX("PlayBtn");
        LoadingSceneManager.LoadScene("LobbyScene");
        player.GetComponent<BoxCollider>().size = new Vector3(1,1.3f,1);
        if (userName.text.Length != 0)
        {
            UserName = userName.text;
            PlayerPrefs.SetString("CurrentUserName", UserName);
            DataManager.instance.ScoreSet(playerController.score, UserName);
            
            
        }
        
    }

    
}
