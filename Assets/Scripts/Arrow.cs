using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage = 1;
    public float lifeTime = 6f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        EnemyHealth enemy = col.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage, transform);
            Destroy(gameObject);
        }
    }
}
