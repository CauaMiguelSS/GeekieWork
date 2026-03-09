using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField]public int maxHealth = 5;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
