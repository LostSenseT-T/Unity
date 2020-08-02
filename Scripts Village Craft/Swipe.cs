using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public GameObject scrollbar;
    private float scroll_pos = 0;
    float[] pos;
    float rpos;
    float lpos;
    // Update is called once per frame
    private void Start()
    {
        pos = new float[transform.childCount];
        var delta = Camera.main.ScreenToWorldPoint(transform.GetChild(1).position).x - Camera.main.ScreenToWorldPoint(transform.GetChild(2).position).x;
        lpos = Camera.main.ScreenToWorldPoint(transform.GetChild(1).position).x - (delta / 2);
        rpos = Camera.main.ScreenToWorldPoint(transform.GetChild(1).position).x + (delta / 2);
    }
    void Update()
    {
        pos = new float[transform.childCount];
        for (int i = 0; i < pos.Length; i++)
        {
            if (Camera.main.ScreenToWorldPoint(transform.GetChild(i).position).x < lpos && Camera.main.ScreenToWorldPoint(transform.GetChild(i).position).x >= rpos)
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }

        }

    }
}