using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;
    public PlayerController playerController;
    public GameObject user;
    public BtnMgr btnMgr;
    public int Lv =1;
    public float MaxHp =100;
    public float MaxExp =50;
    public float expValue;
    public int coinAm;
    public int goldEggAm;
    public float[] bestScore = new float[10];
    public string[] bestUser = new string[10];
    
    public bool coin;
    public bool goldEgg;
    public bool hp;
    public bool maxexp;
    public bool lv;
    public bool exp;
    
    

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        
        hp =PlayerPrefs.HasKey("HP");
        maxexp = PlayerPrefs.HasKey("MaxExpValue");
        lv = PlayerPrefs.HasKey("UpLevel");
        exp = PlayerPrefs.HasKey("ExpValue");
        coin = PlayerPrefs.HasKey("Coin");
        goldEgg = PlayerPrefs.HasKey("GoldEgg");
        
        if(hp ==true &&  maxexp ==true && lv == true && exp == true && coin == true && goldEgg == true )
        {
            Lv = PlayerPrefs.GetInt("UpLevel");
            MaxHp = PlayerPrefs.GetFloat("HP");
            MaxExp = PlayerPrefs.GetFloat("MaxExpValue");
            expValue = PlayerPrefs.GetFloat("ExpValue");
            coinAm = PlayerPrefs.GetInt("Coin");
            goldEggAm = PlayerPrefs.GetInt("GoldEgg");
            
        }
        else
        {
            Lv = 1;
            MaxHp = 100;
            MaxExp = 50;
            expValue = 0;
            coinAm = 0;
            goldEggAm = 0;
            
        }

        //ScoreSet();
    }

    public void ScoreSet(float currentScore, string currentName)
    {
        


        float tmpScore = 0f;
        string tmpName = "";
        for(int i = 0; i<10; i++)
        {
            bestScore[i] = PlayerPrefs.GetFloat(i+"BestScore");
            bestUser[i] = PlayerPrefs.GetString(i+"CurrentUserName");

            while (bestScore[i]< currentScore)
            {
                tmpScore = bestScore[i];
                tmpName = bestUser[i];
                bestScore[i] = currentScore;
                bestUser[i] = currentName;

                PlayerPrefs.SetFloat(i + "BestScore", currentScore);
                PlayerPrefs.SetString(i.ToString() + "CurrentUserName", currentName);

                currentScore = tmpScore;
                currentName = tmpName;
            }
        }

        for (int i = 0;i<10; i++)
        {
            PlayerPrefs.SetFloat(i + "BestScore", bestScore[i]);
            PlayerPrefs.SetString(i.ToString() + "CurrentUserName", bestUser[i]);
        }

        
    }
}
