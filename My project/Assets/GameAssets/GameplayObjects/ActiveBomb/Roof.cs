using UnityEngine;

public class Roof : MonoBehaviour
{
    public GameObject WinScreen;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "goblin")
        {
            Time.timeScale = 0f;
            WinScreen.SetActive(true);
        }
    }
}
