using UnityEngine;

public class Coin : MonoBehaviour
{
    public Rigidbody2D rb;

    public AudioSource audioSource;
    public AudioClip coinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "goblin")
        {
            var mainChar = collision.gameObject.GetComponent<MainChar>();
            if (mainChar.hasCoin == false)
            {
                audioSource.PlayOneShot(coinSound);
                collision.gameObject.GetComponent<MainChar>().PickUpCoin();
                Destroy(gameObject);
            } else
            {
                //Do something to show the player they can't pick up the coin
            }

        }
    }
}
