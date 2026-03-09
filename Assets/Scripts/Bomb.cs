using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timer = 2f;
    public float radius = 2f;
    public int damage = 3;
    public LayerMask enemyLayer;

    void Start() 
    {
        Invoke("Explode", timer);
    }

    void Explode()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(
            transform.position,
            radius,
            enemyLayer
        );

        foreach (Collider2D enemy in enemies) 
        {
            enemy.GetComponent<EnemyHealth>()?.TakeDamage(damage,transform);
        }
        Destroy(gameObject);
    }
}
