using UnityEngine;
using UnityEngine.UI;
using System;

public class TapController : MonoBehaviour
{
    private string direction; // переменная хранящая название нажатой кнопки
    public TimberMan timberMan;

    private GameManager gameManager;
    public GameObject canvas;
    public GameObject x2bonus;
    public GameObject undeadbonus;
    public GameObject respawntable;
    public GameObject pausetable;
    public GameObject oblochka;
    public Text dethscore;
    public Text isearned;
    public static bool dead = false;
    public Text x2label; 
    public Text x8label;

    private UIController uiController;

    private int bestScore = 0;

    int bonuses = 1;
    int time = 0;
    int time8 = 0;

    spawnbonuses sp = new spawnbonuses();
    public int getScore() // возвращает очки за текущую игру
    {
        return Save.scoreclicker;
    }
    public int getBestScore() // возвращает лучший результат
    {
        return bestScore;
    }

    // меняя этот параметр рушится смерть при обнулении таймера
    private float totalTime = 5.0f; // меняя этот парамент, полоска времени начинает двигатся быстрее
    public float currentTime;
    private bool isGameOver;

    public AudioSource cut;
    public AudioSource shield;
    public AudioSource x2;

    Vector3 startposition;

    void Start()
    {

        startposition = oblochka.transform.position;
        isGameOver = true;

        gameManager = GetComponent<GameManager>();
        uiController = GetComponent<UIController>();
        currentTime = totalTime;
        reset();
    }
    void Update()
    {
        float moveback = Mathf.Repeat(Time.time * 1, 6);
        oblochka.transform.position = startposition + Vector3.left * moveback;
        if (staticer.x2)
        {
            x2bonuses();
            x2.Play();
        }
        if(staticer.x8)
        {
            bonuses8();
            shield.Play();
        }
        if (isGameOver) return;

        currentTime -= Time.deltaTime; // уменьшаем время
        uiController.setProgress(currentTime / totalTime);

        // НА СОПЛЯХ ДЕРЖИТСЯ, НО РАБОТАЕТ (СОВЕТ: НЕ ТРОГАТЬ!!!)
        if (currentTime <= -2.35f)
        {
            GameOver();
        }

    }
    public void Tap(string tap) // проверяем нажимается ли кнопка и даем каждой кнопке любой текст
    {
        if (isGameOver) return;

        if (tap == "LEFT")
        {
            timberMan.changeDirection(tap); // передаем "tap" в "direction"
            timberMan.LeftCutAnimation(); // вызываем анимацию срубки дерева слева
        }
        else if (tap == "RIGHT")
        {
            timberMan.changeDirection(tap); // передаем "tap" в "direction"
            timberMan.RightCutAnimation(); // вызываем анимацию срубки дерева справа
        }

        // работает при падении ветки на голову когда ты со стороны ветки
        if (tap == gameManager.getDirectionFirstTrunk()) // если переменная "tap" == названию чанка на котором мы сейчас находимся
        {
            if (time8 == 0)
                GameOver();
        }
        else // если не проигрываем
        {
            gameManager.cutFirstTrunk(tap); // то рубим дерево (ДОБАВИТЬ В ПАРРАМЕТРЫ МЕТОДА "tap" при наложении анимации на уничтожения дерева)
        }

        // работает при переходе на сторону на которой на против игрока в данный момент находится ветка
        if (tap == gameManager.getDirectionFirstTrunk())
        {
            if(time8==0)
                GameOver();
        }
        else // если не умираем
        {
            cut.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
            cut.Play();
            staticer.bonusdown = true;
            sp.spanw_bonuses(x2bonus, undeadbonus);
            if (time == 0)
            {
                bonuses = 1;
            }
            Save.scoreclicker += 1 * bonuses * Save.bonus; // +1 очко
            uiController.setScore(Save.scoreclicker); // передаем значение очков дальше  

            if (currentTime <= totalTime) // проверка для того чтобы полоса прогресса не уходила дальше чем нужно при хорошей игре
            {
                // ДЛЯ БАФФА МЕНЯТЬ ЭТОТ ПАРАМЕТР, НИ В КОЕМ СЛУЧАЕ НЕ ВРЕМЯ!!!
                currentTime += 0.17f; // добавляем к полоске времени время 
            }
            if (currentTime >= totalTime)
            {
                currentTime = totalTime;
            }
        }
    }
    public void x2bonuses()
    {
        CancelInvoke("Timer");
        staticer.x2 = false;
        bonuses = 2;
        time = 5;
        InvokeRepeating("Timer", 0, 1);
    }
    public void Timer()
    {
        time -= 1;
        x2label.text = "x2";
        if (time == 0)
        {
            x2label.text = "";
            CancelInvoke("Timer");
        }
    }
    public void bonuses8()
    {
        CancelInvoke("Timer8");
        staticer.x8 = false;
        time8 = 5;
        InvokeRepeating("Timer8", 0, 1);
    }
    public void Timer8()
    {
        time8 -= 1;
        x8label.text = "unlim: " + time8;
        if (time8 == 0)
        {
            x8label.text = "";
            CancelInvoke("Timer8");
        }
    }
    public void reset()
    {

        if (Save.rewive)
        {
            Save.rewive = false;
            Save.logs -= Convert.ToInt32(Save.scoreclicker * (0.1 * (Save.lvlBuildings[1] + 1) + Save.bonusset[1, Save.choosedskin]));
            Save.score3inRow = 0;
            Save.scorerunner = 0;
        }
        else
        {
            Save.chanse = 0;
            Save.scoreclicker = 0;
            Save.score3inRow = 0;
            Save.scorerunner = 0;
        }
        isGameOver = false;
        
        uiController.setScore(Save.scoreclicker);

        currentTime = totalTime;
        uiController.setProgress(1);

        timberMan.respawn();
        gameManager.reset();

        canvas.gameObject.SetActive(true);

    }
    public void GameOver()
    {
        dead = true;
        pausetable.SetActive(false);
        canvas.SetActive(false);
        int pr = (int)((((1 + 0.1 * (Save.lvlBuildings[1] + 1)) + (Save.bonusset[1, Save.choosedskin] - 1)) - 1) * 100);
        dethscore.text = "" + Convert.ToInt32(Save.scoreclicker) + "+" + pr + "%";
        if (Save.lvlvillage * 50 >= Convert.ToInt32(Save.scoreclicker))
        {
            isearned.text = "You not earned:" + "\nmin plan : " + (50 * Save.lvlvillage).ToString();
            isearned.color = Color.red;
        }
        isGameOver = true;
        timberMan.Die();

        if (bestScore < Save.scoreclicker)
        {
            bestScore = Save.scoreclicker;
        }
    }
}
