using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMoving : MonoBehaviour
{

    private Animator anim;
    protected bool onRight = true, onLeft = true;

    public Transform bat;

    private void Start()
    {
        anim = GetComponent<Animator>();

        onRight = true;
        onLeft = false;
    }


    private void Update()
    {
        WhichSide();
    }

    void WhichSide()
    {
        if (bat.position.x >= 1.5)
        {
            anim.SetBool("FlyLeft", true);
        }
        else if (bat.position.x <= -1.5)
        {
            anim.SetBool("FlyLeft", false);
        }
    }
}
