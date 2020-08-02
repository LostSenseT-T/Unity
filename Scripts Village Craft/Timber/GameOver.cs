using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text txtBestScore;
    public Text txtScore;
    public TapController tapController;

    public Animator anim;


    void Start()
    {
    }
    public void replay()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
    public void show()
    {
        txtScore.text = tapController.getScore().ToString();
        txtBestScore.text = tapController.getBestScore().ToString();

        gameObject.SetActive(true);
        anim.SetBool("Panel", true);
    }
    public void hide()
    {
        gameObject.SetActive(false);
    }
}

