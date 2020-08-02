using UnityEngine;
using System;
using NotificationSamples;//библиотека для оповещений
using UnityEngine.UI;

public class TimeControler : MonoBehaviour
{
    [SerializeField]private GameNotificationsManager notificationManager;//обьявление менеджера для нотификаций
    public GameObject uiTable;//табличка для оповещения о сборе бонуса
    public Text uiLabel;//то же самое
    public GameObject everydaypanel;//панель с бонусами
    private void Start()
    {
        //  InitializationNotification();//инициализация менеджера
        for (int i = 0; i < 4; i++)
            for(int j = 0; j<31;j++)
            {
                if (j != 3)
                {
                    if (j == 6)
                    {
                        Save.bonuses[i, j] = 1000;
                    }
                    else if (j == 13)
                    {
                        Save.bonuses[i, j] = 1500;
                    }
                    else if (j == 20)
                    {
                        Save.bonuses[i, j] = 2000;
                    }
                    else if (j == 27)
                    {
                        Save.bonuses[i, j] = 4000;
                    }
                    else
                    {
                        Save.bonuses[i, j] = (j + 1) * 10;
                    }
                }
                else
                {
                    if (j == 6)
                    {
                        Save.bonuses[i, j] = 100;
                    }
                    else if (j == 13)
                    {
                        Save.bonuses[i, j] = 150;
                    }
                    else if (j == 20)
                    {
                        Save.bonuses[i, j] = 200;
                    }
                    else if (j == 27)
                    {
                        Save.bonuses[i, j] = 400;
                    }
                    else
                    {
                        Save.bonuses[i, j] = 10;
                    }
                }
            }
    }
    private void InitializationNotification()//инициализация менеджера
    {
        //ту не обязательно че-та писать в канале, по факту id и описание
        GameNotificationChannel channel = new GameNotificationChannel("Notification","channel for notification","Трупоеды трупы ели");//канал по которому создаеться оповещение
        notificationManager.Initialize(channel);//инициализируем по каналу менеджер
    }
    public void CreateNotifocation(string title, string body, DateTime delay)//метод создания оповещения(передаться заголовок, описание и время отправления(по желанию картинка, но я не писал)
    {
        IGameNotification notification = notificationManager.CreateNotification();//обьясляем переменную оповещения в менеджере
        if(notification!=null)//если создалось
        {
            notification.Title = title;//заголовок оповещения
            notification.Body = body;//тело оповещени
            notification.DeliveryTime = delay;//DateTime.Now.AddSeconds(3); время отправления
            notificationManager.ScheduleNotification(notification);//Отправка оповещения
        }
    }
    public void CheckTimeEveryDay(int id)//попытка забрать бонус, айди отвечает за кнопку дня, на которую нажали
    {
        if (!Save.DayUpdate)//если день не ушел в обновление
        {
            if (DateTime.Now.Day >= id + 1 && id == Save.countGetted)// если сегодняшняя дата >= чем теоритическая максимальная дата и кнопка, это следующий день, после последнего взятого
            {
                PlayerPrefs.SetInt("LastGetBonuses", DateTime.Now.Day);//сейвим день в который собрали бонус
                Save.countGetted += 1;//обновляем взятую кнопку по порядку
                Save.DayUpdate = true;// день уходит в обновление
                GetBonus(id);//получаем бонусы за ежедневный вход
            }
        }
        else
        {
            everydaypanel.SetActive(false);//выключение таблицы бонусов
            uiTable.SetActive(true);//включение таблички-оповещении
            uiLabel.text = "Return next\nday";
        }
    }
    public void GetBonus(int id)
    {
        everydaypanel.SetActive(false);//выключение таблицы бонусов
        Save.coins += Save.bonuses[0, id];//бонусы
        Save.logs += Save.bonuses[1, id];
        Save.stone += Save.bonuses[2, id];
        Save.emeralds += Save.bonuses[3, id];
        //жесть как выглядит строчка, но по факту сдледующий день в это же время, минус само время(сет часов в 0:00), мб есть реализация лучше, но я не искал особо
        DateTime timeToUpdate = DateTime.Now.AddDays(1).AddHours(-DateTime.Now.Hour+3).AddMinutes(-DateTime.Now.Minute).AddSeconds(-DateTime.Now.Second);
     //   CreateNotifocation("Every day reward!", "Enter the game, and claim it!", timeToUpdate);//обращение к созданию оповещения и агрументы к нему
    }
}

