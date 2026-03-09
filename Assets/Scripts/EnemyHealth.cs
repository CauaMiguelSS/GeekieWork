using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;
    public float knockbackForce = 5f;

    private Rigidbody2D rb;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, Transform attacker) 
    {
        Debug.Log("Inimigo recebeu dano");
        health -= damage;
        Vector2 direction = (transform.position - attacker.position).normalized;
        rb.AddForce (direction * knockbackForce, ForceMode2D.Impulse);

        if (health <= 0) 
        {
            Die();
        }
    }

    public void Die() 
    {
        Debug.Log("Inimigo morreu");
        Destroy(gameObject);
    }
}
