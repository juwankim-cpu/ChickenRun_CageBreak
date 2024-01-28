using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    public AudioSource sfxManager;
    public Slider sfx_Slider;
    public AudioClip[] sfx_Clips;
    void Awake()
    {
        DestroySFX();

        instance = this;
        sfxManager = GameObject.Find("SFXManager").GetComponent<AudioSource>();
        
        sfx_Slider.onValueChanged.AddListener(ChangeSFX);
    }
    public void DestroySFX()
    {

        var obj = FindObjectsOfType<SFXManager>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ChangeSFX(float value)
    {
        sfxManager.volume = value;
        
    }

    public void PlaySFX(string type)
    {
        int index = 0;

        switch (type)
        {
            case "Jump": index = 0; break;
            case "Slide": index = 1; break;
            case "Hit": index = 2; break;
            case "Potion": index = 3; break;
            case "Booster": index=4; break;
            case "LevelUp": index=5; break;
            case "PlayBtn": index=6; break;
            
        }

        sfxManager.clip = sfx_Clips[index];
        sfxManager.Play();
    }
}
