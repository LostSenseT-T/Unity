using UnityEngine;
using System;
using UnityEngine.UI;

public class ScoreScriptRunner : MonoBehaviour
{

    public static bool playerIsLife = true;
    public Text scoreText;// Переменая, которая позволяет получить доступ к тексту 
    public Text TopscoreText;
    public static float score = 0f;
    public void Start()
    {
        if (Save.rewive)
        {
            Save.rewive = false;
            Save.coins -= Convert.ToInt32(Save.scorerunner * (0.1 * (Save.lvlBuildings[2] + 1) + Save.bonusset[2, Save.choosedskin]));
            Save.scoreclicker = 0;
            Save.score3inRow = 0;
        }
        else
        {
            Save.chanse = 0;
            Save.scorerunner = 0;
            Save.scoreclicker = 0;
            Save.score3inRow = 0;
            score = 0;
        }
        TopscoreText.text = "Top : " + Save.TopScoreRunner;
    }

    void FixedUpdate()
    {
        if (playerIsLife)
        {

            score += 0.02f * Save.bonus;
            scoreText.text = "Coins:" + (int)(score);// вывод времени умноженого на 5
        }
    }
};