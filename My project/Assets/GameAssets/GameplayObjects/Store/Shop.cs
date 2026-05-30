using JetBrains.Annotations;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    public string abilityToUnlock;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "goblin")
        {
            var mainChar = collision.gameObject.GetComponent<MainChar>();
            if (mainChar.hasCoin == true)
            {
                //Open shop UI
                shopUI.SetActive(true);
                shopUI.GetComponent<ShopMenu>().abilityToUnlock = abilityToUnlock;
                Time.timeScale = 0f; // Pause the game
            }
            else
            {
                //Do something to show the player they can't open the shop
            }
        }
    }
}
