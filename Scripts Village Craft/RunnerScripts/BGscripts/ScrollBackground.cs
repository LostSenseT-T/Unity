using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSize;
    private Transform currentObjekt;

    void Start()
    {
        currentObjekt = GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        currentObjekt.position = new Vector3(
            currentObjekt.position.x,
            Mathf.Repeat(Time.fixedTime * scrollSpeed, tileSize),
            currentObjekt.position.z
            );
    }
}
