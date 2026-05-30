using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Header("Audio refs")]
    public AudioSource audioSource;
    public AudioClip bombClip;

    [Header("Effect refs")]
    public GameObject explosionSFX;

    [Header("GameSettings")]
    public float bombForce = 1000f;
    public GameObject bombCenter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "goblin")
        {
            Vector2 attractDirection = (collision.rigidbody.position - new Vector2(bombCenter.transform.position.x, bombCenter.transform.position.y)).normalized;

            Vector2 repelDirection = attractDirection;

            var mainChar = collision.gameObject.GetComponent<MainChar>();

            audioSource.PlayOneShot(bombClip, 0.5f);
            explosionSFX.SetActive(true);

            mainChar.ApplyForceToDirection(repelDirection, bombForce);

            Destroy(gameObject);
        }
    }
}
