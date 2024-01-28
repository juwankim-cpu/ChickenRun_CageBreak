
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerSingleton : MonoBehaviour
{
    public static PlayerSingleton instance = null;
    public GameObject character;
    
    public GameObject[] chicken;
    public int changevalue;
    
    

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }

        }

        character = GameObject.Find("Player");
        
        //Debug.Log(changevalue);
        
    }
    
    public void Init_1()
    {
        character.transform.GetChild(2).gameObject.SetActive(true);
        character.transform.GetChild(0).gameObject.SetActive(false);
        character.transform.GetChild(3).gameObject.SetActive(false);
        character.transform.GetChild(4).gameObject.SetActive(false);
        ChangeValue(1);
    }
    public void Init_2()
    {
        character.transform.GetChild(3).gameObject.SetActive(true);
        character.transform.GetChild(0).gameObject.SetActive(false);
        character.transform.GetChild(2).gameObject.SetActive(false);
        character.transform.GetChild(4).gameObject.SetActive(false);
        ChangeValue(2);

    }
    public void Init_3()
    {
        character.transform.GetChild(4).gameObject.SetActive(true);
        character.transform.GetChild(0).gameObject.SetActive(false);
        character.transform.GetChild(2).gameObject.SetActive(false);
        character.transform.GetChild(3).gameObject.SetActive(false);
        ChangeValue(3);
    }
    public void Init_4()
    {
        character.transform.GetChild(0).gameObject.SetActive(true);
        character.transform.GetChild(2).gameObject.SetActive(false);
        character.transform.GetChild(3).gameObject.SetActive(false);
        character.transform.GetChild(4).gameObject.SetActive(false);
        ChangeValue(0);
    }
    public void Lobby()
    {
        if (SceneManager.GetActiveScene().name == "LobbyScene"|| SceneManager.GetActiveScene().name == "GameScene"
            || SceneManager.GetActiveScene().name == "LevelUpScene")
        {
            character = GameObject.Find("Player");

            Instantiate(chicken[0], character.transform);
            Instantiate(chicken[1], character.transform);
            Instantiate(chicken[2], character.transform);
            
            //character.transform.GetChild(1).gameObject.SetActive(false);
            //character.transform.GetChild(2).gameObject.SetActive(false);
            //character.transform.GetChild(3).gameObject.SetActive(false);

            if(changevalue ==0)
            {
                character.transform.GetChild(0).gameObject.SetActive(true);
                character.transform.GetChild(2).gameObject.SetActive(false);
                character.transform.GetChild(3).gameObject.SetActive(false);
                character.transform.GetChild(4).gameObject.SetActive(false);
                
            }

            if (changevalue ==1)
            {
                character.transform.GetChild(0).gameObject.SetActive(false);
                character.transform.GetChild(3).gameObject.SetActive(false);
                character.transform.GetChild(4).gameObject.SetActive(false);
                character.transform.GetChild(2).gameObject.SetActive(true);
                
            }

            if (changevalue == 2)
            {
                character.transform.GetChild(3).gameObject.SetActive(true);
                character.transform.GetChild(0).gameObject.SetActive(false);
                character.transform.GetChild(2).gameObject.SetActive(false);
                character.transform.GetChild(4).gameObject.SetActive(false);
                
            }   

            if (changevalue == 3)
            {
                    character.transform.GetChild(0).gameObject.SetActive(false);
                    character.transform.GetChild(2).gameObject.SetActive(false);
                    character.transform.GetChild(3).gameObject.SetActive(false);
                    character.transform.GetChild(4).gameObject.SetActive(true);
                
            }
        }

        
    }
    
    public void ChangeValue(int variable) 
    {
        changevalue = variable;
    }
}
