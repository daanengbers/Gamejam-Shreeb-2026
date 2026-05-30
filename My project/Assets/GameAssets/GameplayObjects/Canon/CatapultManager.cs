using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatapultManager : MonoBehaviour
{
    [Header("GameObject refs")]
    public MainChar mainChar;
    public GameObject barrel;

    [Header("Animation refs")]
    public Animator animator;

    [Header("Audio refs")]
    public AudioSource audioSource;
    public AudioClip chargeCannon;
    public AudioClip fireCannon;

    [Header("Manager refs")]
    public RunManager runManager;

    [Header("GameSetting")]
    public float launchSpeed = 100f;

    public float rotationSpeed = 100f;
    public float maxRotationAngle = 50f;
    public float minRotationAngle = -50f;

    //State vars
    private bool isLaunching = false;

    //rotate vars
    private float rotationZ = 0f;

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
                Rotate(1);
            }
            if (Keyboard.current.dKey.isPressed && !isLaunching)
            {
                Rotate(-1);
            }
        }
    }

    private IEnumerator LaunchSequence()
    {
        animator.SetTrigger("CannonTrigger");
        audioSource.PlayOneShot(chargeCannon);

        yield return new WaitForSeconds(2);
        audioSource.PlayOneShot(fireCannon, 0.5f);

        yield return new WaitForSeconds(0.5f);

        mainChar.Launch(transform.up, launchSpeed);
    }

    private void Rotate(float dir)
    {
        rotationZ += rotationSpeed * dir * Time.deltaTime;
        rotationZ = Mathf.Clamp(rotationZ, minRotationAngle, maxRotationAngle);
        barrel.transform.localRotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
