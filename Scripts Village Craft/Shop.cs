using UnityEngine;
using UnityEngine.UI;
using System;

public class Shop : MonoBehaviour
{
    public GameObject GemsShop;
    public GameObject MetsShop;
    public GameObject market;
    public Text[] metslabel;

    public void ShopBuy(int id)
    {
        switch (id)
        {
            case 0:
                if (Save.emeralds >= 100)
                {
                    Save.emeralds -= 100;
                    Save.logs += Convert.ToInt32(1000 * (1 + 0.5 * Save.lvlBuildings[0]));
                }
                else
                {
                    GemsShop.SetActive(true);
                    MetsShop.SetActive(false);
                }
                break;
            case 1:
                if (Save.emeralds >= 200)
                {
                    Save.emeralds -= 200;
                    Save.logs += Convert.ToInt32(2500 * (1 + 0.5 * Save.lvlBuildings[0]));
                }
                else
                {
                    GemsShop.SetActive(true);
                    MetsShop.SetActive(false);
                }
                break;
            case 2:
                if (Save.emeralds >= 500)
                {
                    Save.emeralds -= 500;
                    Save.logs += Convert.ToInt32(10000 * (1 + 0.5 * Save.lvlBuildings[0]));
                }
                else
                {
                    GemsShop.SetActive(true);
                    MetsShop.SetActive(false);
                }
                break;
            case 3:
                if (Save.emeralds >= 100)
                {
                    Save.emeralds -= 100;
                    Save.coins += Convert.ToInt32(1000 * (1 + 0.5 * Save.lvlBuildings[0]));
                }
                else
                {
                    GemsShop.SetActive(true);
                    MetsShop.SetActive(false);
                }
                break;
            case 4:
                if (Save.emeralds >= 200)
                {
                    Save.emeralds -= 200;
                    Save.coins += Convert.ToInt32(2500 * (1 + 0.5 * Save.lvlBuildings[0]));
                }
                else
                {
                    GemsShop.SetActive(true);
                    MetsShop.SetActive(false);
                }
                break;
            case 5:
                if (Save.emeralds >= 500)
                {
                    Save.emeralds -= 500;
                    Save.coins += Convert.ToInt32(10000 * (1 + 0.5 * Save.lvlBuildings[0]));
                }
                else
                {
                    GemsShop.SetActive(true);
                    MetsShop.SetActive(false);
                }
                break;
            case 6:
                if (Save.emeralds >= 100)
                {
                    Save.emeralds -= 100;
                    Save.stone += Convert.ToInt32(1000 * (1 + 0.5 * Save.lvlBuildings[0]));
                }
                else
                {
                    GemsShop.SetActive(true);
                    MetsShop.SetActive(false);
                }
                break;
            case 7:
                if (Save.emeralds >= 200)
                {
                    Save.emeralds -= 200;
                    Save.stone += Convert.ToInt32(2500 * (1 + 0.5 * Save.lvlBuildings[0]));
                }
                else
                {
                    GemsShop.SetActive(true);
                    MetsShop.SetActive(false);
                }
                break;
            case 8:
                if (Save.emeralds >= 500)
                {
                    Save.emeralds -= 500;
                    Save.stone += Convert.ToInt32(10000 * (1 + 0.5 * Save.lvlBuildings[0]));
                }
                else
                {
                    GemsShop.SetActive(true);
                    MetsShop.SetActive(false);
                }
                break;
        }
    }


    private void Update()
    {
        metslabel[0].text = "x" + 1000 * (1 + 0.5 * Save.lvlBuildings[0]);
        metslabel[1].text = "x" + 2500 * (1 + 0.5 * Save.lvlBuildings[0]);
        metslabel[2].text = "x" + 10000 * (1 + 0.5 * Save.lvlBuildings[0]);
        metslabel[3].text = "x" + 1000 * (1 + 0.5 * Save.lvlBuildings[0]);
        metslabel[4].text = "x" + 2500 * (1 + 0.5 * Save.lvlBuildings[0]);
        metslabel[5].text = "x" + 10000 * (1 + 0.5 * Save.lvlBuildings[0]);
        metslabel[6].text = "x" + 1000 * (1 + 0.5 * Save.lvlBuildings[0]);
        metslabel[7].text = "x" + 2500 * (1 + 0.5 * Save.lvlBuildings[0]);
        metslabel[8].text = "x" + 10000 * (1 + 0.5 * Save.lvlBuildings[0]);
    }
    public void buySkin(int id)
    {
        switch (id)
        {
            case 0:
                if (Save.emeralds >= 100)
                {
                    Save.emeralds -= 100;
                }
                else
                {
                    market.SetActive(true);
                }

                break;

            case 1:
                if (Save.emeralds >= 200)
                {
                    Save.emeralds -= 200;
                }
                else
                {
                    market.SetActive(true);
                }

                break;

            case 2:
                if (Save.emeralds >= 300)
                {
                    Save.emeralds -= 300;
                }
                else
                {
                    market.SetActive(true);
                }

                break;

            case 3:
                if (Save.emeralds >= 400)
                {
                    Save.emeralds -= 400;
                }
                else
                {
                    market.SetActive(true);
                }

                break;

            case 4:
                if (Save.emeralds >= 400)
                {
                    Save.emeralds -= 400;
                }
                else
                {
                    market.SetActive(true);
                }

                break;

            case 5:
                if (Save.emeralds >= 400)
                {
                    Save.emeralds -= 400;
                }
                else
                {
                    market.SetActive(true);
                }

                break;

            case 6:
                if (Save.emeralds >= 800)
                {
                    Save.emeralds -= 800;
                }
                else
                {
                    market.SetActive(true);
                }

                break;

            case 7:
                if (Save.emeralds >= 800)
                {
                    Save.emeralds -= 800;
                }
                else
                {
                    market.SetActive(true);
                }

                break;

            case 8:
                if (Save.emeralds >= 800)
                {
                    Save.emeralds -= 800;
                }
                else
                {
                    market.SetActive(true);
                }

                break;

            case 9:
                if (Save.emeralds >= 1600)
                {
                    Save.emeralds -= 1600;
                }
                else
                {
                    market.SetActive(true);
                }

                break;
        }
    }
}


