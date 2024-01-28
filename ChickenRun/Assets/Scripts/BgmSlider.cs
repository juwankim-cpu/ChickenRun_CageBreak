using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSlider : MonoBehaviour
{
    public Slider bgmSlider;
    
    void Start()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("bgm_vol",0.75f);    
    }

    
    public void SetBGM()
    {
        LBGMManager.instance.lbgmManager.volume = bgmSlider.value;
        PlayerPrefs.SetFloat("bgm_vol", bgmSlider.value);
    }
}
