using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerning : MonoBehaviour
{
    //mane
    public GameObject mane;
    public GameObject maneLeft;
    public GameObject maneRight;
    public GameObject avatar;
    public GameObject settings;
    public GameObject resourse;
    public GameObject buttons;
    public GameObject thcanvas;
    public GameObject questcanvas;
    public GameObject everydaycanvas;
    public GameObject skincraftcanvas;
    public GameObject exchangercanvas;
    //left
    public GameObject Achivment;
    public GameObject leftscreen;
    public GameObject skinshop;
    public GameObject gendershop;
    //right
    public GameObject minecanvas;
    public GameObject advenchcanvas;
    public GameObject timbercanvas;
    public GameObject mine;
    public GameObject advench;
    public GameObject timber;
    //camera
    public AudioSource book;
    public Camera camera;
    public GameObject oblochkamask;
    public GameObject mostmask;

    //Mane screen
    public void Update()
    {
        if (Save.firstmane && camera.transform.position.x < 5 && camera.transform.position.x > -5)
        {
            mane.SetActive(true);
            oblochkamask.SetActive(false);
            mostmask.SetActive(false);
            Save.firstmane = false;
            Save.CanSwipe = false;
        }
        if (Save.firstleft && camera.transform.position.x < -5)
        {
            maneLeft.SetActive(true);
            oblochkamask.SetActive(false);
            mostmask.SetActive(false);
            Save.firstleft = false;
            Save.CanSwipe = false;
        }
        if (Save.firstright && camera.transform.position.x > 5)
        {
            maneRight.SetActive(true);
            oblochkamask.SetActive(false);
            mostmask.SetActive(false);
            Save.firstright = false;
            Save.CanSwipe = false;
        }
    }
    public void Mane()
    {
        book.Play();
        if (camera.transform.position.x > 5)
        {
            maneRight.SetActive(true);
            oblochkamask.SetActive(false);
            mostmask.SetActive(false);
            Save.CanSwipe = false;
        }
        else if (camera.transform.position.x < -5)
        {
            maneLeft.SetActive(true);
            oblochkamask.SetActive(false);
            mostmask.SetActive(false);
            Save.CanSwipe = false;
        }
        else
        {
            mane.SetActive(true);
            mostmask.SetActive(false);
            oblochkamask.SetActive(false);
            Save.CanSwipe = false;
        }
    }
    int left = 0;
    int right = 0;
    int main = 0;
    public void Avatar()
    {
        switch(main)
        {
            case 0:
                closeMask();
                avatar.SetActive(true);
                break;
            case 1:
                closeMask();
                settings.SetActive(true);
                break;
            case 2:
                closeMask();
                resourse.SetActive(true);
                break;
            case 3:
                closeMask();
                buttons.SetActive(true);
                break;
            case 4:
                closeMask();
                thcanvas.SetActive(true);
                break;
            case 5:
                closeMask();
                everydaycanvas.SetActive(true);
                break;
            case 6:
                closeMask();
                questcanvas.SetActive(true);
                break;
            case 7:
                closeMask();
                exchangercanvas.SetActive(true);
                break;
            case 8:
                closeMask();
                skincraftcanvas.SetActive(true);
                break;
            case 9:
                close();
                break;
        }
        main += 1;
    }
    //leftscreen
    public void Achiv()
    {
        switch (left)
        {
            case 0:
                closeMask();
                Achivment.SetActive(true);
                break;
            case 1:
                closeMask();
                leftscreen.SetActive(true);
                break;
            case 2:
                closeMask();
                skinshop.SetActive(true);
                break;
            case 3:
                closeMask();
                gendershop.SetActive(true);
                break;
            case 4:
                close();
                break;
        }
        left += 1;
    }
    //right sreen
    public void minegame()
    {
        switch (right)
        {
            case 0:
                closeMask();
                mine.SetActive(true);
                break;
            case 1:
                closeMask();
                minecanvas.SetActive(true);
                break;
            case 2:
                closeMask();
                timber.SetActive(true);
                break;
            case 3:
                closeMask();
                timbercanvas.SetActive(true);
                break;
            case 4:
                closeMask();
                advench.SetActive(true);
                break;
            case 5:
                closeMask();
                advenchcanvas.SetActive(true);
                break;
            case 6:
                close();
                break;
        }
        right += 1;
    }
    public void closeMask()
    {
        avatar.SetActive(false);
        resourse.SetActive(false);
        thcanvas.SetActive(false);
        buttons.SetActive(false);
        questcanvas.SetActive(false);
        everydaycanvas.SetActive(false);
        skincraftcanvas.SetActive(false);
        exchangercanvas.SetActive(false);
        settings.SetActive(false);

        Achivment.SetActive(false);
        leftscreen.SetActive(false);
        gendershop.SetActive(false);
        skinshop.SetActive(false);

        mine.SetActive(false);
        minecanvas.SetActive(false);
        timber.SetActive(false);
        timbercanvas.SetActive(false);
        advench.SetActive(false);
        advenchcanvas.SetActive(false);
    }

    //close
    public void close()
    {
        closeMask();
        maneLeft.SetActive(false);
        maneRight.SetActive(false);
        mane.SetActive(false);
        skincraftcanvas.SetActive(false);
        gendershop.SetActive(false);
        advenchcanvas.SetActive(false);
        mostmask.SetActive(true);
        oblochkamask.SetActive(true);
        Save.CanSwipe = true;
    }
}
