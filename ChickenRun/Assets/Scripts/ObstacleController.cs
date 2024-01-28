using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameMgr gameMgr;
    public float obsSpeed;
    public PlayerController playerController;
    
    
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        obsSpeed = gameMgr.gameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-obsSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "DestroyWall" )
        {
            Destroy(gameObject);
        }

        if(playerController.isGod == true)
        {
            playerController.score += 500;
            Destroy(gameObject);
        }

        
    }
}

