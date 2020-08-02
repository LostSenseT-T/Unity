using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class coincsr : MonoBehaviour
{
    public GameObject coin;
    //if collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player += coin
        if(collision.gameObject.tag=="headplayer")
        {
            info.coins += 1;
            PlayerPrefs.SetInt("coins", info.coins);
            Destroy(gameObject);
        }
        //if panel/coin delete and random generate
        if(collision.gameObject.tag=="panel" || collision.gameObject.tag == "Coin")
        {
            Destroy(gameObject);
            Instantiate(coin, new Vector2(Random.Range(-3, 3), transform.position.y + (3 + Random.Range(1, 2))), Quaternion.identity);
        }

    }
    
}
