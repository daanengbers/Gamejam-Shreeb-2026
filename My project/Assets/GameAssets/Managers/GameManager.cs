using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Scoring
    public int highScore = 0;

    //Currency
    public int silver = 0;
    public int gold = 0;

    private static bool created = false;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }

    public void CheckIfNewHighscore(int score)
    {
        highScore = PlayerPrefs.GetInt("highscore");
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            highScore = score;
        }
    }
}
