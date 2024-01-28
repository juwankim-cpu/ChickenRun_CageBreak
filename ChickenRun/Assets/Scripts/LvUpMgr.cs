using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvUpMgr : MonoBehaviour
{
    //public Slider hpBar;
    public DataManager dataMgr;
    public PlayerController playerController;
    public Text LvTxt;
    public Text GoldEgg;
    public Text hpTxt;
    public Text btnTxt;
    public Text maxExpTxt;
    public Text coinTxt;
    
    public Button lvUpBtn;
    public Slider expBar;
    
    public float hpPlus;

    
    public int exp = 10;
    public float hpUp = 50;

    void Start()
    {
        LBGMManager.instance.PlayBgm("Lobby");
        PlayerSingleton.instance.Lobby();
        dataMgr = GameObject.Find("DataManager").GetComponent<DataManager>();
         playerController.maxHp = PlayerPrefs.GetFloat("HP");
        
        //hpTxt.text = hpBar.maxValue.ToString();
        hpTxt.text = dataMgr.MaxHp.ToString();
        GoldEgg.text = PlayerPrefs.GetInt("GoldEgg").ToString();
        LvTxt.text = "LV. " + dataMgr.Lv;
        coinTxt.text = PlayerPrefs.GetInt("Coin").ToString();


        


        //Debug.Log(playerController.goldEggAmount);


    }

    
    void Update()
    {

        hpTxt.text = dataMgr.MaxHp.ToString();
        expBar.value = dataMgr.expValue;
        expBar.maxValue = dataMgr.MaxExp;

        playerController.maxExp = PlayerPrefs.GetFloat("MaxExpValue");
        
        GoldEgg.text = PlayerPrefs.GetInt("GoldEgg").ToString();
        maxExpTxt.text = dataMgr.MaxExp.ToString();
        coinTxt.text = PlayerPrefs.GetInt("Coin").ToString();

        if (dataMgr.Lv == 30)
        {
            btnTxt.text = "최고 레벨 달성!!";
            lvUpBtn.enabled = false;

        }

        if (PlayerPrefs.GetInt("GoldEgg") < exp)
        {
            btnTxt.text = "황금달걀이 부족합니다";
            lvUpBtn.enabled = false;
        }

        
        
    }

    public void LvUp()
    {

        
        //hpBar.maxValue+= 10;
        //hpBar.value += 10;
        //hpTxt.text = hpBar.maxValue.ToString();
        dataMgr.expValue += exp;
        PlayerPrefs.SetFloat("Expvalue", dataMgr.expValue);
            
        if(dataMgr.expValue >= dataMgr.MaxExp)
        {
            dataMgr.expValue = 0;
            dataMgr.Lv++;
            dataMgr.MaxHp += 10;
            hpTxt.text = dataMgr.ToString();
            LvTxt.text = "LV. " + dataMgr.Lv;

            dataMgr.MaxExp += 50;
            SFXManager.instance.PlaySFX("LevelUp");
            PlayerPrefs.SetFloat("MaxExpValue", dataMgr.MaxExp);
            PlayerPrefs.SetInt("UpLevel", dataMgr.Lv);
            PlayerPrefs.SetFloat("HP", dataMgr.MaxHp);

            
            
        }
        
        
        

        //PlayerPrefs.SetFloat("MaxExpValue", expBar.maxValue);

        PlayerPrefs.SetInt("GoldEgg", PlayerPrefs.GetInt("GoldEgg") - exp);

        
        
        
       
    }

    
}
