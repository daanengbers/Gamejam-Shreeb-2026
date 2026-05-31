using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public MainChar mainChar;
    public GameObject YesButton;

    public GameObject BombIcon;
    public GameObject RocketIcon;

    public string abilityToUnlock;

    public AudioSource audioSource;
    public AudioClip purchaseSound;

    void Start()
    {
        switch (abilityToUnlock)
        {
            case "Bomb":
                BombIcon.SetActive(true);
                RocketIcon.SetActive(false);
                break;
            case "jetpack":
                BombIcon.SetActive(false);
                RocketIcon.SetActive(true);
                break;
        }
    }

    private void Update()
    {
        if (!mainChar.hasCoin)
        {
            YesButton.SetActive(false);
        }
        else
        {
            YesButton.SetActive(true);
        }
    }

    public void NoButtonClick()
    {
        Time.timeScale = 1f; // Resume the game
        gameObject.SetActive(false);
    }

    public void YesButtonClick()
    {
        Time.timeScale = 1f; // Resume the game
        mainChar.unlockAbility(abilityToUnlock);
        mainChar.DropCoin();
        audioSource.PlayOneShot(purchaseSound);
        gameObject.SetActive(false);
    }
}
