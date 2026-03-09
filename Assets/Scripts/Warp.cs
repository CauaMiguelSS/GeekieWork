using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    public void OnTriggerEnter2D()
    {
        SceneManager.LoadScene("Game");
        gameObject.SetActive(false);
    }

}
