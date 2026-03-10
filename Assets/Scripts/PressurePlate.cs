using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;

    void OnTriggerEnter2D(Collider2D other)
    {
            door.SetActive(false);
    }
    void OnTriggerExit2D(Collider2D other)
    {
            door.SetActive(true);
    }
}
