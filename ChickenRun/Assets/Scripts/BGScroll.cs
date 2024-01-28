using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public MeshRenderer bgRender;
    public float offset;
    public float speed;
    public hpBarTimer hp;
    public GameMgr gameMgr;
    
    
    void Start()
    {
        bgRender = GetComponent<MeshRenderer>();
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        
    }

    
    void Update()
    {
        offset += Time.deltaTime * gameMgr.gameSpeed*0.05f;
        
        bgRender.material.mainTextureOffset = new Vector2(offset, 0);

        if (hp.hpBar.value <= 0)
        {
            offset = 0;
        }
        
    }
}
