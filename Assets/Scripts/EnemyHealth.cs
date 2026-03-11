using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public float health = 3f;
    public float knockbackForce = 5f;

    [Header("Drop")]
    public bool dropObject;
    public GameObject objectToDrop;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Color originalColor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    public void TakeDamage(int damage, Transform attacker)
    {
        Debug.Log("Inimigo recebeu dano");

        health -= damage;

        StartCoroutine(DamageFlash());

        Vector2 direction = (transform.position - attacker.position).normalized;
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        if (health <= 0)
        {
            Die();
        }
    }

    IEnumerator DamageFlash()
    {
        sr.color = Color.red;

        yield return new WaitForSeconds(0.2f);

        sr.color = originalColor;
    }

    public void Die()
    {
        if (dropObject && objectToDrop != null)
        {
            Instantiate(objectToDrop, transform.position, Quaternion.identity);
        }

        Debug.Log("Inimigo morreu");
        Destroy(gameObject);
    }
}
