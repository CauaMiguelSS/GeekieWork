using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject firePrefab;

    public Transform spawnStart;
    public Transform spawnEnd;

    public Transform targetPoint;

    public float spawnRate = 1f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnFire();
            timer = 0;
        }
    }

    void SpawnFire()
    {
        float t = Random.Range(0f, 1f);

        Vector3 spawnPos = Vector3.Lerp(
            spawnStart.position,
            spawnEnd.position,
            t
        );

        GameObject fire = Instantiate(firePrefab, spawnPos, Quaternion.identity);

        Vector2 dir = targetPoint.position - spawnPos;

        fire.GetComponent<FallingFire>().SetDirection(dir);
    }
}
