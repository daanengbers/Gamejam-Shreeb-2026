using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class WinScreen : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.pKey.isPressed)
        {
            Time.timeScale = 1f;
            PlayerPrefs.SetInt("highscore", 0);
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        }
    }
}
