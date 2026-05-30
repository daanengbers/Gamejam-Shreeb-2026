using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CatapultManager : MonoBehaviour
{
    public MainChar mainChar;
    public RunManager runManager;

    public float launchSpeed = 100f;

    public float rotationSpeed = 1f;
    public float maxRotationAngle = 50f;
    public float minRotationAngle = -50f;
    public float rotationZ = 1f;

    private void Update()
    {
        if (this.transform.rotation.eulerAngles.z > 90)
        {
            Debug.Log(transform.eulerAngles);
        }
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
    //&& transform.rotation.eulerAngles.z < 50

    private void RotateRight()
    {
        //transform.RotateAround(this.transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
        Rotate(1);
    }

    private void RotateLeft()
    {
        //transform.RotateAround(this.transform.position, Vector3.forward , rotationSpeed * Time.deltaTime);
        Rotate(-1);
    }

    private void Rotate(float dir)
    {
        rotationZ = Mathf.Clamp(rotationSpeed * dir, minRotationAngle, maxRotationAngle);
        transform.localRotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
