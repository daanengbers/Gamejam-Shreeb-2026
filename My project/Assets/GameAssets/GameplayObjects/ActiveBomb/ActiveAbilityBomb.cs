using System.Collections;
using UnityEngine;

public class ActiveAbilityBomb : ActiveAbilityBase
{
    public float explosionForce = 100f;
    public GameObject Model;
    public ParticleSystem ParticleSystem;

    public AudioSource audioSource;
    public AudioClip explosionSound;

    public override void Ability()
    {
        onCooldown = true;
        Explode();
    }

    public void Explode()
    {
        mainChar.ApplyForceToDirection(transform.up, explosionForce, true, -1);
        StartCoroutine(WaitForCooldown());

        ParticleSystem.Play();
        audioSource.PlayOneShot(explosionSound);

        Model.transform.localScale = new Vector3( 0.1f ,0.1f ,0.1f );

        StartCoroutine(RechargeBomb());
    }

    IEnumerator RechargeBomb()
    {
        var elapsedTime = 0f;

        Vector3 startScale = Model.transform.localScale;
        Vector3 targetScale = new Vector3(1f, 1f, 1f);

        while (elapsedTime < cooldown)
        {
            float t = elapsedTime / cooldown;
            Model.transform.localScale = Vector3.Lerp(startScale, targetScale, t);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

    }
}
