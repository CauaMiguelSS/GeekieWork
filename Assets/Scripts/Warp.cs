using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour , ITouchable
{
    public void Active()
    {
        SceneManager.LoadScene("Game");
        gameObject.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
