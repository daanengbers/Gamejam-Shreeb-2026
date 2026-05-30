using UnityEngine;
using UnityEngine.UIElements;

public class Bomb : MonoBehaviour
{
    public float bombForce = 1000f;
    public GameObject bombCenter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "goblin")
        {
            Debug.Log("cjeese");
            Vector2 attractDirection = (collision.rigidbody.position - new Vector2(bombCenter.transform.position.x, bombCenter.transform.position.y)).normalized;

            Vector2 repelDirection = attractDirection;

            var mainChar = collision.gameObject.GetComponent<MainChar>();

            mainChar.ApplyForceToDirection(repelDirection, bombForce);
        }
    }
}
