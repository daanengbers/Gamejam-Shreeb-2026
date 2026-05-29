using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainChar : MonoBehaviour
{
    private bool hasLaunched = false;
    [SerializeField] private float launchSpeed = 10f;
    [SerializeField] private Rigidbody2D rb; 

    void Start()
    {
        
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            hasLaunched = true;
            Launch(launchSpeed);
        };
    }

    void Launch(float launchSpeed)
    {
        rb.AddForceY(launchSpeed);
    }
}
