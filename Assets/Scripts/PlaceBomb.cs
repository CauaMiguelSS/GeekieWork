using UnityEngine;

public class PlaceBomb : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bombPoint;

    public float bombCooldown = 2f;
    private float cooldownTimer;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && cooldownTimer <= 0f)
        {
            PlaceBombNow();
            cooldownTimer = bombCooldown;
        }
    }

    void PlaceBombNow()
    {
        Instantiate(bombPrefab, bombPoint.position, Quaternion.identity);
    }
}