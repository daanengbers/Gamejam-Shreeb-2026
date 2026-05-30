using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class ActiveAbilityBase : MonoBehaviour
{
    public MainChar mainChar;

    public float cooldown = 10f;
    public bool onCooldown = false;

    public void Update()
    {
        if (!onCooldown)
        {
            if (Keyboard.current.leftShiftKey.isPressed)
            {
                Ability();
            }
        }
        else if (onCooldown && Keyboard.current.leftShiftKey.isPressed)
        {
            //play on cooldown sound
        }
        
    }

    public virtual void Ability()
    {

    }

    public IEnumerator WaitForCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }
}
