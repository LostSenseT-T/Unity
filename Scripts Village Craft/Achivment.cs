using UnityEngine;
using UnityEngine.UI;
using System;

public class Achivment : MonoBehaviour
{
    public Image[] lvlAchiv;
    public Image[] lvlBord;
    public Text[] labelProsent;
    public Slider[] valuerosent;
    public Sprite[] ramki;
    public GameObject[] rewardImg;
    public Sprite[] achivImage;

    public void getRewardAchiv(int id)
    {
        if (Save.isachivgettedreward[id * 6 + 0])
        {
            Save.islastgettedachiv[id * 6 + 0] = true;
            Save.emeralds += 1000;
            rewardImg[id].SetActive(false);
        }
        else if (Save.isachivgettedreward[id * 6 + 1])
        {
            Save.islastgettedachiv[id * 6 + 1] = true;
            Save.emeralds += 1000;
            rewardImg[id].SetActive(false);
        }
        else if (Save.isachivgettedreward[id * 6 + 2])
        {
            Save.islastgettedachiv[id * 6 + 2] = true;
            Save.emeralds += 1000;
            rewardImg[id].SetActive(false);
        }
        else if (Save.isachivgettedreward[id * 6 + 3])
        {
            Save.islastgettedachiv[id * 6 + 3] = true;
            Save.emeralds += 1000;
            rewardImg[id].SetActive(false);
        }
        else if (Save.isachivgettedreward[id * 6 + 4])
        {
            Save.islastgettedachiv[id * 6 + 4] = true;
            Save.emeralds += 1000;
            rewardImg[id].SetActive(false);
        }
        else if (Save.isachivgettedreward[id * 6 + 5])
        {
            Save.islastgettedachiv[id * 6 + 5] = true;
            Save.emeralds += 1000;
            rewardImg[id].SetActive(false);
        }
    }
    int countskins = 0;
    private void Start()
    {

        for (int kl = 0; kl < 15; kl++)
        {
            if (Save.skinsBought[kl])
            {
                countskins++;
            }
        }
    }
    public void Update()
    {
        //Timerman
        if (Save.treesAll < 100)
        {
            Save.achivlvl[0] = 0;
            Save.persent[0] = Convert.ToInt32(Save.treesAll);
            Save.isachiv[0] = true;
        }
        if (Save.treesAll >= 100)
        {
            Save.achivlvl[0] = 1;
            Save.persent[0] = Convert.ToInt32((Save.treesAll - 100) / 4);
            Save.isachiv[1] = true;
        }
        if (Save.treesAll >= 500)
        {
            Save.achivlvl[0] = 2;
            Save.persent[0] = Convert.ToInt32((Save.treesAll - 500) / 20);
            Save.isachiv[2] = true;
        }
        if (Save.treesAll >= 2500)
        {
            Save.achivlvl[0] = 3;
            Save.persent[0] = Convert.ToInt32((Save.treesAll - 2500) / 25);
            Save.isachiv[3] = true;
        }
        if (Save.treesAll >= 5000)
        {
            Save.achivlvl[0] = 4;
            Save.persent[0] = Convert.ToInt32((Save.treesAll - 5000) / 50);
            Save.isachiv[4] = true;
        }
        if (Save.treesAll >= 10000)
        {
            Save.achivlvl[0] = 5;
            Save.persent[0] = 100;
            Save.isachiv[5] = true;
        }

        //Adventure
        if (Save.cionsAll < 100)
        {
            Save.achivlvl[1] = 0;
            Save.persent[1] = Convert.ToInt32(Save.cionsAll);
            Save.isachiv[6] = true;
        }
        if (Save.cionsAll >= 100)
        {
            Save.achivlvl[1] = 1;
            Save.persent[1] = Convert.ToInt32((Save.cionsAll - 100) / 4);
            Save.isachiv[7] = true;
        }
        if (Save.cionsAll >= 500)
        {
            Save.achivlvl[1] = 2;
            Save.persent[1] = Convert.ToInt32((Save.cionsAll - 500) / 20);
            Save.isachiv[8] = true;
        }
        if (Save.cionsAll >= 2500)
        {
            Save.achivlvl[1] = 3;
            Save.persent[1] = Convert.ToInt32((Save.cionsAll - 2500) / 25);
            Save.isachiv[9] = true;
        }
        if (Save.cionsAll >= 5000)
        {
            Save.achivlvl[1] = 4;
            Save.persent[1] = Convert.ToInt32((Save.cionsAll - 5000) / 50);
            Save.isachiv[10] = true;
        }
        if (Save.cionsAll >= 10000)
        {
            Save.achivlvl[1] = 5;
            Save.persent[1] = 100;
            Save.isachiv[11] = true;
        }

        //Miner
        if (Save.stonesAll < 100)
        {
            Save.achivlvl[2] = 0;
            Save.persent[2] = Save.stonesAll;
            Save.isachiv[12] = true;
        }
        if (Save.stonesAll >= 100)
        {
            Save.achivlvl[2] = 1;
            Save.persent[2] = Convert.ToInt32((Save.stonesAll - 100) / 4);
            Save.isachiv[13] = true;
        }
        if (Save.stonesAll >= 500)
        {
            Save.achivlvl[2] = 2;
            Save.persent[2] = Convert.ToInt32((Save.stonesAll - 500) / 20);
            Save.isachiv[14] = true;
        }
        if (Save.stonesAll >= 2500)
        {
            Save.achivlvl[2] = 3;
            Save.persent[2] = Convert.ToInt32((Save.stonesAll - 2500) / 25);
            Save.isachiv[15] = true;
        }
        if (Save.stonesAll >= 5000)
        {
            Save.achivlvl[2] = 4;
            Save.persent[2] = Convert.ToInt32((Save.stonesAll - 5000) / 50);
            Save.isachiv[16] = true;
        }
        if (Save.stonesAll >= 10000)
        {
            Save.achivlvl[2] = 5;
            Save.persent[2] = 100;
            Save.isachiv[17] = true;
        }

        //TownHall
        if (Save.lvlBuildings[0] == 0)
        {
            Save.achivlvl[3] = 0;
            Save.persent[3] = Convert.ToInt32(((Save.lvlBuildings[0] + 1) * 100 / 2));
            Save.isachiv[18] = true;
        }
        else if (Save.lvlBuildings[0] == 1 || Save.lvlBuildings[0] == 2)
        {
            Save.achivlvl[3] = 1;
            Save.persent[3] = Convert.ToInt32(((Save.lvlBuildings[0] - 1) * 100 / 2));
            Save.isachiv[19] = true;
        }
        else if (Save.lvlBuildings[0] == 3 || Save.lvlBuildings[0] == 4)
        {
            Save.achivlvl[3] = 2;
            Save.persent[3] = Convert.ToInt32(((Save.lvlBuildings[0] - 3) * 100 / 2));
            Save.isachiv[20] = true;
        }
        else if (Save.lvlBuildings[0] == 5 || Save.lvlBuildings[0] == 6)
        {
            Save.achivlvl[3] = 3;
            Save.persent[3] = Convert.ToInt32(((Save.lvlBuildings[0] - 5) * 100 / 2));
            Save.isachiv[21] = true;
        }
        else if (Save.lvlBuildings[0] == 7 || Save.lvlBuildings[0] == 8)
        {
            Save.achivlvl[3] = 4;
            Save.persent[3] = Convert.ToInt32(((Save.lvlBuildings[0] - 7) * 100 / 2));
            Save.isachiv[22] = true;
        }
        else if (Save.lvlBuildings[0] == 9)
        {
            Save.achivlvl[3] = 5;
            Save.persent[3] = 100;
            Save.isachiv[23] = true;
        }


        //Stone-pit
        if (Save.lvlBuildings[3] == 0)
        {
            Save.achivlvl[4] = 0;
            Save.persent[4] = Convert.ToInt32(((Save.lvlBuildings[3] + 1) * 100 / 2));
            Save.isachiv[24] = true;
        }
        else if (Save.lvlBuildings[3] == 1 || Save.lvlBuildings[3] == 2)
        {
            Save.achivlvl[4] = 1;
            Save.persent[4] = Convert.ToInt32(((Save.lvlBuildings[3] - 1) * 100 / 2));
            Save.isachiv[25] = true;
        }
        else if (Save.lvlBuildings[3] == 3 || Save.lvlBuildings[3] == 4)
        {
            Save.achivlvl[4] = 2;
            Save.persent[4] = Convert.ToInt32(((Save.lvlBuildings[3] - 3) * 100 / 2));
            Save.isachiv[26] = true;
        }
        else if (Save.lvlBuildings[3] == 5 || Save.lvlBuildings[3] == 6)
        {
            Save.achivlvl[4] = 3;
            Save.persent[4] = Convert.ToInt32(((Save.lvlBuildings[3] - 5) * 100 / 2));
            Save.isachiv[27] = true;
        }
        else if (Save.lvlBuildings[3] == 7 || Save.lvlBuildings[3] == 8)
        {
            Save.achivlvl[4] = 4;
            Save.persent[4] = Convert.ToInt32(((Save.lvlBuildings[3] - 7) * 100 / 2));
            Save.isachiv[28] = true;
        }
        else if (Save.lvlBuildings[3] == 9)
        {
            Save.achivlvl[4] = 5;
            Save.persent[4] = 100;
            Save.isachiv[29] = true;
        }


        //Sawmill
        if (Save.lvlBuildings[1] == 0)
        {
            Save.achivlvl[5] = 0;
            Save.persent[5] = Convert.ToInt32(((Save.lvlBuildings[1] + 1) * 100 / 2));
            Save.isachiv[30] = true;
        }
        else if (Save.lvlBuildings[1] == 1 || Save.lvlBuildings[1] == 2)
        {
            Save.achivlvl[5] = 1;
            Save.persent[5] = Convert.ToInt32(((Save.lvlBuildings[1] - 1) * 100 / 2));
            Save.isachiv[31] = true;
        }
        else if (Save.lvlBuildings[1] == 3 || Save.lvlBuildings[1] == 4)
        {
            Save.achivlvl[5] = 2;
            Save.persent[5] = Convert.ToInt32(((Save.lvlBuildings[1] - 3) * 100 / 2));
            Save.isachiv[32] = true;
        }
        else if (Save.lvlBuildings[1] == 5 || Save.lvlBuildings[1] == 6)
        {
            Save.achivlvl[5] = 3;
            Save.persent[5] = Convert.ToInt32(((Save.lvlBuildings[1] - 5) * 100 / 2));
            Save.isachiv[33] = true;
        }
        else if (Save.lvlBuildings[1] == 7 || Save.lvlBuildings[1] == 8)
        {
            Save.achivlvl[5] = 4;
            Save.persent[5] = Convert.ToInt32(((Save.lvlBuildings[1] - 7) * 100 / 2));
            Save.isachiv[34] = true;
        }
        else if (Save.lvlBuildings[1] == 9)
        {
            Save.achivlvl[5] = 5;
            Save.persent[5] = 100;
            Save.isachiv[35] = true;
        }


        //Adventure's
        if (Save.lvlBuildings[2] == 0)
        {
            Save.achivlvl[6] = 0;
            Save.persent[6] = Convert.ToInt32(((Save.lvlBuildings[2] + 1) * 100 / 2));
            Save.isachiv[36] = true;
        }
        else if (Save.lvlBuildings[2] == 1 || Save.lvlBuildings[2] == 2)
        {
            Save.achivlvl[6] = 1;
            Save.persent[6] = Convert.ToInt32(((Save.lvlBuildings[2] - 1) * 100 / 2));
            Save.isachiv[37] = true;
        }
        else if (Save.lvlBuildings[2] == 3 || Save.lvlBuildings[2] == 4)
        {
            Save.achivlvl[6] = 2;
            Save.persent[6] = Convert.ToInt32(((Save.lvlBuildings[2] - 3) * 100 / 2));
            Save.isachiv[38] = true;
        }
        else if (Save.lvlBuildings[2] == 5 || Save.lvlBuildings[2] == 6)
        {
            Save.achivlvl[6] = 3;
            Save.persent[6] = Convert.ToInt32(((Save.lvlBuildings[2] - 5) * 100 / 2));
            Save.isachiv[39] = true;
        }
        else if (Save.lvlBuildings[2] == 7 || Save.lvlBuildings[2] == 8)
        {
            Save.achivlvl[6] = 4;
            Save.persent[6] = Convert.ToInt32(((Save.lvlBuildings[2] - 7) * 100 / 2));
            Save.isachiv[40] = true;
        }
        else if (Save.lvlBuildings[2] == 9)
        {
            Save.achivlvl[6] = 5;
            Save.persent[6] = 100;
            Save.isachiv[41] = true;
        }


        //exchanger
        if (Save.lvlBuildings[4] == 0)
        {
            Save.achivlvl[7] = 0;
            Save.persent[7] = Convert.ToInt32(((Save.lvlBuildings[1] + 1) * 100 / 2));
            Save.isachiv[42] = true;
        }
        else if (Save.lvlBuildings[4] == 1 || Save.lvlBuildings[4] == 2)
        {
            Save.achivlvl[7] = 1;
            Save.persent[7] = Convert.ToInt32(((Save.lvlBuildings[4] - 1) * 100 / 2));
            Save.isachiv[43] = true;
        }
        else if (Save.lvlBuildings[4] == 3 || Save.lvlBuildings[4] == 4)
        {
            Save.achivlvl[7] = 2;
            Save.persent[7] = Convert.ToInt32(((Save.lvlBuildings[4] - 3) * 100 / 2));
            Save.isachiv[44] = true;
        }
        else if (Save.lvlBuildings[4] == 5 || Save.lvlBuildings[4] == 6)
        {
            Save.achivlvl[7] = 3;
            Save.persent[7] = Convert.ToInt32(((Save.lvlBuildings[4] - 5) * 100 / 2));
            Save.isachiv[45] = true;
        }
        else if (Save.lvlBuildings[4] == 7 || Save.lvlBuildings[4] == 8)
        {
            Save.achivlvl[7] = 4;
            Save.persent[7] = Convert.ToInt32(((Save.lvlBuildings[4] - 7) * 100 / 2));
            Save.isachiv[46] = true;
        }
        else if (Save.lvlBuildings[4] == 9)
        {
            Save.achivlvl[7] = 5;
            Save.persent[7] = 100;
            Save.isachiv[47] = true;
        }


        //Skins craft
        if (Save.lvlBuildings[5] == 0)
        {
            Save.achivlvl[8] = 0;
            Save.persent[8] = Convert.ToInt32(((Save.lvlBuildings[5] + 1) * 100 / 2));
            Save.isachiv[48] = true;
        }
        else if (Save.lvlBuildings[5] == 1 || Save.lvlBuildings[5] == 2)
        {
            Save.achivlvl[8] = 1;
            Save.persent[8] = Convert.ToInt32(((Save.lvlBuildings[5] - 1) * 100 / 2));
            Save.isachiv[49] = true;
        }
        else if (Save.lvlBuildings[5] == 3 || Save.lvlBuildings[5] == 4)
        {
            Save.achivlvl[8] = 2;
            Save.persent[8] = Convert.ToInt32(((Save.lvlBuildings[5] - 3) * 100 / 2));
            Save.isachiv[50] = true;
        }
        else if (Save.lvlBuildings[5] == 5 || Save.lvlBuildings[5] == 6)
        {
            Save.achivlvl[8] = 3;
            Save.persent[8] = Convert.ToInt32(((Save.lvlBuildings[5] - 5) * 100 / 2));
            Save.isachiv[51] = true;
        }
        else if (Save.lvlBuildings[5] == 7 || Save.lvlBuildings[5] == 8)
        {
            Save.achivlvl[8] = 4;
            Save.persent[8] = Convert.ToInt32(((Save.lvlBuildings[5] - 7) * 100 / 2));
            Save.isachiv[52] = true;
        }
        else if (Save.lvlBuildings[5] == 9)
        {
            Save.achivlvl[8] = 5;
            Save.persent[8] = 100;
            Save.isachiv[53] = true;
        }


        //Builder
        if (Save.countlvlbuildings < 12)
        {
            Save.achivlvl[9] = 0;
            Save.persent[9] = Convert.ToInt32((Save.countlvlbuildings * 100 / 12));
            Save.isachiv[54] = true;
        }
        else if (Save.countlvlbuildings >= 12 && Save.countlvlbuildings < 24)
        {
            Save.achivlvl[9] = 1;
            Save.persent[9] = Convert.ToInt32((Save.countlvlbuildings - 12) * 100 / 12);
            Save.isachiv[55] = true;
        }
        else if (Save.countlvlbuildings >= 24 && Save.countlvlbuildings < 36)
        {
            Save.achivlvl[9] = 2;
            Save.persent[9] = Convert.ToInt32((Save.countlvlbuildings - 24) * 100 / 12);
            Save.isachiv[56] = true;
        }
        else if (Save.countlvlbuildings >= 36 && Save.countlvlbuildings < 48)
        {
            Save.achivlvl[9] = 3;
            Save.persent[9] = Convert.ToInt32((Save.countlvlbuildings - 36) * 100 / 12);
            Save.isachiv[57] = true;
        }
        else if (Save.countlvlbuildings >= 48 && Save.countlvlbuildings < 60)
        {
            Save.achivlvl[9] = 4;
            Save.persent[9] = Convert.ToInt32((Save.countlvlbuildings - 48) * 100 / 12);
            Save.isachiv[58] = true;
        }
        else if (Save.countlvlbuildings >= 60)
        {
            Save.achivlvl[9] = 5;
            Save.persent[9] = 100;
            Save.isachiv[59] = true;
        }


        //Trendy
        if (countskins < 3)
        {
            Save.achivlvl[10] = 0;
            Save.persent[10] = Convert.ToInt32(countskins * 100 / 3);
            Save.isachiv[60] = true;
        }
        else if (countskins >= 3 && countskins < 6)
        {
            Save.achivlvl[10] = 1;
            Save.persent[10] = Convert.ToInt32((countskins - 3) * 100 / 3);
            Save.isachiv[61] = true;
        }
        else if (countskins >= 6 && countskins < 9)
        {
            Save.achivlvl[10] = 2;
            Save.persent[10] = Convert.ToInt32((countskins - 6) * 100 / 3);
            Save.isachiv[62] = true;
        }
        else if (countskins >= 9 && countskins < 12)
        {
            Save.achivlvl[10] = 3;
            Save.persent[10] = Convert.ToInt32((countskins - 9) * 100 / 3);
            Save.isachiv[63] = true;
        }
        else if (countskins >= 12 && countskins < 15)
        {
            Save.achivlvl[10] = 4;
            Save.persent[10] = Convert.ToInt32((countskins - 12) * 100 / 3);
            Save.isachiv[64] = true;
        }
        else if (countskins >= 15)
        {
            Save.achivlvl[10] = 5;
            Save.persent[10] = 100;
            Save.isachiv[65] = true;
        }


        //Getter
        int countall = Save.stonesAll + Save.treesAll + Save.cionsAll;
        if (countall < 1000)
        {
            Save.achivlvl[11] = 0;
            Save.persent[11] = Convert.ToInt32(countall / 10);
            Save.isachiv[66] = true;
        }
        if (countall >= 1000)
        {
            Save.achivlvl[11] = 1;
            Save.persent[11] = Convert.ToInt32((countall - 1000) / 15);
            Save.isachiv[67] = true;
        }
        if (countall >= 2500)
        {
            Save.achivlvl[11] = 2;
            Save.persent[11] = Convert.ToInt32((countall - 2500) / 25);
            Save.isachiv[68] = true;
        }
        if (countall >= 5000)
        {
            Save.achivlvl[11] = 3;
            Save.persent[11] = Convert.ToInt32((countall - 5000) / 50);
            Save.isachiv[69] = true;
        }
        if (countall >= 10000)
        {
            Save.achivlvl[11] = 4;
            Save.persent[11] = Convert.ToInt32((countall - 10000) / 150);
            Save.isachiv[70] = true;
        }
        if (countall >= 25000)
        {
            Save.achivlvl[11] = 5;
            Save.persent[11] = 100;
            Save.isachiv[71] = true;
        }


        //produser
        if (Save.countview < 5)
        {
            Save.achivlvl[12] = 0;
            Save.persent[12] = Convert.ToInt32((Save.countview * 100 / 5));
            Save.isachiv[72] = true;
        }
        else if (Save.countview >= 5 && Save.countview < 25)
        {
            Save.achivlvl[12] = 1;
            Save.persent[12] = Convert.ToInt32((Save.countview - 5) * 100 / 20);
            Save.isachiv[73] = true;
        }
        else if (Save.countview >= 25 && Save.countview < 50)
        {
            Save.achivlvl[12] = 2;
            Save.persent[12] = Convert.ToInt32((Save.countview - 25) * 100 / 25);
            Save.isachiv[74] = true;
        }
        else if (Save.countview >= 50 && Save.countview < 100)
        {
            Save.achivlvl[12] = 3;
            Save.persent[12] = Convert.ToInt32((Save.countview - 50) * 100 / 50);
            Save.isachiv[75] = true;
        }
        else if (Save.countview >= 100 && Save.countview < 200)
        {
            Save.achivlvl[12] = 4;
            Save.persent[12] = Convert.ToInt32((Save.countview - 100) * 100 / 100);
            Save.isachiv[76] = true;
        }
        else if (Save.countview >= 200)
        {
            Save.achivlvl[12] = 5;
            Save.persent[12] = 100;
            Save.isachiv[77] = true;
        }



        //Donat
        if (Save.donat < 1)
        {
            Save.achivlvl[13] = 0;
            Save.persent[13] = Convert.ToInt32((Save.donat * 100 / 1));
            Save.isachiv[78] = true;
        }
        if (Save.donat >= 1)
        {
            Save.achivlvl[13] = 1;
            Save.persent[13] = Convert.ToInt32((Save.donat - 1) * 100 / 2);
            Save.isachiv[79] = true;
        }
        if (Save.donat >= 3)
        {
            Save.achivlvl[13] = 2;
            Save.persent[13] = Convert.ToInt32((Save.donat - 3) * 100 / 2);
            Save.isachiv[80] = true;
        }
        if (Save.donat >= 5)
        {
            Save.achivlvl[13] = 3;
            Save.persent[13] = Convert.ToInt32((Save.donat - 5) * 100 / 5);
            Save.isachiv[81] = true;
        }
        if (Save.donat >= 10)
        {
            Save.achivlvl[13] = 4;
            Save.persent[13] = Convert.ToInt32((Save.donat - 10) * 100 / 10);
            Save.isachiv[82] = true;
        }
        if (Save.donat >= 20)
        {
            Save.achivlvl[13] = 5;
            Save.persent[13] = 100;
            Save.isachiv[83] = true;
        }


        //Fun
        if (Save.timeingame[1] < 30)
        {
            Save.achivlvl[14] = 0;
            Save.persent[14] = Convert.ToInt32((Save.timeingame[1] * 100) / 30);
            Save.isachiv[84] = true;
        }
        if (Save.timeingame[2] >= 30)
        {
            Save.achivlvl[14] = 1;
            Save.persent[14] = Convert.ToInt32(((Save.timeingame[1] - 30) * 100) / 30);
            Save.isachiv[85] = true;
        }
        if (Save.timeingame[2] >= 1)
        {
            Save.achivlvl[14] = 2;
            Save.persent[14] = Convert.ToInt32(((Save.timeingame[2] - 1) * 100) / 3);
            Save.isachiv[86] = true;
        }
        if (Save.timeingame[2] >= 3)
        {
            Save.achivlvl[14] = 3;
            Save.persent[14] = Convert.ToInt32(((Save.timeingame[2] - 3) * 100) / 6);
            Save.isachiv[87] = true;
        }
        if (Save.timeingame[2] >= 6)
        {
            Save.achivlvl[14] = 4;
            Save.persent[14] = Convert.ToInt32(((Save.timeingame[2] - 6) * 100) / 12);
            Save.isachiv[88] = true;
        }
        if (Save.timeingame[2] >= 12)
        {
            Save.achivlvl[14] = 5;
            Save.persent[14] = 100;
            Save.isachiv[89] = true;
        }


        //Treider
        if (Save.exchangeAll < 100)
        {
            Save.achivlvl[15] = 0;
            Save.persent[15] = Convert.ToInt32(Save.exchangeAll);
            Save.isachiv[90] = true;
        }
        if (Save.exchangeAll >= 100)
        {
            Save.achivlvl[15] = 1;
            Save.persent[15] = Convert.ToInt32((Save.exchangeAll - 100) / 4);
            Save.isachiv[91] = true;
        }
        if (Save.exchangeAll >= 500)
        {
            Save.achivlvl[15] = 2;
            Save.persent[15] = Convert.ToInt32((Save.exchangeAll - 500) / 5);
            Save.isachiv[92] = true;
        }
        if (Save.exchangeAll >= 1000)
        {
            Save.achivlvl[15] = 3;
            Save.persent[15] = Convert.ToInt32((Save.exchangeAll - 1000) / 15);
            Save.isachiv[93] = true;
        }
        if (Save.exchangeAll >= 2500)
        {
            Save.achivlvl[15] = 4;
            Save.persent[15] = Convert.ToInt32((Save.exchangeAll - 2500) / 25);
            Save.isachiv[94] = true;
        }
        if (Save.exchangeAll >= 5000)
        {
            Save.achivlvl[15] = 5;
            Save.persent[15] = 100;
            Save.isachiv[95] = true;
        }

        for (int i = 0; i < 16; i++)
        {
            switch (Save.achivlvl[i])
            {
                case 0:
                    lvlAchiv[i].sprite = achivImage[i * 5];
                    lvlBord[i].sprite = ramki[0];
                    break;
                case 1:
                    lvlAchiv[i].sprite = achivImage[i * 5 + 1];
                    lvlBord[i].sprite = ramki[1];
                    break;
                case 2:
                    lvlAchiv[i].sprite = achivImage[i * 5 + 2];
                    lvlBord[i].sprite = ramki[2];
                    break;
                case 3:
                    lvlAchiv[i].sprite = achivImage[i * 5 + 3];
                    lvlBord[i].sprite = ramki[3];
                    break;
                case 4:
                    lvlAchiv[i].sprite = achivImage[i * 5 + 4];
                    lvlBord[i].sprite = ramki[4];
                    break;
                case 5:
                    lvlAchiv[i].sprite = achivImage[i * 5 + 4];
                    lvlBord[i].sprite = ramki[5];
                    valuerosent[i].gameObject.SetActive(false);
                    labelProsent[i].gameObject.SetActive(false);
                    break;
            }
            for (int j = 0; j < 6; j++)
            {
                if (Save.isachivgettedreward[j + i * 6])
                {
                    rewardImg[i].SetActive(true);
                    if (Save.islastgettedachiv[j + i * 6])
                    {
                        Save.isachivgettedreward[j + i * 6] = false;
                        rewardImg[i].SetActive(false);
                    }
                }
            }
            labelProsent[i].text = "" + Save.persent[i] + "%";
            valuerosent[i].value = Save.persent[i] / 100;
        }
    }
}
