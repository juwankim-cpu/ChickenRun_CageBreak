
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using UnityEngine;
using UnityEngine.UI;
using System;

public class SkinMgr : MonoBehaviour
{
    public PlayerController playerController;
    public List<GameObject> chickenPrefab = new List<GameObject>();
    public GameObject temp;
    public List<GameObject> purchaseBtn;
    public List<GameObject> applyBtn;
    public int Coin;
    public Text MSG;
    public GameObject message;
    public float Timer;
    public bool Timeset;

    public bool skin_1;
    public bool skin_2;
    public bool skin_3;
    
   
    public 
    void Start()
    {
        Coin = PlayerPrefs.GetInt("Coin");
        temp = GameObject.Find("Player");

        skin_1 = PlayerPrefs.HasKey("Skin_1");
        skin_2 = PlayerPrefs.HasKey("Skin_2");
        skin_3 = PlayerPrefs.HasKey("Skin_3");

        if (skin_1 == true)
        {
            purchaseBtn[0].SetActive(false);
            applyBtn[0].SetActive(true);
        }
        if (skin_2 == true)
        {
            purchaseBtn[1].SetActive(false);
            applyBtn[1].SetActive(true);
        }
        if (skin_2 == true)
        {
            purchaseBtn[2].SetActive(false);
            applyBtn[2].SetActive(true);
        }



    }


    // Update is called once per frame
    void Update()
    {
        if (Timeset == true) // TimeSet이 True면
        {
            Timer += Time.deltaTime; // 타이머가 작동합니다.
            if (Timer > 2.0f) // 2초가 지나면
            {
                message.SetActive(false);
                MSG.text = null;
                Timer = 0;
                Timeset = false;
            }
        }
    }

    public void Purchase_0()
    {
        if (Coin >= 100)
        {
            Coin -= 100;
            purchaseBtn[0].SetActive(false);
            applyBtn[0].SetActive(true);
        }
        else
        {
            Coin -= 0;
            purchaseBtn[0].SetActive(true);
            applyBtn[0].SetActive(false);
            message.SetActive(true);
            Timeset = true;
            MSG.text = "코인이 부족합니다.";
        }

        PlayerPrefs.SetInt("Coin", Coin);

        if(temp.transform.GetChild(1).gameObject.activeSelf == true)
        {
            Coin -= 0;
            purchaseBtn[0].SetActive(true);
            applyBtn[0].SetActive(false);
            message.SetActive(true);
            Timeset = true;
            MSG.text = "이미 보유한 스킨입니다.";
        }

        

    }

    public void Purchase_1()
    {
        if (Coin >= 200)
        {
            Coin -= 200;
            purchaseBtn[1].SetActive(false);
            applyBtn[1].SetActive(true);
            
        }

        if (Coin < 200)
        {
            Coin -= 0;
            purchaseBtn[1].SetActive(true);
            applyBtn[1].SetActive(false);
            message.SetActive(true);
            Timeset = true;
            MSG.text = "코인이 부족합니다.";
        }
        PlayerPrefs.SetInt("Coin", Coin);

        if (temp.transform.GetChild(2).gameObject.activeSelf == true)
        {
            Coin -= 0;
            purchaseBtn[1].SetActive(true);
            applyBtn[1].SetActive(false);
            message.SetActive(true);
            Timeset = true;
            MSG.text = "이미 보유한 스킨입니다.";
        }


    }

    public void Purchase_2()
    {
        if (Coin >= 400)
        {
            Coin -= 400;
            purchaseBtn[2].SetActive(false);
            applyBtn[2].SetActive(true);
        }
        else
        {
            Coin -= 0;
            purchaseBtn[2].SetActive(true);
            applyBtn[2].SetActive(false);
            message.SetActive(true);
            Timeset = true;
            MSG.text = "코인이 부족합니다.";
        }

        PlayerPrefs.SetInt("Coin", Coin);

        if (temp.transform.GetChild(3).gameObject.activeSelf == true)
        {
            Coin -= 0;
            purchaseBtn[2].SetActive(true);
            applyBtn[2].SetActive(false);
            message.SetActive(true);
            Timeset = true;
            MSG.text = "이미 보유한 스킨입니다.";
        }
    }

    public  void ApllySkin()
    {

        PlayerSingleton.instance.Init_1();
        PlayerPrefs.SetInt("Skin_1", PlayerSingleton.instance.changevalue);
    }

    public  void ApllySkin_1()
    {

        PlayerSingleton.instance.Init_2();
        PlayerPrefs.SetInt("Skin_2", PlayerSingleton.instance.changevalue);

    }
    public  void ApllySkin_2()
    {

        PlayerSingleton.instance.Init_3();
        PlayerPrefs.SetInt("Skin_3", PlayerSingleton.instance.changevalue);
    }
    public void ApllySkin_3()
    {

        PlayerSingleton.instance.Init_4();
        PlayerPrefs.SetInt("Skin_0", PlayerSingleton.instance.changevalue) ;
    }
    


}
