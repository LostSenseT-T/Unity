using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Match3 : MonoBehaviour
{
    public ArrayLayout boardLayout;
    [Header("UI Elements")]
    public Sprite[] pieces;
    public Sprite[] piecesdead;
    public RectTransform gameBoard;
    public RectTransform killedBoard;
    public RectTransform canvas;
    public Text scoreLabel;
    public Text TopscoreLabel;
    public Text dethscore;
    public Text isearned;
    public GameObject restart;
    public Image[] timerBlock;
    public GameObject pausebutton;
    public Image raketaload;
    public GameObject raketaloadfull;
    public Image gamekilload;
    public GameObject gamekillfull;
    [Header("Prefabs")]
    public GameObject nodePiece;
    public GameObject killedPiece;
    public GameObject expl;
    public GameObject expl1;
    public GameObject raketaanimation;
    public GameObject oblochka;

    public AudioSource swipe;
    public AudioSource boom;
    public AudioSource coins;

    int time = 5;
    int width = 9;
    int height = 14;
    public static bool deadP = false;

    bool nextlvl = false;
    bool verynextlvl = false;

    public int scoreraketaneed = 50;
    public int scoreforkillall = 100;

    Vector3 startposition;

    float scoreraketa = 0;
    float scorekillall = 0;

    int[] fills;
    float alpha = 1f;
    Node[,] board;
    bool wasFlipped;
    List<NodePiece> update;
    List<FlippedPieces> flipped;
    List<NodePiece> dead;
    List<KilledPiece> killed;

    List<bool[,]> lvls = new List<bool[,]> { };
    List<bool[,]> lvls1 = new List<bool[,]> { };
    public static bool[,] lvl1 = // БАЗОВЫЙ +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,false,true,true,true,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl2 = // ДЕРЕВО1 + 
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { true,true,true,true,true,true,true,true,true},
        { true,true,true,false,false,false,true,true,true},
        { true,true,false,false,false,false,false,true,true},
        { true,false,false,false,false,false,false,false,true},
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,true,true},
        { true,true,false,false,false,false,false,false,true},
        { true,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,true},
        { false,false,false,false,false,false,false,true,true},
        { true,true,true,true,false,true,true,true,true},

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl3 = // ДЕРЕВО2 +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,false,true,true,true,true},
        { true,true,true,false,false,false,true,true,true},
        { true,true,false,false,false,false,false,true,true},
        { true,false,false,false,false,false,false,false,true},
        { true,false,false,false,false,false,false,false,true},
        { true,false,false,false,false,false,false,false,true},
        { false,false,false,false,false,false,false,false,false},
        { false,false,false,false,false,false,false,false,false},
        { false,false,false,false,false,false,false,false,false},
        { true,true,true,true,false,true,true,true,true},

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl4 = // ПИКА +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { true,true,true,true,true,true,true,true,true},
        { true,true,true,false,false,false,true,true,true},
        { true,true,false,false,false,false,false,true,true},
        { true,false,false,false,false,false,false,false,true},
        { false,false,false,false,false,false,false,false,false},
        { false,false,false,false,false,false,false,false,false},
        { false,false,false,false,false,false,false,false,false},
        { false,false,false,false,false,false,false,false,false},
        { true,false,false,true,false,true,false,false,true},
        { true,true,true,true,false,true,true,true,true},
        { true,true,true,true,false,true,true,true,true},

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl5 = // СЕРДЕЧКО +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { true,true,true,true,true,true,true,true,true},
        { true,false,false,false,true,false,false,false,true},
        { false,false,false,false,false,false,false,false,false},
        { false,false,false,false,false,false,false,false,false},
        { false,false,false,false,false,false,false,false,false},
        { false,false,false,false,false,false,false,false,false},
        { false,false,false,false,false,false,false,false,false},
        { true,false,false,false,false,false,false,false,true},
        { true,true,false,false,false,false,false,true,true},
        { true,true,true,false,false,false,true,true,true},
        { true,true,true,true,false,true,true,true,true},

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl6 = // БЕЛКА +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { true,true,true,true,true,true,false,true,true},
        { true,true,false,true,false,false,false,true,true},
        { true,false,false,true,false,false,false,false,true},
        { false,false,false,true,false,false,false,false,false },
        { false,false,false,true,true,false,false,false,false },
        { true,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { true,false,false,false,false,false,false,false,false },
        { true,false,false,false,false,false,false,false,true },
        { true,true,false,false,false,false,false,true,true },
        { true,false,false,false,false,true,true,true,true},

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl7 = // КОТ +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,true,true,true,true,false,false,true},
        { false,false,false,true,true,false,false,false,true},
        { false,false,false,false,false,false,false,false,true },
        { false,false,false,false,false,false,false,false,true },
        { false,false,true,false,true,false,false,false,true },
        { false,false,false,true,false,false,false,false,true},
        { false,false,false,false,false,false,false,true,true },
        { true,false,false,false,false,false,false,true,false },
        { true,false,false,false,false,false,false,true,false},
        { true,false,false,false,false,false,false,false,false},
        { true,false,false,false,false,false,false,true,true},

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl8 = // СКИЛЕТ +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,false,true,true,true,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,true,true,false,true,true,false,false },
        { false,false,true,false,false,true,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { true,false,false,true,true,true,false,false,true },
        { true,false,false,false,false,false,false,false,true },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl9 = // ДОМ +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { true,true,true,true,true,true,true,true,true},
        { true,true,true,false,false,false,true,false,true},
        { true,true,false,false,false,false,false,false,true },
        { true,false,false,false,false,false,false,false,true },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,true,true,false,false },
        { false,false,false,false,false,true,true,false,false },
        { false,false,true,true,false,false,false,false,false },
        { false,false,true,true,false,false,false,false,false },
        { false,false,true,true,false,false,false,false,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl10 = // ОСЬМИНОГ +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,false,true,true,true,false,false,false },
        { false,false,false,false,true,true,false,true,false },
        { true,false,true,false,false,true,true,true,false },
        { false,false,false,false,false,true,true,false,false },
        { false,false,false,false,false,true,false,false,true },
        { false,false,false,false,true,true,false,false,true },
        { false,false,false,true,true,true,false,false,false },
        { false,false,false,false,false,true,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl11 = // РОМБ ШИРОКИЙ +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { true,true,true,true,true,true,true,true,true},
        { true,true,true,false,false,false,true,true,true},
        { true,true,false,false,false,false,false,true,true },
        { true,false,false,false,false,false,false,false,true },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { true,false,false,false,false,false,false,false,true},
        { true,true,false,false,false,false,false,true,true},
        { true,true,true,false,false,false,true,true,true},

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl12 = // СЮРИКЕН +
         { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,false,true,true,true,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { true,false,false,false,false,false,false,false,true },
        { true,false,false,false,true,false,false,false,true },
        { true,false,false,false,false,false,false,false,true},
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,true,true,true,false,false,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl13 = // 2 СТОРОНЫ (ВЕРТИКАЛЬ) +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,false,true,true,true,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl14 = // 2 СТОРОНЫ (ГОРИЗОНТАЛЬ) + 
           { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,false,true,true,true,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { true,true,true,true,true,true,true,true,true},
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl15 = // PAC MAN (ВРАГ) +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { true,true,true,true,true,true,true,true,true},
        { true,true,false,false,false,false,false,true,true},
        { true,false,false,false,false,false,false,false,true},
        { false,false,false,false,false,false,false,false,false },
        { false,false,true,true,false,true,true,false,false },
        { false,false,true,false,false,true,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,true,false,true,false,true,false,true,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl16 = // ПЕСОЧНЫЕ ЧАСЫ РОВНО +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,false,true,true,true,false,false,false},
        { false,false,false,false,false,false,false,false,false},
        { false,false,false,false,false,false,false,false,false },
        { true,false,false,false,false,false,false,false,true },
        { true,true,false,false,false,false,false,true,true },
        { true,true,true,false,false,false,true,true,true },
        { true,true,false,false,false,false,false,true,true },
        { true,false,false,false,false,false,false,false,true },
        { false,false,false,false,false,false,false,false,false},
        { false,false,false,false,false,false,false,false,false},
        { false,false,false,false,false,false,false,false,false},

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl17 = // ПЕСОЧНЫЕ ЧАСЫ НА БОКУ +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,true,true,true,true,true,true,true,false },
        { false,false,true,true,true,true,true,false,false },
        { false,false,false,true,true,true,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,true,true,true,false,false,false },
        { false,false,true,true,true,true,true,false,false },
        { false,true,true,true,true,true,true,true,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl18 = // ОГОНЬ +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { true,true,true,true,true,true,true,true,false},
        { true,true,true,true,false,true,true,true,false},
        { true,true,true,true,false,false,true,true,false },
        { true,true,false,true,false,false,false,true,false },
        { true,true,false,false,false,false,false,true,false },
        { false,true,false,false,false,false,false,false,false },
        { false,true,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl19 = // БОМБА (ФИТИЛЬ ВВЕРХУ) +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { true,false,false,true,true,true,true,true,true},
        { false,true,false,false,false,true,true,true,true},
        { true,true,true,false,false,false,true,true,true },
        { true,true,false,false,false,false,false,true,true },
        { true,false,false,false,false,false,false,false,true },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false},
        { true,false,false,false,false,false,false,false,true},
        { true,true,false,false,false,false,false,true,true},

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl20 = // ТРЕУГОЛЬНИК И ПРЯМОУГОЛЬНИК +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,true,true,true,true,false,false,false },
        { false,false,false,true,true,true,false,false,false },
        { false,false,false,false,true,true,false,false,false },
        { false,false,false,false,false,true,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,true,false,false,false },
        { false,false,false,false,true,true,false,false,false },
        { false,false,false,true,true,true,false,false,false },
        { false,false,true,true,true,true,false,false,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl21 = // ТРЕУГОЛЬНИК И ПРЯМОУГОЛЬНИК (ФЛИП) +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,false,true,true,true,true,false,false },
        { false,false,false,true,true,true,false,false,false },
        { false,false,false,true,true,false,false,false,false },
        { false,false,false,true,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,true,false,false,false,false,false },
        { false,false,false,true,true,false,false,false,false },
        { false,false,false,true,true,true,false,false,false },
        { false,false,false,true,true,true,true,false,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl22 = // БОМБА (БОЕГОЛОВКОЙ ВНИЗ) +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,false,true,true,true,false,false,false },
        { true,false,false,false,false,false,false,false,true},
        { true,true,false,false,false,false,false,true,true },
        { true,false,false,false,false,false,false,false,true },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { true,false,false,false,false,false,false,false,true },
        { true,true,false,false,false,false,false,true,true },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl23 = // МОНЕТКА +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { true,true,true,true,true,true,true,true,true},
        { true,true,false,false,false,false,false,true,true },
        { true,false,false,false,false,false,false,false,true },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { true,false,false,false,false,false,false,false,true },
        { true,true,false,false,false,false,false,true,true },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl24 = // МАГНИТ +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { true,true,true,true,true,true,true,true,true},
        { true,true,false,false,false,false,false,true,true },
        { true,false,false,false,false,false,false,false,true },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,true,true,true,false,false,false },
        { false,false,false,true,true,true,false,false,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl25 = // X +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,false,true,true,true,false,false,false },
        { false,false,false,true,true,true,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { true,false,false,false,false,false,false,false,true },
        { true,true,false,false,false,false,false,true,true },
        { true,false,false,false,false,false,false,false,true },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,true,true,true,false,false,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl26 = // ГОРА +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { true,true,true,true,true,true,true,true,true },
        { true,true,true,false,false,false,true,true,true },
        { true,true,true,false,false,false,true,true,true },
        { true,true,false,false,false,false,false,true,true },
        { true,true,false,false,false,false,false,true,true },
        { true,false,false,false,false,false,false,false,true },
        { true,false,false,false,false,false,false,false,true },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl27 = // ПАКЕТ С ДЫРКОЙ +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,false,true,true,true,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,true,true,true,false,false,false },
        { false,false,false,false,true,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl28 = // ПЕРЕВЕРНУТАЯ ГОРА +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,false,true,true,true,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,false },
        { true,false,false,false,false,false,false,false,true },
        { true,false,false,false,false,false,false,false,true },
        { true,true,false,false,false,false,false,true,true },
        { true,true,false,false,false,false,false,true,true },
        { true,true,true,false,false,false,true,true,true },
        { true,true,true,false,false,false,true,true,true },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl29 = // ЗИГЗАГ +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { false,false,false,true,true,true,false,false,true },
        { true,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,true },
        { true,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,true },
        { true,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,true },
        { true,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,true },
        { true,false,false,false,false,false,false,false,false },
        { false,false,false,false,false,false,false,false,true },

        { true,true,true,true,true,true,true,true,true} };
    public static bool[,] lvl30 = // ЖУК +
          { { true,true,true,true,true,true,true,true,true},
        { true,true,true,true,true,true,true,true,true},

        { true,true,false,true,true,true,false,true,true },
        { true,true,true,false,false,false,true,true,true },
        { false,true,false,false,false,false,false,true,false },
        { true,false,false,false,false,false,false,false,true },
        { false,false,false,false,false,false,false,false,false },
        { true,false,false,false,false,false,false,false,true },
        { false,false,false,false,false,false,false,false,false },
        { true,false,false,false,false,false,false,false,true },
        { false,false,false,false,false,false,false,false,false },
        { true,true,false,false,false,false,false,true,true },
        { true,false,true,false,false,false,true,false,true },

        { true,true,true,true,true,true,true,true,true} };
    System.Random random;
    public void raketa()
    {
        boom.Play();
        coins.Play();
        int z = 14;
        Point point = new Point(random.Next(0, 9), 0);
        int raketax = (point.x - 4);
        Vector3 v = new Vector3(-32 + raketax * 64, -650);
        if (scoreraketa >= scoreraketaneed - 1)
        {
            var rocketpref = Instantiate(raketaanimation, v, Quaternion.identity);
            rocketpref.transform.SetParent(gameBoard, false);
            for (int i = 0; i < 14; i++)
            {
                point.y = i;
                if (getValueAtPoint(point) != -1)
                {
                    try
                    {
                        KillPiece(point);

                        Node node = getNodeAtPoint(point);
                        NodePiece nodePiece = node.getPiece();

                        if (nodePiece != null)
                        {
                            nodePiece.gameObject.SetActive(false);
                            dead.Add(nodePiece);
                        }
                        node.SetPiece(null);
                    }
                    catch { z--; }
                }
            }
            Save.score3inRow += z * 0.4f * Save.bonus;
            scoreraketa += z * 0.4f;
            scorekillall += z * 0.4f;
            if (scorekillall / scoreforkillall < 1)
            {
                gamekilload.fillAmount = scorekillall / scoreforkillall;
            }
            else
            {
                gamekilload.fillAmount = 1;
                gamekillfull.SetActive(true);
            }
            time = 5;
            for (int k = 0; k < 5; k++)
            {
                timerBlock[k].color = Color.white * 1f;
            }
            ApplyGravityToBoard();
            Debug.Log("score" + scoreraketa);
            scoreraketa = 0;
            scoreLabel.text = "Stone : " + Convert.ToInt32(Save.score3inRow);
            //
            raketaload.fillAmount = 0;
            raketaloadfull.SetActive(false);
        }
    }
    void Start()
    {
        startposition = oblochka.transform.position;
        lvls.Add(lvl1);
        lvls.Add(lvl2);
        lvls.Add(lvl3);
        lvls.Add(lvl4);
        lvls.Add(lvl5);
        lvls.Add(lvl6);
        lvls.Add(lvl7);
        lvls.Add(lvl8);
        lvls.Add(lvl9);
        lvls.Add(lvl10);
        lvls.Add(lvl11);
        lvls.Add(lvl12);
        lvls.Add(lvl13);
        lvls.Add(lvl14);
        lvls.Add(lvl15);
        lvls.Add(lvl16);
        lvls.Add(lvl17);
        lvls.Add(lvl18);
        lvls.Add(lvl19);
        lvls.Add(lvl20);
        lvls.Add(lvl21);
        lvls.Add(lvl22);
        lvls.Add(lvl23);
        lvls.Add(lvl24);
        lvls.Add(lvl25);
        lvls.Add(lvl26);
        lvls.Add(lvl27);
        lvls.Add(lvl28);
        lvls.Add(lvl29);
        lvls.Add(lvl30);
        lvls1 = lvls;
        if (Save.lvlsNow.Length == 0)
        {
            Save.lvlsNow = lvls.ToArray();
            Debug.Log("==0");
        }
        raketaload.fillAmount = 0;
        gamekilload.fillAmount = 0;
        int ind = UnityEngine.Random.Range(0, Save.lvlsNow.Length);
        if (Save.rewive)
        {
            Save.rewive = false;
            Save.stone -= Convert.ToInt32((int)Save.score3inRow * (0.1 * (Save.lvlBuildings[3] + 1) + Save.bonusset[0, Save.choosedskin]));
            Save.scorerunner = 0;
            Save.scoreclicker = 0;
            ind = Save.choosedmap;
            bool[][,] lvlsNow = lvls1.ToArray();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    boardLayout.rows[j].row[i] = lvlsNow[ind][j, i];
                }
            }
        }
        else
        {
            Save.chanse = 0;
            Save.score3inRow = 0;
            Save.scorerunner = 0;
            Save.scoreclicker = 0;
            Save.choosedmap = ind;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    boardLayout.rows[j].row[i] = Save.lvlsNow[ind][j, i];
                }
            }
            Array.Clear(Save.lvlsNow, Save.choosedmap, 1);
            Save.lvlsNow[Save.choosedmap] = Save.lvlsNow[Save.lvlsNow.Length - 1];
            Array.Resize(ref Save.lvlsNow, Save.lvlsNow.Length - 1);
        }
        Time.timeScale = 1;

        scoreLabel.text = "Stone : " + Convert.ToInt32(Save.score3inRow);
        TopscoreLabel.text = "Top : " + Save.TopScore3inRow;
        InvokeRepeating("Timer", 0, 1);
        itsall = false;
        StartGame();
    }
    void Timer()
    {
        if (Time.timeScale != 0)
        {
            time -= 1;
            alpha = 1f;
        }
    }
    bool itsall = false;
    void Update()
    {
        float moveback = Mathf.Repeat(Time.time * 1, 5.5f);
        oblochka.transform.position = startposition + Vector3.left * moveback;
        if (time < 0&&!itsall)
        {
            Time.timeScale = 0;
            pausebutton.SetActive(false);
            deadP = true;
            int pr = (int)((((1 + 0.1 * (Save.lvlBuildings[0]+1)) + (Save.bonusset[0, Save.choosedskin] - 1)) - 1) * 100);
            dethscore.text = "" + Convert.ToInt32(Save.score3inRow) + "+" + pr + "%";
            if(Save.lvlvillage * 50 >= Convert.ToInt32(Save.score3inRow))
            {
                isearned.text = "You not earned:" + "\nmin plan : " + (50 * Save.lvlvillage).ToString();
                isearned.color = Color.red;
            }
            itsall = true;
        }
        if (alpha > 0)
        {
            alpha -= 0.03f;
        }
        if (Save.score3inRow > 100 && !nextlvl)
        {
            CancelInvoke("Timer");
            InvokeRepeating("Timer", 0, 0.8f);
            nextlvl = true;
        }
        else if (Save.score3inRow > 300 && !verynextlvl)
        {
            CancelInvoke("Timer");
            InvokeRepeating("Timer", 0, 0.6f);
            verynextlvl = true;
        }
        if (time < 5 && time >= 0)
        {
            timerBlock[time].color = new Color(255, 255, 255, alpha);
        }
        List<NodePiece> finishedUpdating = new List<NodePiece>();

        for (int i = 0; i < update.Count; i++)
        {
            NodePiece piece = update[i];

            if (!piece.UpdatePiece())
            {
                finishedUpdating.Add(piece);
            }
        }

        for (int i = 0; i < finishedUpdating.Count; i++)
        {
            NodePiece piece = finishedUpdating[i];
            FlippedPieces flip = getFlipped(piece);

            NodePiece flippedPiece = null;

            int x = (int)piece.index.x;
            fills[x] = Mathf.Clamp(fills[x] - 1, 0, width);

            List<Point> connected = isConnected(piece.index, true);

            wasFlipped = (flip != null);

            if (wasFlipped)
            {
                flippedPiece = flip.getOtherPiece(piece);
                AddPoints(ref connected, isConnected(flippedPiece.index, true));
            }

            if (connected.Count == 0)
            {
                if (wasFlipped)
                {
                    FlipPieces(piece.index, flippedPiece.index, false);
                }
            }
            else
            {
                if (connected.Count >= 3 && connected.Count <= 4)
                {
                    Save.score3inRow += connected.Count * 0.2f * Save.bonus;
                    scoreraketa += connected.Count * 0.2f;
                    scorekillall += connected.Count * 0.2f;
                }
                else if (connected.Count >= 5 && connected.Count <= 6)
                {
                    Save.score3inRow += connected.Count * 0.3f * Save.bonus;
                    scoreraketa += connected.Count * 0.3f;
                    scorekillall += connected.Count * 0.3f;
                    Save.bomb = true;
                }
                else if (connected.Count >= 7)
                {
                    Save.score3inRow += connected.Count * 0.4f * Save.bonus;
                    scoreraketa += connected.Count * 0.4f;
                    scorekillall += connected.Count * 0.4f;
                    Save.superbomb = true;
                }
                time = 5;
                for (int k = 0; k < 5; k++)
                {
                    timerBlock[k].color = Color.white * 1f;
                }
                scoreLabel.text = "Stone : " + Convert.ToInt32(Save.score3inRow);

                if (scorekillall / scoreforkillall < 1)
                {
                    gamekilload.fillAmount = scorekillall / scoreforkillall;
                }
                else
                {
                    gamekilload.fillAmount = 1;
                    gamekillfull.SetActive(true);
                }

                if (scoreraketa / scoreraketaneed < 1)
                {
                    raketaload.fillAmount = scoreraketa / scoreraketaneed;
                }
                else
                {
                    raketaload.fillAmount = 1;
                    raketaloadfull.SetActive(true);
                }

                if (scoreraketa / scoreraketaneed < 1)
                {
                    raketaload.fillAmount = scoreraketa / scoreraketaneed;
                }
                else
                {
                    raketaload.fillAmount = 1;
                    raketaloadfull.SetActive(true);
                }
                coins.Play();
                foreach (Point pnt in connected)
                {
                    KillPiece(pnt);

                    Node node = getNodeAtPoint(pnt);
                    NodePiece nodePiece = node.getPiece();

                    if (nodePiece != null)
                    {
                        nodePiece.gameObject.SetActive(false);
                        dead.Add(nodePiece);
                    }
                    node.SetPiece(null);
                }

                ApplyGravityToBoard();
            }

            flipped.Remove(flip);
            update.Remove(piece);
        }
    }
    public void killall()
    {
        gamekilload.fillAmount = 0;
        scorekillall = 0;
        gamekillfull.SetActive(false);
        Point p = new Point(5, 5);
        bombExplose(p, 20);
    }
    public void bombExplose(Point point, int range)
    {

        boom.Play();
        coins.Play();
        Point p = new Point(point.x - Convert.ToInt32(range / 2), point.y - Convert.ToInt32(range / 2));
        int z = range * range;
        for (int i = 0; i < range; i++)
        {
            for (int j = 0; j < range; j++)
            {
                point.x = p.x + i;
                point.y = p.y + j;
                if (getValueAtPoint(point) != -1)
                {
                    try
                    {
                        KillPiece(point);

                        Node node = getNodeAtPoint(point);
                        NodePiece nodePiece = node.getPiece();

                        if (nodePiece != null)
                        {
                            nodePiece.gameObject.SetActive(false);
                            dead.Add(nodePiece);
                        }
                        node.SetPiece(null);
                    }
                    catch { z--; }
                }
            }
        }
        //Instantiate(expl, transform.position, Quaternion.identity);
        Save.score3inRow += z * 0.4f * Save.bonus;
        if (range < 6)
        {
            scoreraketa += z * 0.4f;
            scorekillall += z * 0.4f;
        }
        scoreLabel.text = "Stone : " + Convert.ToInt32(Save.score3inRow);
        if (scoreraketa / scoreraketaneed < 1)
        {
            raketaload.fillAmount = scoreraketa / scoreraketaneed;
        }
        else
        {
            raketaload.fillAmount = 1;
            raketaloadfull.SetActive(true);
        }

        if (scorekillall / scoreforkillall < 1)
        {
            gamekilload.fillAmount = scorekillall / scoreforkillall;
        }
        else
        {
            gamekilload.fillAmount = 1;
            gamekillfull.SetActive(true);
        }
        time = 5;
        for (int k = 0; k < 5; k++)
        {
            timerBlock[k].color = Color.white * 1f;
        }
        ApplyGravityToBoard();
    }
    void ApplyGravityToBoard()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = (height - 1); y >= 0; y--)
            {
                Point p = new Point(x, y);
                Node node = getNodeAtPoint(p);
                int val = getValueAtPoint(p);

                if (val != 0) continue;

                for (int ny = (y - 1); ny >= -1; ny--)
                {
                    Point next = new Point(x, ny);
                    int nextVal = getValueAtPoint(next);

                    if (nextVal == 0) continue;

                    if (nextVal != -1)
                    {
                        Node got = getNodeAtPoint(next);
                        NodePiece piece = got.getPiece();

                        node.SetPiece(piece);
                        update.Add(piece);

                        got.SetPiece(null);
                    }
                    else
                    {
                        int newVal = fillPiece();

                        NodePiece piece;

                        Point fallPnt = new Point(x, (-1 - fills[x]));

                        if (dead.Count > 0)
                        {
                            NodePiece revived = dead[0];
                            revived.gameObject.SetActive(true);
                            piece = revived;

                            dead.RemoveAt(0);
                        }
                        else
                        {
                            GameObject obj = Instantiate(nodePiece, gameBoard);
                            NodePiece n = obj.GetComponent<NodePiece>();

                            piece = n;
                        }

                        piece.Initialize(newVal, p, pieces[newVal - 1]);
                        piece.rect.anchoredPosition = getPositionFromPoint(fallPnt);

                        Node hole = getNodeAtPoint(p);
                        hole.SetPiece(piece);
                        ResetPiece(piece);

                        fills[x]++;
                    }

                    break;
                }
            }
        }
    }
    FlippedPieces getFlipped(NodePiece p)
    {
        FlippedPieces flip = null;
        for (int i = 0; i < flipped.Count; i++)
        {
            if (flipped[i].getOtherPiece(p) != null)
            {
                flip = flipped[i];
                break;
            }
        }

        return flip;
    }
    void StartGame()
    {
        fills = new int[width];

        string seed = getRandomSeed();
        random = new System.Random(seed.GetHashCode());

        update = new List<NodePiece>();

        flipped = new List<FlippedPieces>();

        dead = new List<NodePiece>();

        killed = new List<KilledPiece>();

        InitializeBoard();
        VerifyBoard();
        InstantiateBoard();
    }
    void InitializeBoard()
    {
        board = new Node[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                board[x, y] = new Node((boardLayout.rows[y].row[x]) ? -1 : fillPiece(), new Point(x, y));
            }
        }
    }
    void VerifyBoard()
    {
        List<int> remove;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Point p = new Point(x, y);
                int val = getValueAtPoint(p);
                if (val <= 0) continue;

                remove = new List<int>();

                while (isConnected(p, true).Count > 0)
                {
                    val = getValueAtPoint(p);

                    if (!remove.Contains(val))
                    {
                        remove.Add(val);
                    }

                    setValueAtPoint(p, newValue(ref remove));
                }
            }
        }
    }
    void InstantiateBoard()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Node node = getNodeAtPoint(new Point(x, y));

                int val = node.value;

                if (val <= 0) continue;

                GameObject p = Instantiate(nodePiece, gameBoard);

                NodePiece piece = p.GetComponent<NodePiece>();

                RectTransform rect = p.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2(32 + (64 * x), -32 - (64 * y));

                piece.Initialize(val, new Point(x, y), pieces[val - 1]);

                node.SetPiece(piece);
            }
        }
    }
    public void ResetPiece(NodePiece piece)
    {
        piece.ResetPosition();
        update.Add(piece);
    }
    public void FlipPieces(Point one, Point two, bool main)
    {

        swipe.Play();
        if (getValueAtPoint(one) < 0) return;

        Node nodeOne = getNodeAtPoint(one);
        NodePiece pieceOne = nodeOne.getPiece();

        if (getValueAtPoint(two) > 0)
        {
            Node nodeTwo = getNodeAtPoint(two);
            NodePiece pieceTwo = nodeTwo.getPiece();

            nodeOne.SetPiece(pieceTwo);
            nodeTwo.SetPiece(pieceOne);
            if (main)
            {
                flipped.Add(new FlippedPieces(pieceOne, pieceTwo));
            }

            update.Add(pieceOne);
            update.Add(pieceTwo);
            if (getValueAtPoint(two) == 6)
            {
                bombExplose(two, 3);
            }
            else if (getValueAtPoint(two) == 7)
            {
                bombExplose(two, 5);
            }
        }
        else
        {
            ResetPiece(pieceOne);
        }
    }
    void KillPiece(Point p)
    {
        List<KilledPiece> available = new List<KilledPiece>();

        for (int i = 0; i < killed.Count; i++)
        {
            if (!killed[i].falling)
            {
                available.Add(killed[i]);
            }
        }

        KilledPiece set = null;

        if (available.Count > 0)
        {
            set = available[0];
        }
        else
        {
            GameObject kill = GameObject.Instantiate(killedPiece, killedBoard);
            KilledPiece kPiece = kill.GetComponent<KilledPiece>();
            set = kPiece;
            killed.Add(kPiece);
        }

        int val = getValueAtPoint(p) - 1;

        if (set != null && val >= 0 && val < pieces.Length)
        {
            set.Initialize(piecesdead[val], getPositionFromPoint(p), expl, expl1, gameBoard, val);
        }
    }
    List<Point> isConnected(Point p, bool main)
    {
        List<Point> connected = new List<Point>();
        int val = getValueAtPoint(p);

        Point[] directions =
        {
        Point.up,
        Point.right,
        Point.down,
        Point.left
        };

        foreach (Point dir in directions) // проверка 2 или больше в ряд при стартовой генерации 
        {
            List<Point> line = new List<Point>();

            int same = 0;

            for (int i = 1; i < 3; i++)
            {
                Point check = Point.add(p, Point.mult(dir, i));

                if (getValueAtPoint(check) == val)
                {
                    line.Add(check);
                    same++;
                }
            }

            if (same > 1) // если больше чем 1 подряд в ряд
            {
                AddPoints(ref connected, line);
            }
        }

        for (int i = 0; i < 2; i++) // проверка если в середине между другими фигурами 2 одинаковых фигуры
        {
            List<Point> line = new List<Point>();

            int same = 0;
            Point[] check = { Point.add(p, directions[i]), Point.add(p, directions[i + 2]) };

            foreach (Point next in check) // проверка 2 сторон от эллемента, такие же ли они по значению, если да - добавить их в лист
            {
                if (getValueAtPoint(next) == val)
                {
                    line.Add(next);
                    same++;
                }
            }
            if (same > 1)
            {
                AddPoints(ref connected, line);
            }
        }

        for (int i = 0; i < 4; i++) // проверка 2*2 ситуации
        {
            List<Point> square = new List<Point>();

            int same = 0;
            int next = i + 1;
            if (next >= 4)
            {
                next -= 4;
            }

            Point[] check = { Point.add(p, directions[i]), Point.add(p, directions[next]), Point.add(p, Point.add(directions[i], directions[next])) };

            foreach (Point pnt in check) // проверка всех сторон от эллемента, такие же ли они по значению, если да - добавить их в лист
            {
                if (getValueAtPoint(pnt) == val)
                {
                    square.Add(pnt);
                    same++;
                }
            }

            if (same > 2)
            {
                AddPoints(ref connected, square);
            }
        }

        if (main) // проверка других совпадений при другом совпадении
        {
            for (int i = 0; i < connected.Count; i++)
            {
                AddPoints(ref connected, isConnected(connected[i], false)); // рекурсия ;-)
            }
        }

        /* Не нужен!
        if (connected.Count > 0)
        {
            connected.Add(p);
        }
        */

        return connected;
    }
    void AddPoints(ref List<Point> points, List<Point> add)
    {
        foreach (Point p in add)
        {
            bool doAdd = true;

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].Equals(p))
                {
                    doAdd = false;
                    break;
                }
            }

            if (doAdd)
            {
                points.Add(p);
            }
        }
    }
    int fillPiece()
    {
        if (Save.bomb)
        {
            int val = 6;
            Save.bomb = false;
            return val;
        }
        else if (Save.superbomb)
        {
            int val = 7;
            Save.superbomb = false;
            return val;
        }
        else
        {
            int val = 1;
            val = (random.Next(0, 100) / (100 / 5)) + 1;
            return val;
        }

    }
    public int getValueAtPoint(Point p)
    {
        if (p.x < 0 || p.x >= width || p.y < 0 || p.y >= height)
        {
            return -1;
        }

        return board[p.x, p.y].value;
    }
    void setValueAtPoint(Point p, int v)
    {
        board[p.x, p.y].value = v;
    }
    Node getNodeAtPoint(Point p)
    {
        return board[p.x, p.y];
    }
    int newValue(ref List<int> remove)
    {
        List<int> available = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            available.Add(i + 1);
        }

        foreach (int i in remove)
        {
            available.Remove(i);
        }

        if (available.Count <= 0)
        {
            return 0;
        }

        return available[random.Next(0, available.Count)];
    }
    string getRandomSeed()
    {
        string seed = "";
        string acceptableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890!@#$%^*()";

        for (int i = 0; i < 20; i++)
        {
            seed += acceptableChars[UnityEngine.Random.Range(0, acceptableChars.Length)];
        }

        return seed;
    }
    public Vector2 getPositionFromPoint(Point p)
    {
        return new Vector2(32 + (64 * p.x), -32 - (64 * p.y));
    }
}

[System.Serializable]
public class Node
{
    public int value;
    // 0 - пустой,
    // 1 - дерево,
    // 2 - земля,
    // 3 - камень,
    // 4 - кирпич,
    // 5 - песок,
    //-1 - дырка

    public Point index;

    NodePiece piece;
    public Node(int v, Point i)
    {
        value = v;
        index = i;
    }
    public void SetPiece(NodePiece p)
    {
        piece = p;
        value = (piece == null) ? 0 : piece.value;

        if (piece == null) return;

        piece.SetIndex(index);
    }
    public NodePiece getPiece()
    {
        return piece;
    }
}

[System.Serializable]
public class FlippedPieces
{
    public NodePiece one;
    public NodePiece two;

    public FlippedPieces(NodePiece o, NodePiece t)
    {
        one = o; two = t;
    }
    public NodePiece getOtherPiece(NodePiece p)
    {
        if (p == one)
        {
            return two;
        }
        else if (p == two)
        {
            return one;
        }
        else
        {
            return null;
        }
    }
}

