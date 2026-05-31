using JetBrains.Annotations;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    public string abilityToUnlock;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "goblin")
        {
            //Open shop UI
            shopUI.SetActive(true);
            shopUI.GetComponent<ShopMenu>().abilityToUnlock = abilityToUnlock;
            Time.timeScale = 0f; // Pause the game
        }
    }
}
