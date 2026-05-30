using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainChar : MonoBehaviour
{
    [Header("Manager refs")]
    public RunManager runManager;

    [Header("Physics refs")]
    [SerializeField] private Rigidbody2D rb;
    public GameObject charModel;

    [Header("GameSettings")]
    [SerializeField] private float rotationSpeed = 100f;

    [Header("ObjectsHolding")]
    public GameObject coinOnGob;
    public GameObject Jetpack;

    [Header("Active Ability Settings")]
    public bool hasCoin = false;
    public GameObject ActiveAbilties;
    public GameObject jetPack;

    [SerializeField] private float nudgeForce = 100f;
    [SerializeField] private float nudgeCooldownTime = 1f;

    [HideInInspector] public Quaternion lookDir;
    
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
    public void ApplyForceToDirection(Vector3 targetDir, float force, bool lookDirOn = false)
    {
        if (lookDirOn)
        {
            var nudgeDir = lookDir * Vector2.up;

            rb.AddForce(nudgeDir * force);
        }
        else
        {
            rb.AddForce(targetDir * force);
        }
    }

    public void Launch(Vector3 targetDir, float launchSpeed)
    {
        rb.AddForce(targetDir * launchSpeed);
        runManager.SetHasLaunched();
    }

    public void unlockAbility(string AbilityToUnlock)
    {
        foreach(Transform child in ActiveAbilties.transform)
        {
            child.gameObject.SetActive(false);
        }

        switch (AbilityToUnlock)
        {
            case "jetpack":
                jetPack.SetActive(true);
                break;
        }
    }

    public void PickUpCoin()
    {
        hasCoin = true;
        coinOnGob.SetActive(true);
    }

    public void DropCoin()
    {
        hasCoin = false;
        coinOnGob.SetActive(false);
    }
}
