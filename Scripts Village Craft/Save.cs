using UnityEngine;
using System;
using System.Collections.Generic;

public class Save : MonoBehaviour
{
    public static bool ManeScene = true;//флажок главной сцены
    public static bool CanSwipe = true;//флажок можно ли свайпать
    public static bool sucsessInit;
    public static bool achiv1;
    public static bool achiv2;
    public static bool achiv3;
    public static bool achiv4;
    public static bool achiv5;
    //resurs
    public static int coins;
    public static int logs;
    public static int stone;
    public static int emeralds;
    //для ежедневного оповещения
    public static int[,] bonuses = new int[4, 31];//бонусы за день, масив ресурсов по факту на каждый из 30 дней
    public static int countGetted;//счет собраный наград
    public static bool MounthUpdate;//флажок, можно ли апдейтить месяц(чтоб залатать дырку с бесконечным взятием бонуса в первый день, при перезапуске) => читать контролер апдейтов
    public static bool DayUpdate;//обновление дня


    public static bool[] avatar = new bool[15];
    public static int avatarid;
    public static bool restartis = false;
    public static DateTime datetimeachiv;

    //TopScore
    public static string nickname = "lost";//никнейм
    public static float score3inRow;
    public static int scorerunner;
    public static int scoreclicker;

    public static int chosedgame;
    public static int bonus = 1;
    public static int lvlvillage;

    public static int TopScoreClicker;
    public static int TopScore3inRow;
    public static int TopScoreRunner;
    //settings громкость и язык
    public static float volume = PlayerPrefs.GetFloat("volume");
    public static float volumegui = PlayerPrefs.GetFloat("volumegui");
    public static string language;

    //buildings
    public static int[] lvlBuildings = { 0, 0, 0, 0, 0, 0 };//уровни здания
    public static int[,] buildingsStats = new int[6, 10];//статы зданий(бонусы)
    public static int[,] costCoins = new int[6, 10];//стоимость апгрейда для каждого здания(монеты)
    public static int[,] costLogs = new int[6, 10];//стоимость апгрейда для каждого здания(бревна)
    public static int[,] costStones = new int[6, 10];//стоимость апгрейда для каждого здания(камни)
    public static string[] NameOfBuildingsEn = { "TownHall", "Sawmill", "Camp", "Stone-pit", "Exchanger", "Forge" };//названия зданий на инглише
    public static string[] NameOfBuildingsRus = { "Ратуша", "Лесопилка", "Приключенская мастерская", "Каменоломня", "Обменник", "Мастерская Скинов" };//название зданий на русском
    public static int SelectedBuild = 0;//выбраное здание(апгрейд и покупка)

    //quest
    public static int countQuest;
    public static bool giveQuest;
    public static int[] resourseforquest = { 0, 0, 0, 0 };
    public static bool[] questcomplete = { false, false, false, false };
    public static bool[] questgetted = { false, false, false, false };

    public static bool bomb;
    public static bool superbomb;
    public static int choosedmap;

    public static bool[] isupedBuilding = { false, false, false, false, false, false };
    //achivload
    public static int[] achivlvl = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public static float[] persent = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public static bool[] isachiv = new bool[96];
    public static bool[] isachivgetted = new bool[96];
    public static bool[] isachivgettedreward = new bool[96];
    public static bool[] islastgettedachiv = new bool[96];
    public static int treesAll;
    public static int stonesAll;
    public static int cionsAll;
    public static int countlvlbuildings;
    public static int donat;
    public static int countview;
    public static int everydayview = 0;
    public static int everydayreklam = 0;
    public static int[] timeingame = { 0, 0, 0 };
    public static int exchangeAll;

    public static int reward = 100;

    public static bool rewive;
    public static int chanse;
    public static Vector3 VectorMainCam = new Vector3(0, 0, -10);

    //skins
    public static int choosedskin = 0;
    public static bool[] skinsBought = new bool[15];
    public static float[,] bonusset = { { 1.5f, 2.5f, 1.5f, 1.5f, 2.5f, 1.5f, 1.5f, 2.5f, 1.5f, 1.5f, 2.5f, 1.5f }, { 1.5f, 2.5f, 1.5f, 1.5f, 2.5f, 1.5f, 1.5f, 2.5f, 1.5f, 1.5f, 2.5f, 1.5f }, { 1.5f, 2.5f, 1.5f, 1.5f, 2.5f, 1.5f, 1.5f, 2.5f, 1.5f, 1.5f, 2.5f, 1.5f } };

    public static bool[][,] lvlsNow = { };

    public static string[] lvlvillagename = { "Outskirts", " Colony", "Village", "Settlement", "Stronghold", "City" };
    public static bool firstmane = true;
    public static bool firstleft = true;
    public static bool firstright = true;
    public static int[] costRespawn = { 10, 10, 25, 50, 100, 250, 500, 1000 };
}