using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CatapultManager : MonoBehaviour
{
    public MainChar mainChar;
    public RunManager runManager;

    public float launchSpeed = 100f;

    public float rotationSpeed = 100f;
    public float maxRotationAngle = 50f;
    public float minRotationAngle = -50f;
    public float rotationZ = 0f;

    private void Update()
    {
        if (!runManager.hasLaunched)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                mainChar.Launch(transform.up, launchSpeed);
            }
            if (Keyboard.current.aKey.isPressed)
            {
                RotateLeft();
            }
            if (Keyboard.current.dKey.isPressed)
            {
                RotateRight();
            }
        }
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
        transform.localRotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
