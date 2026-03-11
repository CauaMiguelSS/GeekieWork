using UnityEngine;

public class FallingFire : MonoBehaviour
{
    public float speed = 6f;
    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
