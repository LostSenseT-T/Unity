using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestControler : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] public Text TimerLabel;
    [SerializeField] public Text[] Progress;
    [SerializeField] public GameObject[] QuestsBoxes;

    DateTime timeToQuest = DateTime.Now.AddHours(24 - DateTime.Now.Hour % 24 - 1).AddMinutes(60 - DateTime.Now.Minute - 1).AddSeconds(60 - DateTime.Now.Second);
    public void Awake()
    {
        DateTime timeToQuest = DateTime.Now.AddHours(24 - DateTime.Now.Hour % 24 - 1).AddMinutes(60 - DateTime.Now.Minute - 1).AddSeconds(60 - DateTime.Now.Second);
        TimeSpan timer = timeToQuest - DateTime.Now;
        TimerLabel.text = timer.Hours.ToString() + ":" + timer.Minutes.ToString() + ":" + timer.Seconds.ToString();
        int chunkH = 24 - DateTime.Parse(PlayerPrefs.GetString("LastSession")).Hour % 24 - 1;
        int chunkM = 60 - DateTime.Parse(PlayerPrefs.GetString("LastSession")).Minute;
        if (DateTime.Now > DateTime.Parse(PlayerPrefs.GetString("LastSession")).AddHours(chunkH).AddMinutes(chunkM))
        {
            Save.countQuest = 4;
            Save.everydayview = 0;
            Save.everydayreklam = 0;
            Save.resourseforquest[0] = 0;
            Save.resourseforquest[1] = 0;
            Save.resourseforquest[2] = 0;
            Save.resourseforquest[3] = 0;
        }
    }
    public void Update()
    {
        if (!Save.giveQuest)
        {
            if (Save.countQuest < 4)
            {
                if (DateTime.Now.Hour == 0)
                {
                    Save.countQuest = 4;
                    Save.giveQuest = true;
                    Save.everydayview = 0;
                    Save.everydayreklam = 0;
                    Save.resourseforquest[0] = 0;
                    Save.resourseforquest[1] = 0;
                    Save.resourseforquest[2] = 0;
                    Save.resourseforquest[3] = 0;
                    PlayerPrefs.SetInt("LastQuestH", DateTime.Now.Hour);
                    PlayerPrefs.SetInt("LastQuestD", DateTime.Now.Day);
                }
            }
        }
        TimeSpan timer = timeToQuest - DateTime.Now;
        TimerLabel.text = timer.Hours.ToString() + ":" + timer.Minutes.ToString() + ":" + timer.Seconds.ToString();
        for (int i = 0; i < QuestsBoxes.Length; i++)
        {
            if (!Save.questgetted[i])
            {
                QuestsBoxes[i].SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("LastQuestH") - DateTime.Now.Hour >= 1 || PlayerPrefs.GetInt("LastQuestD") - DateTime.Now.Day >= 1)
        {
            Save.giveQuest = false;
        }
        int countquestcomplete = 0;
        for (int l = 0; l < 3; l++)
        {
            
            if (Save.resourseforquest[l] >= 1000)
            {
                Save.questcomplete[l] = true;
                Save.resourseforquest[l] = 1000;
                Progress[l].text = "Claim Reward!";
            }
            else
            {
                Progress[l].text = Save.resourseforquest[l] + "/\n1000";
            }
            if (Save.questcomplete[l])
                countquestcomplete++;
            if (countquestcomplete == 3)
            {
                Save.questcomplete[3] = true;
            }
        }
        Progress[3].text = countquestcomplete + "/\n3";

    }
    public void OnApplicationPause(bool pause)
    {
        if (pause)
            PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
    }
    public void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
    }
    public void GetRewardQuest(int id)
    {
        if (Save.questcomplete[id])
        {
            if (id != 3)
            {
                Save.emeralds += 30;
                QuestsBoxes[id].SetActive(false);
                Save.questgetted[id] = true;
            }
            else
            {
                Save.emeralds += 100;
                QuestsBoxes[id].SetActive(false);
                Save.questgetted[id] = true;
            }
        }
    }
}
