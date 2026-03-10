using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timer = 2f;
    public float radius = 2f;
    public int damage = 2;
    public LayerMask enemyLayer;

    void Start()
    {
        Invoke("Explode", timer);
    }

    void Explode()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);

        foreach (Collider2D enemy in enemies)
        {
            EnemyHealth e = enemy.GetComponent<EnemyHealth>();

            if (e != null)
            {
                e.TakeDamage(damage, transform);
            }
        }

        Destroy(gameObject);
    }
}
