using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public MainChar mainChar;
    public float bounceForce = 100f;

    public AudioSource audioSource;
    public AudioClip BounceClip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "goblin")
        {
            audioSource.PlayOneShot(BounceClip);
            mainChar.ApplyForceToDirection(transform.up, bounceForce);
        }
    }
}
