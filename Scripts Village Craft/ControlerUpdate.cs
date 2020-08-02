using UnityEngine;
using System;

public class ControlerUpdate : MonoBehaviour
{
    private void Start()
    {
        //day
        if (DateTime.Now.Day > PlayerPrefs.GetInt("LastGetBonuses"))//проверяет наступил новый день или нет
        {
            Save.DayUpdate = false;//апдейт дня завершен, можно брать бонус
        }
        //mounth
        if (Save.MounthUpdate)//апдейт месяца
        {
            if (DateTime.Now.Day == 1)//если 1е число, то кол-во взятых наград = 0 и апдейт месяца запрещен
            {
                Save.countGetted = 0;
                Save.MounthUpdate = false;
            }
        }
        if (DateTime.Now.Day >= 2)//если 2 или больше число апдейт месяца разрешается и произойдет 1го числа
        {
            Save.MounthUpdate = true;
        }
    }
}
