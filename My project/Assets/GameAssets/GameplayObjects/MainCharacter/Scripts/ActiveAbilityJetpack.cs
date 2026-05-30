using Unity.VisualScripting;
using UnityEngine;

public class ActiveAbilityJetpack : ActiveAbilityBase
{
    public float jetpackForce;
    public float jetpackFuelMax;

    private float jetpackFuelLeft;

    public void Start()
    {
        jetpackFuelLeft = jetpackFuelMax;
    }

    public override void Ability()
    {
        if (jetpackFuelLeft > 0)
        {
            jetpackFuelLeft --;
            mainChar.ApplyForceToDirection(transform.up, jetpackForce);
        }
        else
        {
            onCooldown = true;
            StartCoroutine(WaitForCooldown());
        }
    }
}
