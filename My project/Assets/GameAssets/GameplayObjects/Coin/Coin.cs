using UnityEngine;

public class Coin : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("" + collision.gameObject.tag);
        if (collision.gameObject.tag == "goblin")
        {
            Debug.Log("" + collision.gameObject.tag);
            var mainChar = collision.gameObject.GetComponent<MainChar>();
            if (mainChar.hasCoin == false)
            {
                Debug.Log("" + collision.gameObject.tag +"2");
                collision.gameObject.GetComponent<MainChar>().PickUpCoin();
                Destroy(gameObject);
            } else
            {
                //Do something to show the player they can't pick up the coin
            }

        }
    }
}
