using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxSlider : MonoBehaviour
{
    public Slider sfxSlider;
    void Start()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfx_vol",0.75f);
    }

    public void SetSFX()
    {
        SFXManager.instance.sfxManager.volume = sfxSlider.value;
        PlayerPrefs.SetFloat("sfx_vol", sfxSlider.value);
    }
}
