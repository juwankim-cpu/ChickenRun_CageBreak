using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerController controller;

    public void Update()
    {
        if(controller.isHit == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 15);

            if(controller.hitCurTime> 0.667)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            }
        }
        
    }
}
