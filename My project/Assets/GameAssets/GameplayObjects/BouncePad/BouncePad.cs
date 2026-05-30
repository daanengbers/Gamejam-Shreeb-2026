using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public MainChar mainChar;
    public float bounceForce = 100f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "goblin")
        {
            Debug.Log("my pantie");
            mainChar.ApplyForceToDirection(transform.up, bounceForce);
        }
    }
}
