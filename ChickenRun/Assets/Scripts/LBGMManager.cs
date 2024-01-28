using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LBGMManager : MonoBehaviour
{
    public static LBGMManager instance;
    public AudioSource lbgmManager;
    public Slider bgm_Slider;
    
    
    public AudioClip[] bgm_Clips;
    
    
    void Awake()
    {
        DestroySound();
        instance = this;
        lbgmManager = GameObject.Find("BGMManager").GetComponent<AudioSource>();
        
        
        bgm_Slider.onValueChanged.AddListener(ChangeBGM);

        
    }
    
    public void ChangeBGM(float value)
    {
        lbgmManager.volume = value;
        
        
    }

    public void DestroySound()
    {

        var obj = FindObjectsOfType<LBGMManager>();

        if (obj.Length ==1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBgm(string type)
    {
        int index = 0;

        switch (type)
        {
            case "Lobby": index = 0; break;
            case "Game": index = 1; break;
        }

        lbgmManager.clip = bgm_Clips[index];
        lbgmManager.Play();
    }

    
}   

