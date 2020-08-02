 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerasc : MonoBehaviour
{
    public GameObject player;
    
    void Update () 
    {
        //cumshot
        if (player != null)
        {
            transform.position = new Vector3(0, player.transform.position.y, -10);
        }
        else
        {
            transform.position = new Vector3(0, info.dethy, -10);
        }
        

    }
}
