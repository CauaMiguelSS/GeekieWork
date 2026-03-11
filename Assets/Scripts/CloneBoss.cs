using UnityEngine;
using System.Collections;

public class CloneBoss : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    public float attackDuration = 5f;

    public GameObject fireSpawner;
    public GameObject laser;

    public SpriteRenderer sprite;

    private bool isAttacking;

    void Start()
    {
        currentHealth = maxHealth;

        fireSpawner.SetActive(false);
        laser.SetActive(false);

        sprite.enabled = false; // começa invisível
    }

    public void StartAttack()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;

        sprite.enabled = true; // aparece
        fireSpawner.SetActive(true);

        yield return new WaitForSeconds(attackDuration);

        fireSpawner.SetActive(false);
        laser.SetActive(false);
        sprite.enabled = false; // fica invisível

        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
        if (!isAttacking) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}