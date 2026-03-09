using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public Transform player;

    public float speed = 2f;
    public float detectionDistance = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < detectionDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        }
    }
}
