using TMPro;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    public GameManager gameManager;
    public RunManager runManager;

    public TMP_Text currentHeightUI;
    public TMP_Text bestHeightUI;

    public void Update()
    {
        currentHeightUI.SetText("Your height: " + runManager.maxHeightReached + " meters");
        bestHeightUI.SetText("High-score: " + gameManager.highScore + " meters");
    }

    public void RestartButtonClick()
    {
        Time.timeScale = 1f; // Resume the game
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
