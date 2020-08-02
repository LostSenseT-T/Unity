using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbonuses : MonoBehaviour
{
    int i = 0;
    Vector3 vnew = new Vector3();
    public void spanw_bonuses(GameObject x2bonus, GameObject undeadbonus)
    {

        Vector3 v;
        var r1 = Random.Range(1, 10);
        if (r1 > 5)
        {
            v = new Vector3(-1.7f, 9.25f, 0);
        }
        else
        {
            v = new Vector3(1.7f, 9.25f, 0);
        }

        var r = Random.Range(1, 70);
        if (r == 1)
        {
            Instantiate(x2bonus, v, Quaternion.identity);
        }
        else if (r == 4)
        {
            Instantiate(undeadbonus, v, Quaternion.identity);
        }
    }
    private void Start()
    {
        InvokeRepeating("downfall", 0, 0.02f);
    }
    void downfall()
    {
        vnew = new Vector3(transform.position.x, transform.position.y - 0.09f, 0);
        transform.position = vnew;
    }
    private void Update()
    {
        //if (staticer.bonusdown)
        //{
        //    vnew = new Vector3(transform.position.x, transform.position.y - 1.6f, 0);
        //    transform.position = vnew;
        //    staticer.bonusdown = false;
        //}
        if (transform.position.y < -1)
            Destroy(gameObject);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "x2")
            {
                staticer.x2 = true;
            }
            else if (gameObject.tag == "8")
            {
                staticer.x8 = true;
            }
            Destroy(gameObject);
        }
    }
}
