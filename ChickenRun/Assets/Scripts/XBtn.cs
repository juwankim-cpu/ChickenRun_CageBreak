using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XBtn : MonoBehaviour
{
    public LvUpMgr lvUpMgr;
    public PlayerController playerController;
    public void BackToLobby()
    {
        SceneManager.LoadScene("LobbyScene");
        
        PlayerPrefs.SetFloat("ExpValue", lvUpMgr.expBar.value);
        PlayerPrefs.SetFloat("ExpMaxValue", lvUpMgr.expBar.maxValue);
        
        



    }
}
