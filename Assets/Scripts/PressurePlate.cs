using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            door.SetActive(false);
        }
    }
}
