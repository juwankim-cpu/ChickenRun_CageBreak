using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterMaker : MonoBehaviour
{
    public GameObject boosterPrefab;
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
            GameObject booster = Instantiate(boosterPrefab);
            booster.transform.position = new Vector3(15, Random.Range(0f, 1.4f), 0);
            booster.transform.rotation = transform.rotation;
            booster.name = "Booster";

            coolTime = Random.Range(20f, 26f);
        }


    }
}
