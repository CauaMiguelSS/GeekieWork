using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public float knockbackForce = 6f;
    public float invincibleTime = 0.5f;

    public GameObject gameOverPanel;

    private Rigidbody2D rb;
    private bool invincible;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        UIHearts.instance.UpdateHearts(currentHealth, maxHealth);

        gameOverPanel.SetActive(false);
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

    IEnumerator Invincibility()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibleTime);
        invincible = false;
    }

    void Die()
    {
        Debug.Log("Player morreu");

        Time.timeScale = 0f; // congela o jogo

        gameOverPanel.SetActive(true);
    }
}
