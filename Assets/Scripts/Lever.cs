using System.Xml.Linq;
using UnityEditor;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            door.SetActive(false);
        }
    }
}