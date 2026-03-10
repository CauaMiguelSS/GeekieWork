using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public float knockbackForce = 6f;
    public float invincibleTime = 0.5f;

    private Rigidbody2D rb;
    private bool invincible;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        UIHearts.instance.UpdateHearts(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage, Transform attacker)
    {
        if (invincible) return;

        currentHealth -= damage;

        Vector2 direction = (transform.position - attacker.position).normalized;
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        UIHearts.instance.UpdateHearts(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

        StartCoroutine(Invincibility());
    }

    System.Collections.IEnumerator Invincibility()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibleTime);
        invincible = false;
    }

    void Die()
    {
        Debug.Log("Player morreu");
        Destroy(gameObject);
    }
}
