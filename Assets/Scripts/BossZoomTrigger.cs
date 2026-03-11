using UnityEngine;
using System.Collections;

public class BossZoomTrigger : MonoBehaviour
{
    public Camera cam;
    public Transform arenaCenter;

    public float zoomSize = 10f;
    public float zoomSpeed = 2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CameraFollow follow = cam.GetComponent<CameraFollow>();

            if (follow != null)
                follow.enabled = false;

            StartCoroutine(ZoomCamera());
        }
    }

    IEnumerator ZoomCamera()
    {
        Vector3 targetPosition = new Vector3(
            arenaCenter.position.x,
            arenaCenter.position.y,
            cam.transform.position.z
        );

        while (Vector3.Distance(cam.transform.position, targetPosition) > 0.05f ||
              Mathf.Abs(cam.orthographicSize - zoomSize) > 0.05f)
        {
            cam.transform.position = Vector3.Lerp(
                cam.transform.position,
                targetPosition,
                zoomSpeed * Time.deltaTime
            );

            cam.orthographicSize = Mathf.Lerp(
                cam.orthographicSize,
                zoomSize,
                zoomSpeed * Time.deltaTime
            );

            yield return null;
        }
    }
}