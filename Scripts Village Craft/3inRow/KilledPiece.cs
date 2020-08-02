using UnityEngine;
using UnityEngine.UI;

public class KilledPiece : MonoBehaviour
{
    public bool falling;
    public RectTransform gamebord;
    public float speed = 16f;
    public float gravity = 32f;
    public float minX = -1.5f, maxX = 1.5f;
    public GameObject expl;
    public GameObject expl1;
    public int explboolmane;

    Vector2 moveDir;

    RectTransform rect;

    Image img;

    public void Initialize(Sprite piece, Vector2 start,GameObject explose, GameObject explose1,RectTransform gamebordmane, int explbool)
    {
        falling = true;

        moveDir = Vector2.up;
        moveDir.x = Random.Range(minX, maxX);
        moveDir *= speed / 2;

        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        img.sprite = piece;
        rect.anchoredPosition = start;
        expl = explose;
        expl1 = explose1;
        gamebord = gamebordmane;
        explboolmane = explbool;
    }
    void Update()
    {
        if (!falling) return;
        if(explboolmane==5)
        {
            Vector3 v = new Vector3(rect.anchoredPosition.x - 5 * 64, rect.anchoredPosition.y + 7 * 64, 0);
            var explpref = Instantiate(expl, v, Quaternion.identity);
            explpref.transform.SetParent(gamebord,false);
            explboolmane = 0;
        }else if(explboolmane == 6)
        {
            Vector3 v = new Vector3(rect.anchoredPosition.x - 5 * 64, rect.anchoredPosition.y + 7 * 64, 0);
            var explpref = Instantiate(expl1, v, Quaternion.identity);
            explpref.transform.SetParent(gamebord, false);
            explboolmane = 0;
        }
        moveDir.y -= Time.deltaTime * gravity;
        moveDir.x = Mathf.Lerp(moveDir.x, 0, Time.deltaTime);
        rect.anchoredPosition += moveDir * Time.deltaTime * speed;

        if (rect.position.x < -64f || rect.position.x > Screen.width + 64f || rect.position.y < -64f || rect.position.y > Screen.height + 64f)
        {
            falling = false;
        }
    }
}
