using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyMgr : MonoBehaviour
{
    public GameObject player;
    public GameObject OptionPanel;
    public GameObject shopPanel;
    public SkinMgr skinMgr;
    public Button PlayBtn;
    public Button OptionBtn;
    public Button shopBtn;
    public Text Cointxt;
    public Text GoldEggTxt;
    public Text Score;
    public Text LV;
    public float[] rankScore = new float[10];
    public Text[] rankScoreText = new Text[10];
    public string[] rankName = new string[10];
    public Text[] rankNameText = new Text[10];
    public GameObject dataManager;
    public DataManager dataMgr;
    

    private void Start()
    {
        dataManager = GameObject.Find("DataManager");
        dataMgr = dataManager.GetComponent<DataManager>();
        Cointxt.text = PlayerPrefs.GetInt("Coin").ToString();
       
        GoldEggTxt.text = PlayerPrefs.GetInt("GoldEgg").ToString() ;
        
        
        
            
        PlayerSingleton.instance.Lobby();
        for (int i = 0; i < 10; i++)
        {
            rankScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            rankScoreText[i].text = string.Format(rankScore[i].ToString());
            rankName[i] = PlayerPrefs.GetString(i.ToString() + "CurrentUserName");
            rankNameText[i].text = string.Format(rankName[i]);


        }
        LBGMManager.instance.PlayBgm("Lobby");
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }        
    }
    public void Option()
    {
        OptionPanel.SetActive(true);
        PlayBtn.enabled = false;
        SFXManager.instance.PlaySFX("PlayBtn");
    }

    public void ShoptoLobby()
    {
        OptionPanel.SetActive(false);
        shopPanel.SetActive(false);
        PlayBtn.enabled = true;
        OptionBtn.enabled = true;
        shopBtn.enabled = true;
        Cointxt.text = PlayerPrefs.GetInt("Coin").ToString();
        PlayerPrefs.SetFloat("bgm_vol", SFXManager.instance.sfxManager.volume);
        SFXManager.instance.PlaySFX("PlayBtn");
    }
    public void Shop()
    {
        shopPanel.SetActive(true);
        PlayBtn.enabled=false;
        OptionBtn.enabled=false;
        shopBtn.enabled=false;
        SFXManager.instance.PlaySFX("PlayBtn");
    }
    public void Lobby()
    {
        OptionPanel.SetActive(false);
        shopPanel.SetActive(false);
        PlayBtn.enabled = true;
        OptionBtn.enabled=true;
        shopBtn.enabled=true;
        Cointxt.text = PlayerPrefs.GetInt("Coin").ToString();
        SFXManager.instance.PlaySFX("PlayBtn");

    }

    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        LoadingSceneManager.LoadScene("GameScene");
        PlayerPrefs.GetFloat("HPvalue");
        SFXManager.instance.PlaySFX("PlayBtn");
    }

    public void GrowPage()
    {
        SceneManager.LoadScene("LevelUpScene");
        PlayerPrefs.GetInt("Level");
        PlayerPrefs.GetFloat("Hp");
        PlayerPrefs.GetFloat("ExpValue");
        PlayerPrefs.GetFloat("ExpMaxValue");
        SFXManager.instance.PlaySFX("PlayBtn");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

