using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    public float timeOn = 0.4f;
    public float timeOff = 2f;

    void OnEnable()
    {
        StartCoroutine(LaserRoutine());
    }

    IEnumerator LaserRoutine()
    {
        while (true)
        {
            gameObject.SetActive(true);

            yield return new WaitForSeconds(timeOn);

            gameObject.SetActive(false);

            yield return new WaitForSeconds(timeOff);
        }
    }
}
