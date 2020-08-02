using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Net.Mail;
using System.Net;
using GooglePlayGames.BasicApi;
using System.IO;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.Audio;

public class UIScript : MonoBehaviour
{
    //оглавление переменных, в скрипте в юнити чтоб красиво было
    //Основные части интерфейса
    [Header("UI")]
    public AudioMixerGroup mixer;
    [SerializeField] public GameObject Settings;
    [SerializeField] public GameObject Support;
    [SerializeField] public GameObject Upgrade;
    [SerializeField] public GameObject TopRank;
    [SerializeField] public GameObject Market;
    [SerializeField] public GameObject Quest;
    [SerializeField] public GameObject Pause;
    [SerializeField] public GameObject Loding;
    [SerializeField] public GameObject community;
    [SerializeField] public Slider slider;
    [SerializeField] public Slider sliderGui;
    [SerializeField] public GameObject YourTopRank;
    [SerializeField] public GameObject Achivments;
    [SerializeField] public GameObject upTh;
    [SerializeField] public GameObject EveryDay;
    [SerializeField] public Button[] EveryDayButtons;
    [SerializeField] public GameObject exchenger;
    [SerializeField] public GameObject avatar;
    [SerializeField] public GameObject x2plane;
    [SerializeField] public GameObject respawnplane;
    [SerializeField] public GameObject respawnplaneNotFirst;
    [SerializeField] public GameObject x2planeforgame;
    [SerializeField] public GameObject achivplane;
    [SerializeField] public Text achivlabel;
    [SerializeField] public Text CountReklamReward;
    [SerializeField] public Text RewardReklamReward;
    [SerializeField] public Image achivimg;
    [SerializeField] public Sprite[] achivimgmassive;
    [SerializeField] public GameObject skinsmenu;
    [SerializeField] public GameObject gendermenu;
    [SerializeField] public GameObject credits;
    [SerializeField] public GameObject tyforwatching;
    [SerializeField] public GameObject sendmesGoogle;
    [SerializeField] public GameObject[] skinsButton;
    [SerializeField] public Image[] skinsSpriteInShop;
    [SerializeField] public Text respawnGemsLabel;
    [SerializeField] public GameObject upgradeAnim;
    [SerializeField] public RectTransform[] buildingsBox;
    [SerializeField] public Text lvlvillage;
    [SerializeField] public GameObject respawnTimer;
    [SerializeField] public Text textRespawnTimer;
    [SerializeField] public Image imageRespawnTimer;
    [SerializeField] public GameObject respawn;
    [SerializeField] public GameObject Mask;
    [SerializeField] public Sprite[] achivImage;
    [SerializeField] public GameObject[] ReklamButtons;
    [SerializeField] public GameObject ReklamButton;
    [SerializeField] public Text ReklamText;
    [SerializeField] public GameObject ReklamShop;
    public GameObject oblochka;
    public Image[] gameslight;
    public AudioSource button;
    public AudioSource book;
    public AudioSource woodcutter;
    public AudioSource every;
    public AudioSource pause;
    public AudioSource campaudio;
    public AudioSource forgeaudio;
    public AudioSource upgadeaudio;
    public AudioSource achiveaudio;
    //кнопки
    [Header("Buttons")]
    [SerializeField] public GameObject VillageButton;
    [SerializeField] public GameObject FarmButton;
    [SerializeField] public GameObject ProfileButton;
    //строки ресурсов
    [Header("RresourseLabel")]
    [SerializeField] public Text stonesValue;
    [SerializeField] public Text logsValue;
    [SerializeField] public Text coinsValue;
    [SerializeField] public Text emeraldsValue;
    [Header("Mail")]
    [SerializeField] public InputField Teme;
    [SerializeField] public InputField Message;
    //перевод интерфейса(если точне то все строки для определения и сменыт
    [Header("LanguageGui")]
    //settingspanel
    [SerializeField] public Text volumeLabel;
    [SerializeField] public Text supporLabel;
    [SerializeField] public Text languageLabel;
    [SerializeField] public Text communityLabel;
    //supportpanel
    [SerializeField] public Text TemeLabel;
    [SerializeField] public Text MessageLabel;
    [SerializeField] public Text Enter1Label;
    [SerializeField] public Text Enter2Label;
    [SerializeField] public Text sendLabel;
    //updatepanel
    [SerializeField] public Text NameOfBuildingLabel;
    [SerializeField] public Text BeforeUpdateLabel;
    [SerializeField] public Text AfterUpdateLabel;
    [SerializeField] public Text BuyLabel;
    [SerializeField] public Text upTHLabel;
    //toppanel
    [SerializeField] public Text TopOfWorldLabel;
    [SerializeField] public Text YourScoreLabel;
    //pausepanel
    [SerializeField] public Text resumeLabel;
    [SerializeField] public Text restartLabel;
    [SerializeField] public Text homeLabel;
    //marketpanel
    [SerializeField] public Text MarketLabel;
    //questpanel
    [SerializeField] public Text QuestLabel;
    [Header("Camera")]
    [SerializeField] public Camera maincamera;
    [Header("BuildSkins")]
    [SerializeField] public GameObject[] skinsBuild;
    [SerializeField] public Text[] costBuild;
    //leftscreen
    [SerializeField] public Text[] leftSceenLabels;
    [Header("Shop")]
    [SerializeField] public Text EmeraldCountShop;
    [SerializeField] public Text LogsCountShop;
    [SerializeField] public Text CoinsCountShop;
    [SerializeField] public Text StoneCountShop;
    [SerializeField] public GameObject MetsShop;
    [SerializeField] public GameObject GemsShop;
    [Header("EveryDay")]
    [SerializeField] public Sprite SpriteButton;
    [Header("Avatar")]
    [SerializeField] public GameObject[] avatarblock;
    [SerializeField] public Sprite[] avatarSprite;
    [SerializeField] public Image maneAvatar;


    float timeforrespawn = 0;
    //векторы для управления камерой(свайпы) и основной вектор камеры
    Vector2 startToch;
    Vector3 camProfile = new Vector3(-11, 0, -10);
    Vector3 camVillage = new Vector3(0, 0, -10);
    Vector3 camFarm = new Vector3(9, 0, -10);
    private static Vector3 VectorMainCam = new Vector3(0, 0, -10);
    float light = 1;
    public float delta = 0.0000001f;
    public bool NewSwipe = true;//разрешение для нового свайпа(чтоб свайпы не происходили в найстройках и тд)
    private static string path;
    private const string achiv1 = "CgkI3uH7rc4YEAIQAQ";
    private const string achiv2 = "CgkI3uH7rc4YEAIQAg";
    private const string achiv3 = "CgkI3uH7rc4YEAIQAw";
    private const string achiv4 = "CgkI3uH7rc4YEAIQBA";
    private const string achiv5 = "CgkI3uH7rc4YEAIQBQ";

    private const string ldbminer = "CgkI3uH7rc4YEAIQBg";
    private const string ldbrunner = "CgkI3uH7rc4YEAIQBw";
    private const string ldbtimber = "CgkI3uH7rc4YEAIQCA";
#if UNITY_ANDROID
    PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .EnableSavedGames()
            .Build();
#endif
    private void Awake()
    {

#if UNITY_ANDROID
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = false;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((success) => { });
#elif UNITY_IPHONE
        UnityEngine.SocialPlatforms.GameCenter.GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
        Social.localUser.Authenticate((success) => { });
#endif


        Social.ReportScore(Convert.ToInt32(Save.scoreclicker), ldbtimber, (bool sucsess) => { });
        Social.ReportScore(Convert.ToInt32(Save.score3inRow), ldbminer, (bool sucsess) => { });
        Social.ReportScore(Convert.ToInt32(Save.scorerunner), ldbrunner, (bool sucsess) => { });
    }

    Vector3 startposition;
    void Start()
    {
        for (int k = 0; k < 6; k++)
        {
            if (Save.isupedBuilding[k])
            {
                var upgradepref = Instantiate(upgradeAnim);
                upgadeaudio.Play();
                upgradepref.transform.SetParent(buildingsBox[k], false);
                Save.isupedBuilding[k] = false;
            }
        }
        if (Save.ManeScene)
        {
            try
            {
                startposition = oblochka.transform.position;
                maincamera.transform.position = Save.VectorMainCam;
                Save.countlvlbuildings = 0;
                for (int kl = 0; kl < 6; kl++)
                {
                    Save.countlvlbuildings += Save.lvlBuildings[kl] + 1;
                }
                Save.lvlvillage = Save.countlvlbuildings / 12;
                lvlvillage.text = "Village - " + Save.lvlvillagename[Save.lvlvillage] + "\nmin plan : " + (50 * Save.lvlvillage).ToString();
                if (!Save.achiv5)
                {
                    if (Save.countlvlbuildings == 12)
                    {
                        GetAchiv(achiv5);
                        Save.achiv5 = true;
                    }
                }
                if (!Save.achiv1)
                {
                    GetAchiv(achiv1);
                    Save.achiv1 = true;
                }

                for (int i = 0; i < Save.avatar.Length / 2; i++)
                {
                    Save.avatar[i] = true;
                }
                Save.avatar[14] = true;
                maneAvatar.sprite = avatarSprite[Save.avatarid];
                for (int i = 0; i < Save.avatar.Length; i++)
                {
                    if (Save.avatar[i])
                    {
                        avatarblock[i].SetActive(false);
                    }
                }
                //загрузка значений ресурсов в рилайме
                coinsValue.text = Convert.ToString(Save.coins);
                emeraldsValue.text = Convert.ToString(Save.emeralds);
                logsValue.text = Convert.ToString(Save.logs);
                stonesValue.text = Convert.ToString(Save.stone);
                EmeraldCountShop.text = Convert.ToString(Save.emeralds);
                LogsCountShop.text = Convert.ToString(Save.logs);
                CoinsCountShop.text = Convert.ToString(Save.coins);
                StoneCountShop.text = Convert.ToString(Save.stone);
            }
            catch { }
        }
        //generation cost and stats
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (i == 0)
                {
                    Save.buildingsStats[i, j] = (j + 1);
                }
                else if (i == 1 || i == 2 || i == 3)
                {
                    Save.buildingsStats[i, j] = (j + 1) * 10;
                }
                else if (i == 4)
                {
                    Save.buildingsStats[i, j] = 50 + (j + 1) * 5;
                }
                else if (i == 5)
                {
                    Save.buildingsStats[i, j] = (j + 1);
                }
                Save.costCoins[i, j] = j * j * 10 + 100;
                Save.costLogs[i, j] = j * j * 10 + 100;
                Save.costStones[i, j] = j * j * 10 + 100;
            }
        }

        //если включена стартовая сцена(главный экран)
        if (Save.ManeScene)
        {
            try
            {

                // перевот Т.Т самая обезьянья работа из всего проделаного здесь(мб даже не доконца)

                //подгрузка уровней зданий
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        skinsBuild[i * 10 + j].SetActive(false);//выключение всех зданий
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    skinsBuild[i * 10 + Save.lvlBuildings[i]].SetActive(true);//включение только необходимых
                }
                //выключение всех менюшек
                Loding.gameObject.SetActive(false);
                VillageButton.gameObject.SetActive(false);
                //установка громкости

                for (int a = 0; a < 10; a++)
                {
                    if (Save.everydayreklam > a)
                        ReklamButtons[a].SetActive(false);
                }
                ReklamText.text = Save.everydayview.ToString() + "/10";
                if (Save.everydayview >= 10)
                    ReklamButton.SetActive(false);

                Save.volume = PlayerPrefs.GetFloat("volume");
                slider.value = Save.volume;
                Save.volumegui = PlayerPrefs.GetFloat("volumegui");
                sliderGui.value = Save.volumegui;
            }
            catch
            {

                Save.volume = 1;
                slider.value = Save.volume;
                Save.volumegui = 1;
                sliderGui.value = Save.volumegui;

            }
        }
        else
        {
            try
            {
                //если экран игры запущен, ну и перевод для него
                if (Save.language != "rus")
                {
                    resumeLabel.text = "Resume";
                    restartLabel.text = "Restart";
                    homeLabel.text = "Village";
                }
                else
                {
                    resumeLabel.text = "Продолжить";
                    restartLabel.text = "Рестарт";
                    homeLabel.text = "Домой";
                }
                //выключение загрузочного екрана и менбшки паузы
                Loding.gameObject.SetActive(false);
                Pause.gameObject.SetActive(false);
            }
            catch { }
        }
    }
    void achiv_open()
    {
        for (int l = 0; l < Save.isachiv.Length; l++)
        {
            if (Save.isachiv[l])
            {
                if (l % 6 != 0)
                {
                    if (!Save.isachivgetted[l])
                    {
                        int getachiv = l / 6;
                        Save.isachivgetted[l] = true;
                        Save.isachivgettedreward[l] = true;
                        emeraldsValue.text = Convert.ToString(Save.emeralds);
                        achivlabel.text = "take your \n reward!";
                        achivimg.sprite = achivImage[l - 1];
                        achivplane.SetActive(true);
                        achiveaudio.Play();
                    }
                }
            }
        }
    }
    //load resors in real time
    private void Update()
    {
        if (!Save.ManeScene)
        {
            if (PlayerRunner.dead || TapController.dead || Match3.deadP)
            {
                respawnTimer.SetActive(true);
                timeforrespawn = 5;
                PlayerRunner.dead = false;
                TapController.dead = false;
                Match3.deadP = false;
            }
            if (Math.Round(timeforrespawn, 2) == 1 || Math.Round(timeforrespawn, 2) == 2 || Math.Round(timeforrespawn, 2) == 3 || Math.Round(timeforrespawn, 2) == 4 || Math.Round(timeforrespawn, 2) == 5)
            {
                TimerForRespawn(Convert.ToInt32(Math.Round(timeforrespawn, 2)));
            }
            if (timeforrespawn > 0)
            {
                timeforrespawn -= 0.01f;
                imageRespawnTimer.fillAmount = (5 - timeforrespawn) / 5;
            }
            if (timeforrespawn < 0)
            {
                TimerForRespawn(timeforrespawn);
            }
        }
        if (Save.ManeScene)
        {
            Time.timeScale = 1;
            try
            {
                ReklamText.text = Save.everydayview.ToString() + "/10";
                if (Save.everydayview >= 10)
                    ReklamButton.SetActive(false);
                ReklamText.text = Save.countview + "/10";
                float moveback = Mathf.Repeat(Time.time * 1, 5.5f);
                oblochka.transform.position = startposition + Vector3.left * moveback;
                light -= delta;
                gameslight[0].color = new Color(255, 255, 255, light);
                gameslight[1].color = new Color(255, 255, 255, light);
                gameslight[2].color = new Color(255, 255, 255, light);
                if (light < 0.2 || light >= 1)
                    delta = -delta;
                coinsValue.text = Convert.ToString(Save.coins);
                emeraldsValue.text = Convert.ToString(Save.emeralds);
                logsValue.text = Convert.ToString(Save.logs);
                stonesValue.text = Convert.ToString(Save.stone);
                EmeraldCountShop.text = Convert.ToString(Save.emeralds);
                LogsCountShop.text = Convert.ToString(Save.logs);
                CoinsCountShop.text = Convert.ToString(Save.coins);
                StoneCountShop.text = Convert.ToString(Save.stone);
                Save.volume = slider.value;
                PlayerPrefs.SetFloat("volume", Save.volume);
                Save.volumegui = sliderGui.value;
                PlayerPrefs.SetFloat("volumegui", Save.volumegui);
                mixer.audioMixer.SetFloat("GuiVolume", Mathf.Lerp(-80, 0, Save.volumegui));
                mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, Save.volume));

                achiv_open();
            }
            catch
            {
                Save.volume = 1;
                PlayerPrefs.SetFloat("volume", Save.volume);
                Save.volumegui = 1;
                PlayerPrefs.SetFloat("volumegui", Save.volumegui);
                mixer.audioMixer.SetFloat("GuiVolume", Mathf.Lerp(-80,0,Save.volumegui));
                mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, Save.volume));
            }
        }
        //загрузка в сейвы громкости
        //Save.volume = slider.value;
        //изменение позиции камеры плавно
        try
        {
            if (Save.ManeScene)
            {
                maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, VectorMainCam, 0.1f);
            }
            //если мейнскрин и можно сделать новый свайп
            if (Save.ManeScene && NewSwipe)
            {

                if (Input.GetMouseButtonDown(0))//считывание нажатия кнопки мыши
                {
                    startToch = Camera.main.ScreenToWorldPoint(Input.mousePosition);//позиция в которой нажали
                }
                else if (Input.GetMouseButtonUp(0))//считывание отпуска мыши
                {
                    Vector2 endTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);//позиция отпуска мыши
                    Vector2 swipe = endTouch - startToch;//общая протященность свайпа
                    if (Mathf.Abs(swipe.x) > 2)//если больше 2 юнитов то защитать свайп
                    {
                        if (maincamera.transform.position.x > 5)//если сцена миниигр
                        {
                            if (swipe.x > 0)//на сцене миниигр можно только свайпнуть влево
                            {
                                goVillage();//свайп в деревню
                            }
                        }
                        else if (maincamera.transform.position.x < -5)//на сцене профиля можно только свайпнуть вправо
                        {
                            if (swipe.x < 0)
                            {
                                goVillage();//свайп в деревню
                            }
                        }
                        else
                        {
                            if (swipe.x < 0)//проверка куда свайпать
                            {
                                goFarm();//переход нп ферму
                            }
                            else
                            {
                                goProfile();//переход в профиль
                            }
                        }
                    }
                }
            }
            NewSwipe = Save.CanSwipe;//подгрузка разрешения свайпа из класса
        }
        catch { }
    }
    //buttons control
    public void SettingOpen()
    {
        button.Play();
        //открытие настроек, флажок, что свайпать нельзя
        Save.CanSwipe = false;
        Settings.gameObject.SetActive(true);
        community.SetActive(false);
    }
    public void SupportOpen()
    {
        button.Play();
        //открытие окна саппорта, закрытие ностроек
        Save.CanSwipe = false;
        Settings.gameObject.SetActive(false);
        Support.gameObject.SetActive(true);
    }
    public void UpgradeOpen(int id)
    {
        button.Play();
        //окно апгрейда здания, флажок не свайпать
        Save.CanSwipe = false;
        if (Save.lvlBuildings[id] != 9)//проверка на последний уровень здания
        {
            if (Save.language != "rus")//проверка на язык
            {
                Save.SelectedBuild = id;
                if (id == 1)
                {
                    //подгрузка информации в окна//айди здания через которое вызвали апгрейд
                    Upgrade.gameObject.SetActive(true);
                    NameOfBuildingLabel.text = Save.NameOfBuildingsEn[id] + " " + (Save.lvlBuildings[id] + 1).ToString() + "lvl";//имя здания
                    woodcutter.Play();
                    BeforeUpdateLabel.text = "Woods looting up: " + Convert.ToString(Save.buildingsStats[id, Save.lvlBuildings[id]]) + "%";//что сейчас дает(пока окно не вариативное, тк не придуманы до конца баффы и тд)
                    AfterUpdateLabel.text = "Woods looting up: " + Convert.ToString(Save.buildingsStats[id, Save.lvlBuildings[id] + 1]) + "%";//что будет давать позже
                }
                else if (id == 2)
                {
                    //подгрузка информации в окна//айди здания через которое вызвали апгрейд
                    Upgrade.gameObject.SetActive(true);
                    NameOfBuildingLabel.text = Save.NameOfBuildingsEn[id] + " " + (Save.lvlBuildings[id] + 1).ToString() + "lvl";//имя здания
                    campaudio.Play();
                    BeforeUpdateLabel.text = "Coins looting up: " + Convert.ToString(Save.buildingsStats[id, Save.lvlBuildings[id]]) + "%";//что сейчас дает(пока окно не вариативное, тк не придуманы до конца баффы и тд)
                    AfterUpdateLabel.text = "Coins looting up: " + Convert.ToString(Save.buildingsStats[id, Save.lvlBuildings[id] + 1]) + "%";//что будет давать позже
                }
                else if (id == 3)
                {
                    //подгрузка информации в окна//айди здания через которое вызвали апгрейд
                    Upgrade.gameObject.SetActive(true);
                    NameOfBuildingLabel.text = Save.NameOfBuildingsEn[id] + " " + (Save.lvlBuildings[id] + 1).ToString() + "lvl";//имя здания
                    BeforeUpdateLabel.text = "Stones looting up: " + Convert.ToString(Save.buildingsStats[id, Save.lvlBuildings[id]]) + "%";//что сейчас дает(пока окно не вариативное, тк не придуманы до конца баффы и тд)
                    AfterUpdateLabel.text = "Stones looting up: " + Convert.ToString(Save.buildingsStats[id, Save.lvlBuildings[id] + 1]) + "%";//что будет давать позже
                }
                else if (id == 0)
                {
                    Upgrade.gameObject.SetActive(true);
                    NameOfBuildingLabel.text = Save.NameOfBuildingsEn[id] + " " + (Save.lvlBuildings[id] + 1).ToString() + "lvl";//имя здания
                    BeforeUpdateLabel.text = "Max lvl buildings: " + Convert.ToString(Save.buildingsStats[id, Save.lvlBuildings[id]]);//что сейчас дает(пока окно не вариативное, тк не придуманы до конца баффы и тд)
                    AfterUpdateLabel.text = "Max lvl buildings: " + Convert.ToString(Save.buildingsStats[id, Save.lvlBuildings[id] + 1]);//что будет давать позже

                }
                else if (id == 4)
                {
                    Upgrade.gameObject.SetActive(true);
                    NameOfBuildingLabel.text = Save.NameOfBuildingsEn[id] + " " + (Save.lvlBuildings[id] + 1).ToString() + "lvl";//имя здания
                    BeforeUpdateLabel.text = "Exchange rate: " + Convert.ToString(Save.buildingsStats[id, Save.lvlBuildings[id]]) + "%";//что сейчас дает(пока окно не вариативное, тк не придуманы до конца баффы и тд)
                    AfterUpdateLabel.text = "Exchange rate: " + Convert.ToString(Save.buildingsStats[id, Save.lvlBuildings[id] + 1]) + "%";//что будет давать позже

                }
                else if (id == 5)
                {
                    Upgrade.gameObject.SetActive(true);
                    NameOfBuildingLabel.text = Save.NameOfBuildingsEn[id] + " " + (Save.lvlBuildings[id] + 1).ToString() + "lvl";//имя здания
                    forgeaudio.Play();
                    BeforeUpdateLabel.text = "Skins in shop: " + Convert.ToString(Save.buildingsStats[id, Save.lvlBuildings[id]]);//что сейчас дает(пока окно не вариативное, тк не придуманы до конца баффы и тд)
                    AfterUpdateLabel.text = "Skins in shop: " + Convert.ToString(Save.buildingsStats[id, Save.lvlBuildings[id] + 1]);//что будет давать позже

                }
            }
            else
            {
                //подгрузка информации в окна -//-
                Save.SelectedBuild = id;
                Upgrade.gameObject.SetActive(true);
                NameOfBuildingLabel.text = Save.NameOfBuildingsRus[id];
                BeforeUpdateLabel.text = "Увеличение добычи ресурсов: " + Convert.ToString(Save.buildingsStats[id, Save.lvlBuildings[id]]);
                AfterUpdateLabel.text = "Увеличение добычи ресурсов: " + Convert.ToString(Save.buildingsStats[id, Save.lvlBuildings[id] + 1]);
            }
            costBuild[0].text = Convert.ToString(Save.costCoins[id, Save.lvlBuildings[id]]);
            costBuild[1].text = Convert.ToString(Save.costLogs[id, Save.lvlBuildings[id]]);
            costBuild[2].text = Convert.ToString(Save.costStones[id, Save.lvlBuildings[id]]);
        }
        else
        {
            //если максимальный уровень здания закрыть апгрейд и выдать табличку об этом
            Upgrade.SetActive(false);
            upTh.SetActive(true);
            upTHLabel.text = "You rich max lvl";
        }

    }
    public void TopRankOpen()
    {
        button.Play();
        Social.ShowLeaderboardUI();
    }

    public void GogleAchivOpen()
    {
        Social.ShowAchievementsUI();
    }

    public void Close()
    {
        button.Play();
        //закрытие всего на статическом полотне, флажок, что можно свайпать
        Save.CanSwipe = true;
        EveryDay.SetActive(false);
        Settings.gameObject.SetActive(false);
        avatar.SetActive(false);
        Support.gameObject.SetActive(false);
        TopRank.gameObject.SetActive(false);
        exchenger.SetActive(false);
        Mask.SetActive(true);
        Market.SetActive(false);
        Quest.SetActive(false);

    }
    public void goProfile()
    {
        //смена основного вектора камеры и подсветка кнопок
        ProfileButton.gameObject.SetActive(false);
        VillageButton.gameObject.SetActive(true);
        FarmButton.gameObject.SetActive(true);
        Close();
        CloseNotStatic();
        communityClose();
        Save.CanSwipe = true;
        VectorMainCam = camProfile;
        Save.VectorMainCam = camProfile;
    }
    public void goVillage()
    {
        //смена основного вектора камеры и подсветка кнопок
        ProfileButton.gameObject.SetActive(true);
        VillageButton.gameObject.SetActive(false);
        FarmButton.gameObject.SetActive(true);
        Close();
        CloseNotStatic();
        communityClose();
        Save.CanSwipe = true;

        Achivments.SetActive(false);
        VectorMainCam = camVillage;
        Save.VectorMainCam = camVillage;
    }
    public void goFarm()
    {
        //смена основного вектора камеры и подсветка кнопок
        ProfileButton.gameObject.SetActive(true);
        VillageButton.gameObject.SetActive(true);
        FarmButton.gameObject.SetActive(false);
        Close();
        CloseNotStatic();
        communityClose();
        Save.CanSwipe = true;

        Achivments.SetActive(false);//выключение панельки ачивок
        VectorMainCam = camFarm;
        Save.VectorMainCam = camFarm;
    }
    public void goMainScene()
    {

        if (Save.lvlvillage * 50 <= Save.score3inRow)
        {
            Save.stone += Convert.ToInt32(Convert.ToInt32(Save.score3inRow) * (0.1 * (Save.lvlBuildings[3] + 1) + Save.bonusset[0, Save.choosedskin]));
            Save.stonesAll += Convert.ToInt32(Convert.ToInt32(Save.score3inRow) * (0.1 * (Save.lvlBuildings[3] + 1) + Save.bonusset[0, Save.choosedskin]));
            Save.resourseforquest[1] += Convert.ToInt32(Convert.ToInt32(Save.score3inRow) * (0.1 * (Save.lvlBuildings[3] + 1) + Save.bonusset[0, Save.choosedskin]));
        }
        if (Save.lvlvillage * 50 <= Save.scorerunner)
        {
            Save.coins += Convert.ToInt32(Save.scorerunner * (0.1 * (Save.lvlBuildings[2] + 1) + Save.bonusset[2, Save.choosedskin]));
            Save.cionsAll += Convert.ToInt32(Save.scorerunner * (0.1 * (Save.lvlBuildings[2] + 1) + Save.bonusset[2, Save.choosedskin]));
            Save.resourseforquest[2] += Convert.ToInt32(Save.scorerunner * (0.1 * (Save.lvlBuildings[2] + 1) + Save.bonusset[2, Save.choosedskin]));
        }
        if (Save.lvlvillage * 50 <= Save.scoreclicker)
        {
            Save.logs += Convert.ToInt32(Save.scoreclicker * (0.1 * (Save.lvlBuildings[1] + 1) + Save.bonusset[1, Save.choosedskin]));
            Save.treesAll += Convert.ToInt32(Save.scoreclicker * (0.1 * (Save.lvlBuildings[1] + 1) + Save.bonusset[1, Save.choosedskin]));
            Save.resourseforquest[0] += Convert.ToInt32(Save.scoreclicker * (0.1 * (Save.lvlBuildings[1] + 1) + Save.bonusset[1, Save.choosedskin]));
        }
        if (Save.score3inRow > Save.TopScore3inRow)
            Save.TopScore3inRow = (int)Save.score3inRow;
        if (Save.scoreclicker > Save.TopScoreClicker)
            Save.TopScoreClicker = Save.scoreclicker;
        if (Save.scorerunner > Save.TopScoreRunner)
            Save.TopScoreRunner = (int)Save.scorerunner;

        Save.bonus = 1;
        //переход на мейнскрин и подгрузка лодинг скрина до перехода
        Loding.gameObject.SetActive(true);
        Save.ManeScene = true;
        Save.score3inRow = 0;
        Save.score3inRow = 0;
        Save.score3inRow = 0;
        CloadSave.writeinFile();
        Debug.Log("Save");
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
    public void goX2(int id)
    {
        button.Play();
        Save.chosedgame = id;
        x2plane.SetActive(true);
    }
    public void restartx2plane()
    {
        button.Play();
        if (Save.bonus == 2 && !Save.rewive)
        {
            x2planeforgame.SetActive(true);
            Save.bonus = 1;
        }
        else
        {
            x2planeforgame.SetActive(true);

        }
    }
    public void RestartIs()
    {
        Save.restartis = true;
    }
    public void goGameScene(int id)
    {
        button.Play();
        if (!Save.restartis)
        {
            Save.score3inRow = 0;
            Save.scorerunner = 0;
            Save.scoreclicker = 0;
        }
        else
        {
            Save.restartis = false;
        }
        if (Save.bonus == 2 && !Save.rewive)
        {
            x2planeforgame.SetActive(true);
            Save.bonus = 1;
        }
        else
        {
            Save.bonus = id;
            if (0 == Save.chosedgame)
            {
                //рестарт
                if (Save.lvlvillage * 50 <= Save.score3inRow)
                {
                    Save.stone += Convert.ToInt32(Convert.ToInt32(Save.score3inRow) * (0.1 * (Save.lvlBuildings[3] + 1) + Save.bonusset[0, Save.choosedskin]));
                    Save.stonesAll += Convert.ToInt32(Convert.ToInt32(Save.score3inRow) * (0.1 * (Save.lvlBuildings[3] + 1) + Save.bonusset[0, Save.choosedskin]));
                    Save.resourseforquest[1] += Convert.ToInt32(Convert.ToInt32(Save.score3inRow) * (0.1 * (Save.lvlBuildings[3] + 1) + Save.bonusset[0, Save.choosedskin]));
                }

                if (Save.score3inRow > Save.TopScore3inRow)
                    Save.TopScore3inRow = (int)Save.score3inRow;
                //переход на сцену игры и подгрузка лодинг скрина
                Time.timeScale = 1;
                Loding.gameObject.SetActive(true);
                Save.ManeScene = false;
                CloadSave.writeinFile();
                Debug.Log("Save");
                SceneManager.LoadScene("3inRowScene", LoadSceneMode.Single);
            }
            else if (1 == Save.chosedgame)
            {
                //рестарт
                if (Save.lvlvillage * 50 <= Save.scorerunner)
                {
                    Save.coins += Convert.ToInt32(Save.scorerunner * (0.1 * (Save.lvlBuildings[2] + 1) + Save.bonusset[2, Save.choosedskin]));
                    Save.cionsAll += Convert.ToInt32(Save.scorerunner * (0.1 * (Save.lvlBuildings[2] + 1) + Save.bonusset[2, Save.choosedskin]));
                    Save.resourseforquest[2] += Convert.ToInt32(Save.scorerunner * (0.1 * (Save.lvlBuildings[2] + 1) + Save.bonusset[2, Save.choosedskin]));
                }
                if (Save.scorerunner > Save.TopScoreRunner)
                    Save.TopScoreRunner = (int)Save.scorerunner;
                //переход на сцену игры и подгрузка лодинг скрина
                Time.timeScale = 1;
                Loding.gameObject.SetActive(true);
                Save.ManeScene = false;
                CloadSave.writeinFile();
                Debug.Log("Save");
                SceneManager.LoadScene("Runner", LoadSceneMode.Single);
            }
            else if (2 == Save.chosedgame)
            {
                //рестарт
                if (Save.lvlvillage * 50 <= Save.scoreclicker)
                {
                    Save.logs += Convert.ToInt32(Save.scoreclicker * (0.1 * (Save.lvlBuildings[1] + 1) + Save.bonusset[1, Save.choosedskin]));
                    Save.treesAll += Convert.ToInt32(Save.scoreclicker * (0.1 * (Save.lvlBuildings[1] + 1) + Save.bonusset[1, Save.choosedskin]));
                    Save.resourseforquest[0] += Convert.ToInt32(Save.scoreclicker * (0.1 * (Save.lvlBuildings[1] + 1) + Save.bonusset[1, Save.choosedskin]));
                }
                if (Save.scoreclicker > Save.TopScoreClicker)
                    Save.TopScoreClicker = Save.scoreclicker;
                //переход на сцену игры и подгрузка лодинг скрина
                Time.timeScale = 1;
                Loding.gameObject.SetActive(true);
                Save.ManeScene = false;
                CloadSave.writeinFile();
                Debug.Log("Save");
                SceneManager.LoadScene("ClikerScene", LoadSceneMode.Single);
            }
        }
    }
    public void PauseOpen()
    {
        //пауза на сцене игры
        pause.Play();
        Time.timeScale = 0;
        Pause.gameObject.SetActive(true);
    }
    public void PauseClose()
    {
        button.Play();
        //выключение паузы
        Time.timeScale = 1;
        Pause.gameObject.SetActive(false);
    }
    public void Buy()//кнопка покупки на странице апгрейда
    {
        button.Play();
        if (!Save.achiv2)
        {
            GetAchiv(achiv2);
            Save.achiv2 = true;
        }
        //передаеться айди здания
        int id = Save.SelectedBuild;
        if (Save.lvlBuildings[id] < Save.lvlBuildings[0] || id == 0)//проверка на ТХ, если это не ТХ, то проверка на то меньше ли лвл здания, чем ТХ
        {
            //проверка на то хватит ли бабла, рич бич йо мазафака
            if (Save.coins >= Save.costCoins[id, Save.lvlBuildings[id]] && Save.logs >= Save.costLogs[id, Save.lvlBuildings[id]] && Save.stone >= Save.costStones[id, Save.lvlBuildings[id]])
            {
                Save.logs -= Save.costLogs[id, Save.lvlBuildings[id]];//минус бревна
                Save.stone -= Save.costStones[id, Save.lvlBuildings[id]];//минус камни
                Save.coins -= Save.costCoins[id, Save.lvlBuildings[id]];//минус бабки
                coinsValue.text = Convert.ToString(Save.coins);
                emeraldsValue.text = Convert.ToString(Save.emeralds);
                logsValue.text = Convert.ToString(Save.logs);
                stonesValue.text = Convert.ToString(Save.stone);
                Save.lvlBuildings[id] += 1;//плюч жизнь(лвл здания, жизнь то реально минус =)
                Save.isupedBuilding[id] = true;
                if (id == 1 || id == 2 || id == 3)
                {
                    Save.VectorMainCam = new Vector3(9, 0, -10);
                }
                CloadSave.writeinFile();
                Debug.Log("Save");
                SceneManager.LoadScene("MainScene", LoadSceneMode.Single);//перезагрузка сцены
            }
            else
            {
                Upgrade.SetActive(false);
                upTh.SetActive(true);
                upTHLabel.text = "Get more resourses! Sucker";
            }

        }
        else if (Save.lvlBuildings[id] == 9)//проверка на максимальный лвл здания
        {
            //если да то жесть, включаем табличку у вас максимальный уровень здания
            Upgrade.SetActive(false);
            upTh.SetActive(true);
            upTHLabel.text = "You rich max lvl";
        }
        else
        {
            //если нет, то включаем табличку апни тх сначала
            upTHLabel.text = "Raise LvL TH first";
            Upgrade.SetActive(false);
            upTh.SetActive(true);
        }
        Save.CanSwipe = true;
    }
    public void SendMessageToEmail()
    {
        button.Play();
        //отправка сообщения
        if (Teme.text != "" && Message.text != "")//если поля не пусты
        {
            try//пытаемся
            {
                MailMessage mail = new MailMessage();//стандартный класс шарпа, я внатуре не знал
                mail.From = new MailAddress("mectykomanda@gmail.com");//отправляем сообщение от нас
                mail.To.Add(new MailAddress("mectykomanda@gmail.com"));//нам, вот это поворот сообщений
                mail.Subject = Teme.text;//Тема
                mail.Body = Message.text;//Меседж
                SmtpClient client = new SmtpClient();//чета вроде сервиса через который реализуем
                client.Host = "smtp.gmail.com";//ну серв гугла
                client.Port = 587;//открытый порт, честно говоря это юзлес, вряд-ли кто-то захочет перехватить сообщение от поддержи нашей, но это вроде как дает нам защиты
                client.EnableSsl = true;//Включаем подключение ссл, не важно впринцепи, файлы мы не шлем
                client.Credentials = new NetworkCredential("mectykomanda@gmail.com".Split('@')[0], "qwe123rty456");//ну это проверка на безопасность с помощью пароля(гугл на самом деле это блочит, тк регает это как подозрительный вход, но с разрешением в настройках начинает прекрасно работать)
                client.DeliveryMethod = SmtpDeliveryMethod.Network;//метод отправки(интернет конечно же)
                client.Send(mail);//отправка
                mail.Dispose();//удаление мейла из оперативки
                Teme.text = "";//обнуление темы
                Message.text = "";//обнуление меседжа
            }
            catch (Exception e)//ну просто так, все равно все работает
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }
    }
    public void languageEn()
    {
        button.Play();
        //кнопка переключения языка
        if (Save.language != "en")//если и так не выбран инглишь
        {

            Save.CanSwipe = true;
            Save.language = "en";
            CloadSave.writeinFile();
            Debug.Log("Save");
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
    public void languageRus()
    {
        button.Play();
        //кнопка переключения языка
        if (Save.language != "rus")//если и так не выбран русский
        {
            Save.language = "rus";
            Save.CanSwipe = true;
            CloadSave.writeinFile();
            Debug.Log("Save");
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
    public void communityOpen()
    {
        button.Play();
        //открыть окно с соцсетями
        Save.CanSwipe = false;
        community.SetActive(true);
    }
    public void communityClose()
    {
        button.Play();
        //закрыть окно с соцсетями
        community.SetActive(false);
    }
    public void socialNetwork(int id)
    {
        button.Play();
        // свич с айдишкой выбраной соцсети
        switch (id)
        {
            case 0:
                System.Diagnostics.Process.Start("www.bggamestudios.com");
                break;
            case 1:
                System.Diagnostics.Process.Start("www.facebook.com");
                break;
            case 2:
                System.Diagnostics.Process.Start("www.instagram.com");
                break;

        }
    }
    public void MarketOpen()
    {
        //открыть маркет
        button.Play();
        Save.CanSwipe = false;
        Mask.SetActive(false);
        Market.SetActive(true);
    }
    public void QuestOpen()
    {
        //открыть квесты
        button.Play();
        book.Play();
        Save.CanSwipe = false;
        Quest.SetActive(true);
    }
    public void AchivmentsOpen()
    {
        //открыть ачивки
        button.Play();
        Save.CanSwipe = false;
        Achivments.SetActive(true);
    }

    public void CloseNotStatic()
    {
        //закрыть все в окна в статическом канвасе
        button.Play();
        Save.CanSwipe = true;
        achivplane.SetActive(false);
        x2plane.SetActive(false);
        Upgrade.gameObject.SetActive(false);
        skinsmenu.SetActive(false);
        gendermenu.SetActive(false);
        Achivments.SetActive(false);
        upTh.SetActive(false);
        credits.SetActive(false);
        tyforwatching.SetActive(false);
        sendmesGoogle.SetActive(false);
    }
    public void EveryDayOpen()
    {
        //открыть часовню
        button.Play();
        every.Play();
        Save.CanSwipe = false;
        Mask.SetActive(false);
        EveryDay.SetActive(true);
        for (int i = 0; i < EveryDayButtons.Length; i++)
        {
            if (Save.countGetted >= i + 1)
            {
                EveryDayButtons[i].image.color = Color.grey;
            }
        }
    }
    public void ShopSwith(int id)
    {
        button.Play();
        if (id == 0)
        {
            GemsShop.SetActive(true);
            MetsShop.SetActive(false);
            ReklamShop.SetActive(false);
        }
        else if(id == 1)
        {
            GemsShop.SetActive(false);
            MetsShop.SetActive(true);
            ReklamShop.SetActive(false);
        }
        else
        {
            GemsShop.SetActive(false);
            MetsShop.SetActive(false);
            ReklamShop.SetActive(true);
        }
    }
    public void OpenExenger()
    {
        button.Play();
        Save.CanSwipe = false;
        exchenger.SetActive(true);
    }
    public void openAvatar()
    {
        button.Play();
        avatar.SetActive(true);
    }
    public void setAvatar(int id)
    {
        button.Play();
        Save.avatarid = id;
        if (!Save.achiv4)
        {
            GetAchiv(achiv4);
            Save.achiv4 = true;
        }
        maneAvatar.sprite = avatarSprite[Save.avatarid];
    }
    public void skinsMenuopen()
    {
        button.Play();
        skinsmenu.SetActive(true);
        for (int i = 0; i < 9; i++)
        {
            if (i >= Save.lvlBuildings[5])
            {
                skinsButton[i].SetActive(false);
                skinsSpriteInShop[i].color = Color.gray;
            }
            else
            {
                skinsButton[i].SetActive(true);
                skinsSpriteInShop[i].color = Color.white;
            }
        }
        Save.CanSwipe = false;
    }
    public void genderMenuopen()
    {
        button.Play();
        gendermenu.SetActive(true);

        Save.CanSwipe = false;
    }
    public void creditsopen()
    {
        button.Play();
        credits.SetActive(true);
        Save.CanSwipe = false;
    }
    public void Reklama()
    {
        button.Play();
        Save.countview += 1;
    }
    public void ReklamaStart()
    {
        button.Play();
        if (Save.countview < 10)
        {
            Save.countview += 1;
            Save.everydayview += 1;
            goGameScene(2);
        }
        else
        {
            ReklamButton.SetActive(false);
        }
    }
    public void ReklamaForReward()
    {
        switch (Save.everydayreklam)
        { 
            case 0:
                Save.emeralds += 10;
                    break;
            case 1:
                Save.emeralds += 20;
                break;
            case 2:
                Save.emeralds += 30;
                break;
            case 3:
                Save.emeralds += 40;
                break;
            case 4:
                Save.emeralds += 50;
                break;
            case 5:
                Save.emeralds += 60;
                break;
            case 6:
                Save.emeralds += 70;
                break;
            case 7:
                Save.emeralds += 80;
                break;
            case 8:
                Save.emeralds += 90;
                break;
            case 9:
                Save.emeralds += 100;
                break;
        }
        Save.everydayreklam += 1;
        if (Save.everydayreklam <= 9)
        {
            CountReklamReward.text = (Save.everydayreklam) + "/10";
            RewardReklamReward.text = ((Save.everydayreklam+1) * 10).ToString();
        }
        else
        {
            CountReklamReward.text = "10/10";
            RewardReklamReward.text = " ";
        }

    }
    public void respawnbox()
    {
        button.Play();
        respawnTimer.SetActive(false);
        timeforrespawn = 0;
        if (Save.chanse == 0)
        {
            respawnGemsLabel.text = "Gems " + 10;
            respawnplane.SetActive(true);
        }
        else
        {
            if (Save.chanse > 7)
                Save.chanse = 7;
            respawnGemsLabel.text = "Gems " + Save.costRespawn[Save.chanse];
            respawnplaneNotFirst.SetActive(true);
        }
    }
    public void respawnboxclose()
    {
        button.Play();
        respawnplaneNotFirst.SetActive(false);
        respawnplane.SetActive(false);
        respawn.SetActive(true);
    }
    public void respawnReklam()
    {
        button.Play();
        Save.restartis = true;
        Save.rewive = true;
        Save.chanse += 1;
        Save.countview += 1;
        goGameScene(Save.bonus);
    }
    public void respawnGems()
    {
        button.Play();
        Save.restartis = true;
        if (Save.chanse > 7)
            Save.chanse = 7;
        if (Save.emeralds >= Save.costRespawn[Save.chanse] || Save.chanse == 0)
        {
            if (Save.chanse == 0)
            {
                if (Save.emeralds > 10)
                {
                    Save.chanse += 2;
                    Save.rewive = true;
                    Save.emeralds -= Save.costRespawn[Save.chanse];
                    goGameScene(Save.bonus);
                }
            }
            else
            {
                Save.chanse += 1;
                Save.rewive = true;
                Save.emeralds -= Save.costRespawn[Save.chanse];
                goGameScene(Save.bonus);
            }
        }
    }
    public void closegame()
    {
        button.Play();
        respawnplane.SetActive(false);
        respawnplaneNotFirst.SetActive(false);
        x2planeforgame.SetActive(false);
    }
    public void gemsstart()
    {
        button.Play();
        if (Save.emeralds >= 25)
        {
            Save.emeralds -= 25;
            goGameScene(2);
        }
        else
        {
            CloseNotStatic();
            Close();
            MarketOpen();
        }
    }
    public void sendGoogle()
    {
        button.Play();
        Application.OpenURL("market://details?q=pname:com.BGgamestudio.VillageCraft/");
    }
    public void respawnSet()
    {
        button.Play();
        respawnTimer.SetActive(false);
        respawn.SetActive(true);
    }
    public void TimerForRespawn(float id)
    {
        textRespawnTimer.text = id.ToString();
        if (id < 0)
        {
            timeforrespawn = 0;
            respawnTimer.SetActive(false);
            respawn.SetActive(true);
        }
    }
    public void toAchiv()
    {
        button.Play();
        goProfile();
        Achivments.SetActive(true);
    }
    public void GetAchiv(string id)
    {
        if (Save.sucsessInit)
        {
            Social.ReportProgress(id, 100.0f, (bool sucsess) => { });
        }
    }
}
