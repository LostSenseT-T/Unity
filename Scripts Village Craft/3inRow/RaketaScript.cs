using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaketaScript : MonoBehaviour
{
    public int speed;
    public GameObject raketag;
    void Start()
    {
        Rigidbody2D raketa = GetComponent<Rigidbody2D>();
        raketa.velocity = Vector3.up*speed;
    }
}
