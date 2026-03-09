using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public Transform attackPoint;
    public float attackRadius = 0.6f;
    public int damage = 1;
    public LayerMask enemyLayer;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("ATAQUE!!!");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRadius,
            enemyLayer
        );
        Debug.Log("inimigos encontrados" + enemies.Length);
        foreach (Collider2D enemy in enemies) 
        {
            Debug.Log("Acertou inimigo");
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage, transform);
            }
        }
    }

    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
