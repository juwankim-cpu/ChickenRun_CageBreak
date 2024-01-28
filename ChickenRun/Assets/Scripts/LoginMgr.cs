using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoginMgr : MonoBehaviour
{
    public Text startTxt;
    public LoopType loopType;

    private void Start()
    {
        startTxt.DOFade(0.0f, 1.25f).SetLoops(-1, loopType);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadingSceneManager.LoadScene("LobbyScene");
        }
    }
}
