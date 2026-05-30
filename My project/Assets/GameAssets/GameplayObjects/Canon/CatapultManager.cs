using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CatapultManager : MonoBehaviour
{
    public MainChar mainChar;
    public GameObject barrel;

    public AudioSource audioSource;
    public AudioClip chargeCannon;
    public AudioClip fireCannon;

    public RunManager runManager;

    private bool isLaunching = false;

    public float launchSpeed = 100f;

    public float rotationSpeed = 100f;
    public float maxRotationAngle = 50f;
    public float minRotationAngle = -50f;
    public float rotationZ = 0f;

    public Animator animator;

    private void Update()
    {
        if (!runManager.hasLaunched)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame && !isLaunching)
            {
                isLaunching = true;
                StartCoroutine(LaunchSequence());
            }
            if (Keyboard.current.aKey.isPressed && !isLaunching)
            {
                RotateLeft();
            }
            if (Keyboard.current.dKey.isPressed && !isLaunching)
            {
                RotateRight();
            }
        }
    }

    private IEnumerator LaunchSequence()
    {
        animator.SetTrigger("CannonTrigger");
        audioSource.PlayOneShot(chargeCannon);

        yield return new WaitForSeconds(2);
        audioSource.PlayOneShot(fireCannon);

        yield return new WaitForSeconds(0.5f);

        mainChar.Launch(transform.up, launchSpeed);
    }

    private void RotateRight()
    {
        Rotate(-1);
    }

    private void RotateLeft()
    {
        Rotate(1);
    }

    private void Rotate(float dir)
    {
        rotationZ += rotationSpeed * dir * Time.deltaTime;
        rotationZ = Mathf.Clamp(rotationZ, minRotationAngle, maxRotationAngle);
        barrel.transform.localRotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
