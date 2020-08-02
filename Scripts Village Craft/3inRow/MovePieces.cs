using UnityEngine;

public class MovePieces : MonoBehaviour
{
    public static MovePieces instance;

    Match3 game;

    NodePiece moving;
    Point newIndex;
    Vector2 mouseStart;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        game = GetComponent<Match3>();
    }
    void Update()
    {
        if (moving != null)
        {
            Vector2 dir = ((Vector2)Input.mousePosition - mouseStart);
            Vector2 nDir = dir.normalized;
            Vector2 aDir = new Vector2(Mathf.Abs(dir.x), Mathf.Abs(dir.y));

            newIndex = Point.clone(moving.index);
            Point add = Point.zero;

            if (dir.magnitude > 32) // Если наша мышка на 32 пикселя отдалилась от своего первоначального значения
            {
                // дает понять мышке координаты обьекта на котором она находится ((0,0) | (1,0) | (0,1) | (1,1) и т.д.)
                if (aDir.x > aDir.y)
                {
                    add = (new Point((nDir.x > 0) ? 1 : -1, 0));
                }
                else if (aDir.y > aDir.x)
                {
                    add = (new Point(0, (nDir.y > 0) ? -1 : 1));
                }
            }
            newIndex.x = newIndex.x + add.x;
            newIndex.y = newIndex.y + add.y;

            Vector2 pos = game.getPositionFromPoint(moving.index);

            if (!newIndex.Equals(moving.index))
            {
                pos += Point.mult(new Point(add.x, -add.y), 16).ToVector(); // (16) - расстояние на которое сдвинется от начальной позиции эллемент при попытке направить его пальцем или мышкой
                // должна быть половина от размера эллемента
            }
            moving.MovePositionTo(pos);

        }
    }
    public void MovePiece(NodePiece piece)
    {
        if (moving != null) return;

        moving = piece;
        mouseStart = Input.mousePosition;
    }
    public void DropPiece()
    {
        if (moving == null) return;

        Debug.Log("Dropped");
        if (game.getValueAtPoint(newIndex) == 6)
        {
            game.bombExplose(newIndex, 3);
        }
        else if (game.getValueAtPoint(newIndex) == 7)
        {
            game.bombExplose(newIndex, 5);
        }
        else
        {
            if (!newIndex.Equals(moving.index))
            {
                game.FlipPieces(moving.index, newIndex, true);
            }
            else
            {
                game.ResetPiece(moving);
            }
        }
        moving = null;
    }
}
