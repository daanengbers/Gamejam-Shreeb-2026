using UnityEngine;

public class ActiveAbilityBomb : ActiveAbilityBase
{
    public float explosionForce = 100f;
    public override void Ability()
    {
        onCooldown = true;
        Explode();
    }

    public void Explode()
    {
        mainChar.ApplyForceToDirection(transform.up, explosionForce, true, -1);
        StartCoroutine(WaitForCooldown());
    }
}
