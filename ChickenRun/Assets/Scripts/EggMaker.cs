using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMaker : MonoBehaviour
{
    public GameObject [] eggPrefab;
    

    
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
            int eggIndex = Random.Range(0, eggPrefab.Length);
            GameObject egg = Instantiate(eggPrefab[eggIndex]);
            egg.transform.position = new Vector3(15, Random.Range(-.4f, 2.3f),0);
            egg.transform.rotation = transform.rotation;
            egg.name = "Egg";
           
            coolTime = 0.4f;
        }

        
    }



    
}
