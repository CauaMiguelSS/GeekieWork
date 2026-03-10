using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;
    public float arrowSpeed = 10f;

    public float shootCooldown = 0.5f;
    private float cooldownTimer;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(1) && cooldownTimer <= 0f)
        {
            Shoot();
            cooldownTimer = shootCooldown;
        }
    }

    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 direction = (mousePos - shootPoint.position).normalized;

        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);

        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * arrowSpeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
