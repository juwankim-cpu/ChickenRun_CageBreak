using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggController : MonoBehaviour
{
    public float eggSpeed;
    public GameMgr gameMgr;
    
    void Start()
    {
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        eggSpeed = gameMgr.gameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-eggSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DestroyWall")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "BoosterMode")
        {
            Destroy(gameObject);
        }
        

        
    }
}
