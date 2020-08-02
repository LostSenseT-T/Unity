using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerRunner : MonoBehaviour
{
    public Animator anim;
    public GameObject pausebutton;
    public GameObject restart;
    private bool onLeft, onRight;
    private bool jumped;
    public static int bonus;
    public Text dethscore;
    public Text isearned;
    public static bool dead = false;

    public AudioSource swipe;
    public AudioSource torch;
    public AudioSource coins;
    public AudioSource cx2;
    private void Awake()
    {
        bonus = 1;
        onLeft = true;
        onRight = false;
        dead = false;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        if (!jumped)
        {
            if (onLeft)
            {
                anim.Play("PlayerRunLeft");
            }
            else
            {
                anim.Play("PlayerRunRight");
            }
        }
    }

    public void Jump()
    {
        if (onLeft)
        {
            swipe.Play();
            anim.Play("PlayerJumpRight");
        }
        else
        {
            swipe.Play();
            anim.Play("PlayerJumpLeft");
        }
        jumped = true;
    }


    void OnLeft()
    {
        onLeft = true;
        onRight = false;

        jumped = false;
    }

    void OnRight()
    {
        onLeft = false;
        onRight = true;

        jumped = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Die"))
        {
            //smert'
            Time.timeScale = 0;
            pausebutton.SetActive(false);
            dead = true;
            Save.scorerunner = (int)(ScoreScriptRunner.score);
            int pr = (int)((((1 + 0.1 * (Save.lvlBuildings[2] + 1)) + (Save.bonusset[2, Save.choosedskin]-1)) - 1) * 100);
            dethscore.text = "" + Convert.ToInt32(Save.scorerunner) + "+" + pr + "%";
            if (Save.lvlvillage * 50 >= Convert.ToInt32(Save.scorerunner))
            {
                isearned.text = "You not earned:" + "\nmin plan : " + (50 * Save.lvlvillage).ToString();
                isearned.color = Color.red;
            }
        }
        else if (other.tag.Equals("Gold"))
        {
            //goldcoin +10monet
            coins.Play();
            ScoreScriptRunner.score += 1 * bonus * Save.bonus;
            Destroy(other.gameObject);
        }
        else if (other.tag == "LightBonus")
        {
            torch.Play();
            BonusScriptRunner.bonusLight = true;
            Destroy(other.gameObject);
        }
        else if (other.tag == "x2Bonus")
        {
            cx2.Play();
            BonusScriptRunner.x2 = true;
            Destroy(other.gameObject);
        }
    }
}