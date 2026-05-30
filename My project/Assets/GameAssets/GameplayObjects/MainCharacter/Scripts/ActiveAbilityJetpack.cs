using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ActiveAbilityJetpack : ActiveAbilityBase
{
    public float jetpackForce;
    public float jetpackFuelMax;

    public UnityEngine.UI.Image jetpackBar;

    private float jetpackFuelLeft;

    public void Start()
    {
        jetpackFuelLeft = jetpackFuelMax;
    }

    public override void Ability()
    {
        jetpackBar.fillAmount = jetpackFuelLeft / jetpackFuelMax;

        if (jetpackFuelLeft > 0)
        {
            jetpackFuelLeft -= 1 * Time.deltaTime;
            mainChar.ApplyForceToDirection(transform.up, jetpackForce, true);
        }
        else
        {
            onCooldown = true;
            StartCoroutine(WaitForCooldown());
            StartCoroutine(RefillFuell());
        }
    }

    IEnumerator RefillFuell()
    {
        var elapsedTime = 0f;
        while (elapsedTime < cooldown)
        {
            jetpackBar.color = Color.Lerp(Color.red, Color.green, elapsedTime / cooldown);
            float t = elapsedTime / cooldown;
            jetpackFuelLeft = Mathf.Lerp(0f, jetpackFuelMax, t);
            jetpackBar.fillAmount = jetpackFuelLeft / jetpackFuelMax;

            elapsedTime += Time.deltaTime;
            
            yield return null;
        }

    }
}
