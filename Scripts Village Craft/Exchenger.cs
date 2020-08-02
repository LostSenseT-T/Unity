using UnityEngine;
using UnityEngine.UI;
using System;

public class Exchenger : MonoBehaviour
{
    public Toggle coinsOld;
    public Toggle stonesOld;
    public Toggle logsOld;
    public Toggle coinsNew;
    public Toggle stonesNew;
    public Toggle logsNew;
    public InputField input;
    public Text labelNewResourse;

    public void Update()
    {
        if (input.text != "")
        {
            if(input.text.Length > 5)
            {
                input.text = "99999";
            }
            int value = Convert.ToInt32(Convert.ToInt32(input.text) * (0.55 + Save.lvlBuildings[4] * 0.05));
            if (value <= 99999)
            {
                labelNewResourse.text = "Will:\n" + value;
            }
        }
        else
        {
            labelNewResourse.text = "Will:\n0";
        }
    }

    private const string achiv3 = "CgkI3uH7rc4YEAIQAw";
    public void exchenge()
    {
        int costvalue = Convert.ToInt32(input.text);
        int value = Convert.ToInt32(Convert.ToInt32(input.text) * (0.55 + Save.lvlBuildings[4] * 0.05));
        if (coinsOld.isOn)
        {
            if (stonesNew.isOn)
            {
                if (Save.coins >= costvalue)
                {
                    Save.stone += value;
                    Save.coins -= costvalue;
                    Save.exchangeAll += value;
                    input.text = "";
                    if (!Save.achiv3)
                    {
                        Save.achiv3 = true;
                        Social.ReportProgress("CgkI3uH7rc4YEAIQAw", 100.0f, (bool sucsess) => { });
                    }
                }
            }
            else if (logsNew.isOn)
            {
                if (Save.coins >= costvalue)
                {
                    Save.logs += value;
                    Save.coins -= costvalue;
                    Save.exchangeAll += value;
                    input.text = "";
                    if (!Save.achiv3)
                    {
                        Save.achiv3 = true;
                        Social.ReportProgress("CgkI3uH7rc4YEAIQAw", 100.0f, (bool sucsess) => { });
                    }
                }
            }
        }
        else if (stonesOld.isOn)
        {
            if (coinsNew.isOn)
            {
                if (Save.stone >= costvalue)
                {
                    Save.coins += value;
                    Save.stone -= costvalue;
                    Save.exchangeAll += value;
                    input.text = "";
                    if (!Save.achiv3)
                    {
                        Save.achiv3 = true;
                        Social.ReportProgress("CgkI3uH7rc4YEAIQAw", 100.0f, (bool sucsess) => { });
                    }
                }
            }
            else if (logsNew.isOn)
            {
                if (Save.stone >= costvalue)
                {
                    Save.logs += value;
                    Save.stone -= costvalue;
                    Save.exchangeAll += value;
                    input.text = "";
                    if (!Save.achiv3)
                    {
                        Save.achiv3 = true;
                        Social.ReportProgress("CgkI3uH7rc4YEAIQAw", 100.0f, (bool sucsess) => { });
                    }
                }
            }
        }
        else if (logsOld.isOn)
        {
            if (coinsNew.isOn)
            {
                if (Save.logs >= costvalue)
                {
                    Save.coins += value;
                    Save.logs -= costvalue;
                    Save.exchangeAll += value;
                    input.text = "";
                    if (!Save.achiv3)
                    {
                        Save.achiv3 = true;
                        Social.ReportProgress("CgkI3uH7rc4YEAIQAw", 100.0f, (bool sucsess) => { });
                    }
                }
            }
            else if (stonesNew.isOn)
            {
                if (Save.logs >= costvalue)
                {
                    Save.stone += value;
                    Save.logs -= costvalue;
                    Save.exchangeAll += value;
                    input.text = "";
                    if (!Save.achiv3)
                    {
                        Save.achiv3 = true;
                        Social.ReportProgress("CgkI3uH7rc4YEAIQAw", 100.0f, (bool sucsess) => { });
                    }
                }
            }
        }
        value = 0;
    }
}
