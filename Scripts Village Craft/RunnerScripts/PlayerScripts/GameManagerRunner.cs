using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRunner : MonoBehaviour
{
    private int timeLight;
    private int timeX2;

    public PlayerRunner pr;

    void Update()
    {
        //if(BonusScriptRunner.bonusLight)
        //{
        //    CancelInvoke("TimerLight");
        //    BonusScriptRunner.bonusLight = false;
        //    timeLight = 5;
        //    LightFlicker.timeOutBonus = true;
        //    InvokeRepeating("TimerLight", 0, 1);
        //}
        if (BonusScriptRunner.x2)
        {
            CancelInvoke("TimerX2");
            BonusScriptRunner.x2 = false;
            timeX2 = 5;
            InvokeRepeating("TimerX2", 0, 1);
        }
    }
    public void Tap()
    {
        pr.Jump();
    }

    //public void TimerLight()
    //{
    //    timeLight -= 1;
    //    if (timeLight == 0)
    //    {
    //        LightFlicker.timeOutBonus = false;
    //        CancelInvoke("TimerLight");
    //    }
    //}

    public void TimerX2()
    {
        PlayerRunner.bonus = 2;

        timeX2 -= 1;

        if (timeX2 == 0)
        {
            PlayerRunner.bonus = 1;
            CancelInvoke("TimerX2");
        }
    }
}
