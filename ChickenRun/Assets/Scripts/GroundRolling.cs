using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRolling : MonoBehaviour
{
    public float speed;
    public float limitX;
    public Vector3 originPos;
    public hpBarTimer hp;
    public GameMgr gameMgr;

    

    void Start()
    {
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
    }

    void FixedUpdate()
    {
        
        transform.Translate(-gameMgr.gameSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x < limitX)
        {
            transform.position = originPos;
        }

        if( hp.hpBar.value <= 0)
        {
            gameMgr.gameSpeed = 0;
        }
    }
}
