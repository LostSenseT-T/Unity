using System;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;
using GooglePlayGames.BasicApi.SavedGame;

public class CloadSave : MonoBehaviour
{
    private static DateTime startDateTime;
    public static ISavedGameMetadata currentMetadata;
    public static ISavedGameClient savedGameClient;

    private static SaveObj obj = new SaveObj();//создаем обьект класса(см.ниже)
    private static string path;//путь к сохранению, позже будет заменено на клауд сохранение и код снизу немного видо исменится
    public void Awake()//при запуске приложения до старта
    {
        Save.datetimeachiv = DateTime.Now;
#if UNITY_ANDROID && !UNITY_EDITOR//проверка, что это андроид, и не юнити редактор
        path = Path.Combine(Application.persistentDataPath, "Save.json");//путь на андроиде в корневую папку
#else
        path = Path.Combine(Application.dataPath, "Save.json");//путь на компе в корневую папку
#endif
        if (File.Exists(path))//если файл существует
        {
            obj = JsonUtility.FromJson<SaveObj>(File.ReadAllText(path));//распаковываем файл в обьект
            Save.coins = obj.coinsToSave;//возвращаем значения
            Save.logs = obj.logsToSave;
            Save.stone = obj.stonesToSave;
            Save.emeralds = obj.emeraldsToSave;
            Save.lvlBuildings = obj.LvLsToSave;
            Save.DayUpdate = obj.DayUpdateToSave;
            Save.countGetted = obj.countGettedToSave;
            Save.countQuest = obj.countquestToSave;
            Save.giveQuest = obj.giveQuestToSave;
            Save.questcomplete = obj.questcompletesave;
            Save.questgetted = obj.questgettedsave;
            Save.resourseforquest = obj.resourseforquestsave;
            Save.avatarid = obj.skinidToSave;
            Save.achivlvl = obj.achivlvlsave;
            Save.persent = obj.persentsave;
            Save.treesAll = obj.treesAllsave;
            Save.stonesAll = obj.stonesAllsave;
            Save.cionsAll = obj.cionsAllsave;
            Save.countlvlbuildings = obj.countlvlbuildingssave;
            Save.donat = obj.donatsave;
            Save.countview = obj.countviewsave;
            Save.timeingame = obj.timeingamesave;
            Save.exchangeAll = obj.exchangeAllsave;
            Save.achiv1 = obj.achiv1ToSave;
            Save.achiv2 = obj.achiv2ToSave;
            Save.achiv3 = obj.achiv3ToSave;
            Save.achiv4 = obj.achiv4ToSave;
            Save.achiv5 = obj.achiv5ToSave;
            Save.TopScore3inRow = obj.tsMiner;
            Save.TopScoreClicker = obj.tsTimber;
            Save.TopScoreRunner = obj.tsrunner;
            Save.isachiv = obj.isachivsave;
            Save.isachivgetted = obj.isgettedsave;
            Save.chanse = obj.chansetosave;
            Save.rewive = obj.rewivetosave;
            Save.isachivgettedreward = obj.isachivgettedreward;
            Save.islastgettedachiv = obj.islastgettedachiv;
            Save.firstleft = obj.firstleft;
            Save.firstmane = obj.firstmane;
            Save.firstright = obj.firstright;
            Save.everydayview = obj.everydayview;
            Save.everydayreklam = obj.everydayreklam;
            //Save.lvlsNow = obj.lvlsNowToSave;
            Debug.Log("time" + Save.timeingame[2] + ":" + Save.timeingame[1] + ":" + Save.timeingame[0]);
        }

    }

    public static byte[] GetData()
    {
        Save.timeingame[2] = (DateTime.Now - Save.datetimeachiv).Hours + Save.timeingame[2];
        Save.timeingame[1] = (DateTime.Now - Save.datetimeachiv).Minutes + Save.timeingame[1];
        Save.timeingame[0] = (DateTime.Now - Save.datetimeachiv).Seconds + Save.timeingame[0];

        if (Save.timeingame[0] >= 60)
        {
            Save.timeingame[0] = Save.timeingame[0] - 60;
            Save.timeingame[1] += 1;
        }
        if (Save.timeingame[1] >= 60)
        {
            Save.timeingame[1] = Save.timeingame[1] - 60;
            Save.timeingame[2] += 1;
        }
        Debug.Log("time" + Save.timeingame[2] + ":" + Save.timeingame[1] + ":" + Save.timeingame[0]);
        obj.coinsToSave = Save.coins;//загружаем значения в обьект в каждый тик
        obj.logsToSave = Save.logs;
        obj.stonesToSave = Save.stone;
        obj.emeraldsToSave = Save.emeralds;
        obj.LvLsToSave = Save.lvlBuildings;
        obj.countGettedToSave = Save.countGetted;
        obj.DayUpdateToSave = Save.DayUpdate;
        obj.countquestToSave = Save.countQuest;
        obj.giveQuestToSave = Save.giveQuest;
        obj.questcompletesave = Save.questcomplete;
        obj.questgettedsave = Save.questgetted;
        obj.resourseforquestsave = Save.resourseforquest;

        obj.achivlvlsave = Save.achivlvl;
        obj.persentsave = Save.persent;
        obj.treesAllsave = Save.treesAll;
        obj.stonesAllsave = Save.stonesAll;
        obj.cionsAllsave = Save.cionsAll;
        obj.countlvlbuildingssave = Save.countlvlbuildings;
        obj.donatsave = Save.donat;
        obj.countviewsave = Save.countview;
        obj.timeingamesave = Save.timeingame;
        obj.exchangeAllsave = Save.exchangeAll;
        obj.achiv1ToSave = Save.achiv1;
        obj.achiv2ToSave = Save.achiv2;
        obj.achiv3ToSave = Save.achiv3;
        obj.achiv4ToSave = Save.achiv4;
        obj.achiv5ToSave = Save.achiv5;
        obj.isachivsave = Save.isachiv;
        obj.isgettedsave = Save.isachivgetted;

        obj.tsMiner = Save.TopScore3inRow;
        obj.tsTimber = Save.TopScoreClicker;
        obj.tsrunner = Save.TopScoreRunner;
        obj.isachivsave = Save.isachiv;
        obj.isgettedsave = Save.isachivgetted;

        obj.chansetosave = Save.chanse;
        obj.rewivetosave = Save.rewive;
        obj.isachivgettedreward = Save.isachivgettedreward;
        obj.islastgettedachiv = Save.islastgettedachiv;
        obj.firstleft = Save.firstleft;
        obj.firstmane = Save.firstmane;
        obj.firstright = Save.firstright;
        obj.everydayview = Save.everydayview;
        obj.everydayreklam = Save.everydayreklam;
        //obj.lvlsNowToSave = Save.lvlsNow;
        string json = JsonUtility.ToJson(obj);
        byte[] barray = Encoding.UTF8.GetBytes(json);
        return barray;
    }
    public static void LoadData(byte[] data)
    {
        obj = JsonUtility.FromJson<SaveObj>(Encoding.UTF8.GetString(data, 0, data.Length));
        Save.coins = obj.coinsToSave;//возвращаем значения
        Save.logs = obj.logsToSave;
        Save.stone = obj.stonesToSave;
        Save.emeralds = obj.emeraldsToSave;
        Save.lvlBuildings = obj.LvLsToSave;
        Save.DayUpdate = obj.DayUpdateToSave;
        Save.countGetted = obj.countGettedToSave;
        Save.countQuest = obj.countquestToSave;
        Save.giveQuest = obj.giveQuestToSave;
        Save.questcomplete = obj.questcompletesave;
        Save.questgetted = obj.questgettedsave;
        Save.resourseforquest = obj.resourseforquestsave;
        Save.avatarid = obj.skinidToSave;
        Save.achivlvl = obj.achivlvlsave;
        Save.persent = obj.persentsave;
        Save.treesAll = obj.treesAllsave;
        Save.stonesAll = obj.stonesAllsave;
        Save.cionsAll = obj.cionsAllsave;
        Save.countlvlbuildings = obj.countlvlbuildingssave;
        Save.donat = obj.donatsave;
        Save.countview = obj.countviewsave;
        Save.timeingame = obj.timeingamesave;
        Save.exchangeAll = obj.exchangeAllsave;
        Save.achiv1 = obj.achiv1ToSave;
        Save.achiv2 = obj.achiv2ToSave;
        Save.achiv3 = obj.achiv3ToSave;
        Save.achiv4 = obj.achiv4ToSave;
        Save.achiv5 = obj.achiv5ToSave;
        Save.TopScore3inRow = obj.tsMiner;
        Save.TopScoreClicker = obj.tsTimber;
        Save.TopScoreRunner = obj.tsrunner;
        Save.isachiv = obj.isachivsave;
        Save.isachivgetted = obj.isgettedsave;
        Save.chanse = obj.chansetosave;
        Save.rewive = obj.rewivetosave;
        Save.isachivgettedreward = obj.isachivgettedreward;
        Save.islastgettedachiv = obj.islastgettedachiv;
        Save.firstleft = obj.firstleft;
        Save.firstmane = obj.firstmane;
        Save.firstright = obj.firstright;
        Save.everydayview = obj.everydayview;
        Save.everydayreklam = obj.everydayreklam;
        //Save.lvlsNow = obj.lvlsNowToSave;
    }
    public void writeinFileNonStatic()
    {
        Save.timeingame[2] = (DateTime.Now - Save.datetimeachiv).Hours + Save.timeingame[2];
        Save.timeingame[1] = (DateTime.Now - Save.datetimeachiv).Minutes + Save.timeingame[1];
        Save.timeingame[0] = (DateTime.Now - Save.datetimeachiv).Seconds + Save.timeingame[0];
        if (Save.timeingame[0] >= 60)
        {
            Save.timeingame[0] = Save.timeingame[0] - 60;
            Save.timeingame[1] += 1;
        }
        if (Save.timeingame[1] >= 60)
        {
            Save.timeingame[1] = Save.timeingame[1] - 60;
            Save.timeingame[2] += 1;
        }
        Debug.Log("time" + Save.timeingame[2] + ":" + Save.timeingame[1] + ":" + Save.timeingame[0]);
        obj.coinsToSave = Save.coins;//загружаем значения в обьект в каждый тик
        obj.logsToSave = Save.logs;
        obj.stonesToSave = Save.stone;
        obj.emeraldsToSave = Save.emeralds;
        obj.LvLsToSave = Save.lvlBuildings;
        obj.countGettedToSave = Save.countGetted;
        obj.DayUpdateToSave = Save.DayUpdate;
        obj.countquestToSave = Save.countQuest;
        obj.giveQuestToSave = Save.giveQuest;
        obj.questcompletesave = Save.questcomplete;
        obj.questgettedsave = Save.questgetted;
        obj.resourseforquestsave = Save.resourseforquest;

        obj.achivlvlsave = Save.achivlvl;
        obj.persentsave = Save.persent;
        obj.treesAllsave = Save.treesAll;
        obj.stonesAllsave = Save.stonesAll;
        obj.cionsAllsave = Save.cionsAll;
        obj.countlvlbuildingssave = Save.countlvlbuildings;
        obj.donatsave = Save.donat;
        obj.countviewsave = Save.countview;
        obj.timeingamesave = Save.timeingame;
        obj.exchangeAllsave = Save.exchangeAll;
        obj.achiv1ToSave = Save.achiv1;
        obj.achiv2ToSave = Save.achiv2;
        obj.achiv3ToSave = Save.achiv3;
        obj.achiv4ToSave = Save.achiv4;
        obj.achiv5ToSave = Save.achiv5;
        obj.isachivsave = Save.isachiv;
        obj.isgettedsave = Save.isachivgetted;

        obj.tsMiner = Save.TopScore3inRow;
        obj.tsTimber = Save.TopScoreClicker;
        obj.tsrunner = Save.TopScoreRunner;
        obj.isachivsave = Save.isachiv;
        obj.isgettedsave = Save.isachivgetted;

        obj.chansetosave = Save.chanse;
        obj.rewivetosave = Save.rewive;
        obj.isachivgettedreward = Save.isachivgettedreward;
        obj.islastgettedachiv = Save.islastgettedachiv;
        obj.firstleft = Save.firstleft;
        obj.firstmane = Save.firstmane;
        obj.firstright = Save.firstright;
        obj.everydayview = Save.everydayview;
        obj.everydayreklam = Save.everydayreklam;
        //obj.lvlsNowToSave = Save.lvlsNow;
#if UNITY_ANDROID && !UNITY_EDITOR//проверка, что это андроид, и не юнити редактор
        path = Path.Combine(Application.persistentDataPath, "Save.json");//путь на андроиде в корневую папку
#else
        path = Path.Combine(Application.dataPath, "Save.json");//путь на компе в корневую папку
#endif
        File.WriteAllText(path, JsonUtility.ToJson(obj));
    }
    public static void writeinFile()
    {
        Save.timeingame[2] = (DateTime.Now - Save.datetimeachiv).Hours + Save.timeingame[2];
        Save.timeingame[1] = (DateTime.Now - Save.datetimeachiv).Minutes + Save.timeingame[1];
        Save.timeingame[0] = (DateTime.Now - Save.datetimeachiv).Seconds + Save.timeingame[0];
        if (Save.timeingame[0] >= 60)
        {
            Save.timeingame[0] = Save.timeingame[0] - 60;
            Save.timeingame[1] += 1;
        }
        if (Save.timeingame[1] >= 60)
        {
            Save.timeingame[1] = Save.timeingame[1] - 60;
            Save.timeingame[2] += 1;
        }
        Debug.Log("time" + Save.timeingame[2] + ":" + Save.timeingame[1] + ":" + Save.timeingame[0]);
        obj.coinsToSave = Save.coins;//загружаем значения в обьект в каждый тик
        obj.logsToSave = Save.logs;
        obj.stonesToSave = Save.stone;
        obj.emeraldsToSave = Save.emeralds;
        obj.LvLsToSave = Save.lvlBuildings;
        obj.countGettedToSave = Save.countGetted;
        obj.DayUpdateToSave = Save.DayUpdate;
        obj.countquestToSave = Save.countQuest;
        obj.giveQuestToSave = Save.giveQuest;
        obj.questcompletesave = Save.questcomplete;
        obj.questgettedsave = Save.questgetted;
        obj.resourseforquestsave = Save.resourseforquest;

        obj.achivlvlsave = Save.achivlvl;
        obj.persentsave = Save.persent;
        obj.treesAllsave = Save.treesAll;
        obj.stonesAllsave = Save.stonesAll;
        obj.cionsAllsave = Save.cionsAll;
        obj.countlvlbuildingssave = Save.countlvlbuildings;
        obj.donatsave = Save.donat;
        obj.countviewsave = Save.countview;
        obj.timeingamesave = Save.timeingame;
        obj.exchangeAllsave = Save.exchangeAll;
        obj.achiv1ToSave = Save.achiv1;
        obj.achiv2ToSave = Save.achiv2;
        obj.achiv3ToSave = Save.achiv3;
        obj.achiv4ToSave = Save.achiv4;
        obj.achiv5ToSave = Save.achiv5;
        obj.isachivsave = Save.isachiv;
        obj.isgettedsave = Save.isachivgetted;

        obj.tsMiner = Save.TopScore3inRow;
        obj.tsTimber = Save.TopScoreClicker;
        obj.tsrunner = Save.TopScoreRunner;
        obj.isachivsave = Save.isachiv;
        obj.isgettedsave = Save.isachivgetted;

        obj.chansetosave = Save.chanse;
        obj.rewivetosave = Save.rewive;
        obj.isachivgettedreward = Save.isachivgettedreward;
        obj.islastgettedachiv = Save.islastgettedachiv;
        obj.firstleft = Save.firstleft;
        obj.firstmane = Save.firstmane;
        obj.firstright = Save.firstright;
        obj.everydayview = Save.everydayview;
        obj.everydayreklam = Save.everydayreklam;
        //obj.lvlsNowToSave = Save.lvlsNow;
#if UNITY_ANDROID && !UNITY_EDITOR//проверка, что это андроид, и не юнити редактор
        path = Path.Combine(Application.persistentDataPath, "Save.json");//путь на андроиде в корневую папку
#else
        path = Path.Combine(Application.dataPath, "Save.json");//путь на компе в корневую папку
#endif
        File.WriteAllText(path, JsonUtility.ToJson(obj));
    }
    private void OnApplicationPause(bool pause)//сворачивание приложения
    {
        if (pause)//если свернули
        {
            Save.timeingame[2] = (DateTime.Now - Save.datetimeachiv).Hours + Save.timeingame[2];
            Save.timeingame[1] = (DateTime.Now - Save.datetimeachiv).Minutes + Save.timeingame[1];
            Save.timeingame[0] = (DateTime.Now - Save.datetimeachiv).Seconds + Save.timeingame[0];
            if (Save.timeingame[0] >= 60)
            {
                Save.timeingame[0] = Save.timeingame[0] - 60;
                Save.timeingame[1] += 1;
            }
            if (Save.timeingame[1] >= 60)
            {
                Save.timeingame[1] = Save.timeingame[1] - 60;
                Save.timeingame[2] += 1;
            }
            Debug.Log("time" + Save.timeingame[2] + ":" + Save.timeingame[1] + ":" + Save.timeingame[0]);
            obj.coinsToSave = Save.coins;//загружаем значения в обьект в каждый тик
            obj.logsToSave = Save.logs;
            obj.stonesToSave = Save.stone;
            obj.emeraldsToSave = Save.emeralds;
            obj.LvLsToSave = Save.lvlBuildings;
            obj.countGettedToSave = Save.countGetted;
            obj.DayUpdateToSave = Save.DayUpdate;
            obj.countquestToSave = Save.countQuest;
            obj.giveQuestToSave = Save.giveQuest;
            obj.questcompletesave = Save.questcomplete;
            obj.questgettedsave = Save.questgetted;
            obj.resourseforquestsave = Save.resourseforquest;

            obj.achivlvlsave = Save.achivlvl;
            obj.persentsave = Save.persent;
            obj.treesAllsave = Save.treesAll;
            obj.stonesAllsave = Save.stonesAll;
            obj.cionsAllsave = Save.cionsAll;
            obj.countlvlbuildingssave = Save.countlvlbuildings;
            obj.donatsave = Save.donat;
            obj.countviewsave = Save.countview;
            obj.timeingamesave = Save.timeingame;
            obj.exchangeAllsave = Save.exchangeAll;
            obj.achiv1ToSave = Save.achiv1;
            obj.achiv2ToSave = Save.achiv2;
            obj.achiv3ToSave = Save.achiv3;
            obj.achiv4ToSave = Save.achiv4;
            obj.achiv5ToSave = Save.achiv5;
            obj.isachivsave = Save.isachiv;
            obj.isgettedsave = Save.isachivgetted;

            obj.tsMiner = Save.TopScore3inRow;
            obj.tsTimber = Save.TopScoreClicker;
            obj.tsrunner = Save.TopScoreRunner;
            obj.isachivsave = Save.isachiv;
            obj.isgettedsave = Save.isachivgetted;

            obj.chansetosave = Save.chanse;
            obj.rewivetosave = Save.rewive;
            obj.isachivgettedreward = Save.isachivgettedreward;
            obj.islastgettedachiv = Save.islastgettedachiv;
            obj.firstleft = Save.firstleft;
            obj.firstmane = Save.firstmane;
            obj.firstright = Save.firstright;
            obj.everydayview = Save.everydayview;
            obj.everydayreklam = Save.everydayreklam;
            //obj.lvlsNowToSave = Save.lvlsNow;
#if UNITY_ANDROID && !UNITY_EDITOR//проверка, что это андроид, и не юнити редактор
        path = Path.Combine(Application.persistentDataPath, "Save.json");//путь на андроиде в корневую папку
#else
            path = Path.Combine(Application.dataPath, "Save.json");//путь на компе в корневую папку
#endif
            File.WriteAllText(path, JsonUtility.ToJson(obj));//записываем обьект в файл
        }
    }
    private void OnApplicationQuit()//при выходе(компик)
    {
        Save.timeingame[2] = (DateTime.Now - Save.datetimeachiv).Hours + Save.timeingame[2];
        Save.timeingame[1] = (DateTime.Now - Save.datetimeachiv).Minutes + Save.timeingame[1];
        Save.timeingame[0] = (DateTime.Now - Save.datetimeachiv).Seconds + Save.timeingame[0];
        if (Save.timeingame[0] >= 60)
        {
            Save.timeingame[0] = Save.timeingame[0] - 60;
            Save.timeingame[1] += 1;
        }
        if (Save.timeingame[1] >= 60)
        {
            Save.timeingame[1] = Save.timeingame[1] - 60;
            Save.timeingame[2] += 1;
        }
        Debug.Log("time" + Save.timeingame[2] + ":" + Save.timeingame[1] + ":" + Save.timeingame[0]);
        obj.coinsToSave = Save.coins;//загружаем значения в обьект в каждый тик
        obj.logsToSave = Save.logs;
        obj.stonesToSave = Save.stone;
        obj.emeraldsToSave = Save.emeralds;
        obj.LvLsToSave = Save.lvlBuildings;
        obj.countGettedToSave = Save.countGetted;
        obj.DayUpdateToSave = Save.DayUpdate;
        obj.countquestToSave = Save.countQuest;
        obj.giveQuestToSave = Save.giveQuest;
        obj.questcompletesave = Save.questcomplete;
        obj.questgettedsave = Save.questgetted;
        obj.resourseforquestsave = Save.resourseforquest;

        obj.achivlvlsave = Save.achivlvl;
        obj.persentsave = Save.persent;
        obj.treesAllsave = Save.treesAll;
        obj.stonesAllsave = Save.stonesAll;
        obj.cionsAllsave = Save.cionsAll;
        obj.countlvlbuildingssave = Save.countlvlbuildings;
        obj.donatsave = Save.donat;
        obj.countviewsave = Save.countview;
        obj.timeingamesave = Save.timeingame;
        obj.exchangeAllsave = Save.exchangeAll;
        obj.achiv1ToSave = Save.achiv1;
        obj.achiv2ToSave = Save.achiv2;
        obj.achiv3ToSave = Save.achiv3;
        obj.achiv4ToSave = Save.achiv4;
        obj.achiv5ToSave = Save.achiv5;
        obj.isachivsave = Save.isachiv;
        obj.isgettedsave = Save.isachivgetted;

        obj.tsMiner = Save.TopScore3inRow;
        obj.tsTimber = Save.TopScoreClicker;
        obj.tsrunner = Save.TopScoreRunner;
        obj.isachivsave = Save.isachiv;
        obj.isgettedsave = Save.isachivgetted;

        obj.chansetosave = Save.chanse;
        obj.rewivetosave = Save.rewive;
        obj.isachivgettedreward = Save.isachivgettedreward;
        obj.islastgettedachiv = Save.islastgettedachiv;
        obj.firstleft = Save.firstleft;
        obj.firstmane = Save.firstmane;
        obj.firstright = Save.firstright;
        obj.everydayview = Save.everydayview;
        obj.everydayreklam = Save.everydayreklam;
        //obj.lvlsNowToSave = Save.lvlsNow;
#if UNITY_ANDROID && !UNITY_EDITOR//проверка, что это андроид, и не юнити редактор
        path = Path.Combine(Application.persistentDataPath, "Save.json");//путь на андроиде в корневую папку
#else
        path = Path.Combine(Application.dataPath, "Save.json");//путь на компе в корневую папку
#endif
        File.WriteAllText(path, JsonUtility.ToJson(obj));//записываем обьект в файл
        //GPGSManager.WriteSaveData(GetData());
        Save.ManeScene = true;
    }
}

[Serializable]
public class SaveObj//класс сохраняемого обьекта, по факту набор всего, что хотим сохранить
{
    //сохраняемые данные
    public int coinsToSave;
    public int logsToSave;
    public int stonesToSave;
    public int emeraldsToSave;

    public int[] LvLsToSave;

    public int countGettedToSave;
    public bool DayUpdateToSave;

    public int countquestToSave;
    public bool giveQuestToSave;

    public int[] resourseforquestsave;
    public bool[] questcompletesave;
    public bool[] questgettedsave;

    public int skinidToSave;

    public int[] achivlvlsave;
    public float[] persentsave;
    public int treesAllsave;
    public int stonesAllsave;
    public int cionsAllsave;
    public int countlvlbuildingssave;
    public int donatsave;
    public int countviewsave;
    public int[] timeingamesave;
    public int exchangeAllsave;

    public bool achiv1ToSave;
    public bool achiv2ToSave;
    public bool achiv3ToSave;
    public bool achiv4ToSave;
    public bool achiv5ToSave;
    public int tsMiner;
    public int tsrunner;
    public int tsTimber;
    public bool[] isachivsave;
    public bool[] isgettedsave;
    public bool[] isachivgettedreward;
    public bool[] islastgettedachiv;
    public bool rewivetosave;
    public int chansetosave;
    public bool firstmane;
    public bool firstleft;
    public bool firstright;
    public int everydayview;
    public int everydayreklam;
    //public bool[][,] lvlsNowToSave;
}