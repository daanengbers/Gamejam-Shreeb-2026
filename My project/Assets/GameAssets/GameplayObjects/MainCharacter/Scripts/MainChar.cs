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
    [SerializeField] private float rotationSpeed = 100f;

    [SerializeField] private float nudgeForce = 100f;
    [SerializeField] private float nudgeCooldownTime = 1f;

    public Quaternion lookDir;
    public GameObject charModel;

    private float rotationZ = 0f;

    private bool nudgeCooldown = false;

    public void Start()
    {
        lookDir = transform.rotation;
    }

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
        var nudgeDir = lookDir * Vector2.up;

        //Check if the player wants to move left or right
        if (Mathf.Sign(nudgeDir.x ) != Mathf.Sign(rb.linearVelocity.x))
        {
            rb.linearVelocity = new Vector2(-rb.linearVelocity.x * 0.5f, rb.linearVelocity.y);
        }

        rb.AddForce(nudgeDir * nudgeForce);

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
        lookDir = lookDir * Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.back);
        charModel.transform.rotation = lookDir;
    }

    private void RotateLeft()
    {
        lookDir = lookDir * Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.forward);
        charModel.transform.rotation = lookDir;
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
