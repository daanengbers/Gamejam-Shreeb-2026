using UnityEngine;
using UnityEngine.InputSystem;

public class CatapultManager : MonoBehaviour
{
    public MainChar mainChar;
    public RunManager runManager;

    public float rotationSpeed = 1f;
    public float launchSpeed = 100f;

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
            if (Keyboard.current.aKey.isPressed && transform.rotation.eulerAngles.z < 50)
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
        transform.RotateAround(this.transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
    }

    private void RotateLeft()
    {
        transform.RotateAround(this.transform.position, Vector3.forward , rotationSpeed * Time.deltaTime);
    }
}
