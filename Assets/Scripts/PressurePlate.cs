using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;

    void OnTriggerStay2D(Collider2D other)
    {
            door.SetActive(false);
    }
}
