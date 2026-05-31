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
        if (score > highScore)
        {
            highScore = score;
        }
    }
}
