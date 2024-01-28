using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMaker : MonoBehaviour
{
    public GameObject potionPrefab;



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
            GameObject potion = Instantiate(potionPrefab);
            potion.transform.position = new Vector3(15, Random.Range(0f, 1.4f), 0);
            potion.transform.rotation = transform.rotation;
            potion.name = "Potion";

            coolTime = Random.Range(18f, 20f) ;
        }


    }
}
