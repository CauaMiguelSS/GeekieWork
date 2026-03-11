using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject bossController;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            bossController.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
