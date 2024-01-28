using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMaker : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float curTime;
    public float coolTime;

    

    void Start()
    {
        RandomCoolTime();
        

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
                enemy.name = "Obstacle";
                RandomCoolTime();
            }
        }

    

    void RandomCoolTime()
    {
        coolTime = Random.Range(1.5f,4.5f);
    }
}
