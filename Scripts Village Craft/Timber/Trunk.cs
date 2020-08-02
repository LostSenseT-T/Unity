using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : MonoBehaviour
{
    private float target;
    private float velocity;
    private float totalTime = 2f;
    private float currentTime = 0f;

    private bool isAnimate = false;

    private SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (!isAnimate) return;

        currentTime += Time.deltaTime;
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + (velocity * currentTime), gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        gameObject.transform.Rotate(Vector3.forward, 10f, Space.Self);

        if (currentTime >= totalTime)
        {
            Destroy(this.gameObject);
            isAnimate = false;
        }
    }
    public void onAnimateDestroy(string directionTrunk)
    {      
        target = (directionTrunk == "RIGHT") ? -5 : 5;
        velocity = (target - gameObject.transform.localPosition.x) / totalTime;
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 0.7f, gameObject.transform.localPosition.z);
        sprite.sortingOrder = 1;
        currentTime = 0f; // как вариант решения проблемы с срубыванием не первого а второго эллемента дерева (изменить с 0 до большего значения)
        isAnimate = true;
    }
}
