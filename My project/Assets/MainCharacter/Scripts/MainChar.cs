using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MainChar : MonoBehaviour
{
    public RunManager runManager;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed = 1f;

    [SerializeField] private float nudgeForce = 100f;
    [SerializeField] private float nudgeCooldownTime = 1f;

    private float rotationZ = 0f;

    private bool nudgeCooldown = false;

    //Movement functions
    public void Update()
    {
        if (runManager.hasLaunched)
        {
            if (Keyboard.current.aKey.isPressed)
            {
                RotateLeft();
            }
            if (Keyboard.current.dKey.isPressed)
            {
                RotateRight();
            }
            if (Keyboard.current.spaceKey.wasPressedThisFrame && !nudgeCooldown)
            {
                Nudge();
            }
        }
    }

    ///Movement funcs///

    //Nudge funcs
    private void Nudge()
    {
        rb.AddForce(transform.up * nudgeForce);
        nudgeCooldown = true;
        StartCoroutine(NudgeCooldownHandler());
    }

    IEnumerator NudgeCooldownHandler()
    {
        yield return new WaitForSeconds(nudgeCooldownTime);
        nudgeCooldown = false;
    }

    //Rotate funcs
    private void RotateRight()
    {
        Rotate(-1);
    }

    private void RotateLeft()
    {
        Rotate(1);
    }

    private void Rotate(int dir)
    {
        rotationZ += rotationSpeed * dir * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, 0, rotationZ);
    }

    ///Public funcs
    public void ApplyForceToDirection(Vector3 targetDir, float force)
    {
        rb.AddForce(targetDir * force);
    }

    public void Launch(Vector3 targetDir, float launchSpeed)
    {
        rb.AddForce(targetDir * launchSpeed);
        runManager.SetHasLaunched();
    }
}
