using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text txtScore; // текстовая переменная для очков
    public Text ToptxtScore;
    public Image progressBar;
    public void Start()
    {
        ToptxtScore.text = "Top : " + Save.TopScoreClicker;
    }
    public void setScore(int value)
    {
        txtScore.text = "Woods: " + value.ToString();
    }
   
    public void setProgress(float value)
    {
        float total = 370f; // общее значение
        float pos = total - (value * total); // расчет перемещения
        // progressBar.transform.localScale = new Vector3(-pos, progressBar.transform.localScale.y, progressBar.transform.localScale.z); // для сжатия progressBar внутрь
        progressBar.transform.localPosition = new Vector3(-pos, progressBar.transform.localPosition.y, progressBar.transform.localPosition.z); // для смешения progressBar влево
    }
    
}
