using UnityEngine;
using UnityEngine.InputSystem;

public class CatapultManager : MonoBehaviour
{
    public MainChar mainChar;
    public RunManager runManager;

    public float launchSpeed = 100f;

    private void Update()
    {
        if (!runManager.hasLaunched)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                mainChar.Launch(launchSpeed);
            }
        }
        
    }
}
