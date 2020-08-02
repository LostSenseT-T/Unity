using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyOrder : MonoBehaviour
{
    public GameObject[] CloseedSkin;
    public Text coinsText;
    public void Start()
    {
        //load open skins
        coinsText.text = "Coins: " + info.coins;
        for (int j = 0; j < info.i; j++)
        {
            info.BoughtSkins[j] = bool.Parse(PlayerPrefs.GetString("Skin_" + j));
            if (info.BoughtSkins[j])
            {
                CloseedSkin[j].gameObject.SetActive(false);
            }
        }
    }
    public void TryBuy(int indexSkins)
    {
        //try buy
        if (info.coins >= 10)
        {
            info.coins -= 10;
            PlayerPrefs.SetInt("coins", info.coins);
            coinsText.text = "Coins: " + info.coins;
            CloseedSkin[indexSkins].gameObject.SetActive(false);
            info.BoughtSkins[indexSkins] = true;
            for (int i = 0; i < info.BoughtSkins.Length; i++)
            {
                PlayerPrefs.SetString("Skin_" + i, info.BoughtSkins[i].ToString());
            }
        }
    }
    public void Activate(int indexSkins)
    {
        //activate skin
        info.SkinName = indexSkins;
        PlayerPrefs.SetInt("SkinID", info.SkinName);
    }
}
