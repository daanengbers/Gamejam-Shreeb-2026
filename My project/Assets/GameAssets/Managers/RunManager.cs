using TMPro;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    [Header("Main character refs")]
    public GameObject mainChar;

    [Header("UI refs")]
    public TMP_Text currentHeightUI;
    public TMP_Text maxHeightUI;
    public GameObject endRunUI;

    public GameManager gameManager;

    public bool hasLaunched { get; private set; } = false;
    public bool hasLanded { get; private set; } = false;

    public int maxHeightReached = 0;
    private int currentHeight = 0;

    public void Update()
    {
        if(hasLaunched)
            checkIfNewHeightReached();
    }

    private void checkIfNewHeightReached()
    {
        currentHeight = Mathf.FloorToInt(mainChar.transform.position.y);
        currentHeightUI.SetText("Highest: " +  currentHeight + "meters");

        if (currentHeight > maxHeightReached)
        {
            maxHeightReached = currentHeight;
            maxHeightUI.SetText("Height: " + maxHeightReached + " meters");
        }
    }

    public void SetHasLaunched()
    {
        hasLaunched = true;
    }

    public void SetHasLanded()
    {
        if (hasLaunched)
        {
            hasLanded = true;

            gameManager.CheckIfNewHighscore(maxHeightReached);
            endRunUI.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
