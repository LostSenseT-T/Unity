using UnityEngine;

public class WallsMover : MonoBehaviour
{
    public Vector2 direction;

    void FixedUpdate()
    {
        transform.Translate(direction * Time.fixedDeltaTime);
    }
}
