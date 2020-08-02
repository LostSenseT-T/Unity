using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimberMan : MonoBehaviour
{
    public Animator anim; // работа с анимацией
    private SpriteRenderer sprite; // работа с анимацией


    private string dir; // узнаем с какой стороны находится игрок во время смерти

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // работа с анимацией

        dir = "LEFT";

    }
    void Update()
    {
        
    }
    public void changeDirection(string direction) // меняем позицию при нажатии на экран
    {
        if (direction == "LEFT")
        {
            transform.localPosition = new Vector3(-2.1f, -1.5f, transform.position.z); // передвигаем игрока влево
            sprite.flipX = true; // оставляем стандартное расположение
            dir = direction; // присваиваем значение переменной
        }
        else if (direction == "RIGHT")
        {
            transform.localPosition = new Vector3(2.05f, -1.5f, transform.position.z); // передвигаем игрока вправо
            sprite.flipX = false; // разворачиваем
            dir = direction; // присваиваем значение переменной
        }
    }
    public void LeftCutAnimation() // анимация рубления дерева слева
    {
        anim.Play("Cut",0,0); // вызывает анимацию рубления дерева слева
    }
    public void RightCutAnimation() // анимация рубления дерева справа
    {
        anim.Play("Cut2", 0, 0); // вызывает анимацию рубления дерева справа
    }
    public void Die() // СМЭРТЬ
    {

        if (dir == "LEFT") // Если умерли слева
        {
            anim.Play("Die", 0, 0); // вызов анимации смерти слева
        }
        else if (dir == "RIGHT") // если умерли справа
        {
            anim.Play("Die2", 0, 0); // вызов анимации смерти справа
        }
    }
    public void respawn()
    {
        anim.Play("Stay", 0, 0);

        if (dir == "LEFT")
        {
            transform.localPosition = new Vector3(-2.1f, -1.5f, transform.position.z); // передвигаем игрока влево
            sprite.flipX = true; // оставляем стандартное расположение
        }
        else if (dir == "RIGHT")
        {
            transform.localPosition = new Vector3(2.05f, -1.5f, transform.position.z); // передвигаем игрока вправо
            sprite.flipX = false; // разворачиваем
        }
    }
}
