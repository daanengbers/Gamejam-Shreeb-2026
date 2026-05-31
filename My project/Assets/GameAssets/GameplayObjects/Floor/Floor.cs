using UnityEngine;

public class Floor : MonoBehaviour
{
    public RunManager runManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "goblin")
        {
            runManager.SetHasLanded();
        }
    }
}
