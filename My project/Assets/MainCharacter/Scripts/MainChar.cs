using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainChar : MonoBehaviour
{
    public RunManager runManager;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float nudgeForce = 100f;

    //Movement functions
    public void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            transform.RotateAround(this.transform.position, Vector3.forward, rotationSpeed);
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            transform.RotateAround(this.transform.position, Vector3.back, rotationSpeed);
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(transform.up * nudgeForce);
        }
    }

    public void Launch(float launchSpeed)
    {
        rb.AddForceY(launchSpeed);
        runManager.SetHasLaunched();
    }
}
