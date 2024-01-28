using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("Map Data - Map");

        for (int i = 0; i < data.Count; i++)
        {
            Debug.Log(data[i]["EggType"].ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
