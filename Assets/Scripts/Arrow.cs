using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 8f;
    public int damage = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D enemy) 
    {
        if (enemy.CompareTag("Enemy")) 
        {
            enemy.GetComponent<EnemyHealth>()?.TakeDamage(damage, transform);
            Destroy(gameObject);
        }
    }
}
