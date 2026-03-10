using UnityEngine;
using UnityEngine.UI;

public class UIHearts : MonoBehaviour
{
    public static UIHearts instance;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Awake()
    {
        instance = this;
    }

    public void UpdateHearts(int currentHealth, int maxHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            hearts[i].enabled = i < maxHealth;
        }
    }
}
