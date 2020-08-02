using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public float speed;

    public float positionOfPatrool;
    public Transform point;
    public Transform bat;
    
    bool movingRight;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Chill();
    }
    

    void Chill()
    {
        if(transform.position.x < point.position.x - positionOfPatrool) //Просто привязал мышь к точке. Выполняется проверка, отошла ли мышь от точки на определенное
        {                                                               //расстояние, если да, то летит в другую сторону
            movingRight = true;
        }
        else if(transform.position.x > point.position.x + positionOfPatrool)
        {
            movingRight = false;
        }

        if(movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
