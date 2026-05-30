using System.Collections;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RunManager : MonoBehaviour
{
    [Header("Main character refs")]
    public GameObject mainChar;

    [Header("UI refs")]
    public TMP_Text currentHeightUI;
    public TMP_Text maxHeightUI;
    public GameObject endRunUI;

    public bool hasLaunched { get; private set; } = false;
    public bool hasLanded { get; private set; } = false;

    private float maxHeightReached = 0;
    private float currentHeight = 0;

    public void Update()
    {
        checkIfNewHeightReached();
    }

    private void checkIfNewHeightReached()
    {
        currentHeight = mainChar.transform.position.y;
        currentHeightUI.SetText("Current height: " +  currentHeight + "meters");

        if (currentHeight > maxHeightReached)
        {
            maxHeightReached = currentHeight;
            maxHeightUI.SetText("Max height explored: " + maxHeightReached + " meters");
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
            endRunUI.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }
}
