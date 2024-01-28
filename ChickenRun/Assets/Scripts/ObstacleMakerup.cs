using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMakerup : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float curTime;
    public float coolTime;

    

    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
       
            curTime += Time.deltaTime;
            if (curTime > coolTime)
            {

                curTime = 0;
                GameObject enemy = Instantiate(obstaclePrefab);
                enemy.transform.position = transform.position;   
                enemy.transform.rotation = transform.rotation;
                enemy.name = "Obstacle1";
                RandomCoolTime();
            }
        }

    

    void RandomCoolTime()
    {
        coolTime = 10f;
    }
}
