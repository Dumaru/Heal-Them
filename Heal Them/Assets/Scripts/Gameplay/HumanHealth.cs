using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class HumanHealth : MonoBehaviour
{
    #region Fields
    public float initialHealth = 100;
    public float currentHealth;
    public HumanState state = HumanState.Live;
    ParticleSystem hitParticlesDamage;
    ParticleSystem hitParticlesHeal;
    CapsuleCollider capsuleCollider;
    bool isDead = false;
    Animator animator;
    AudioSource audioSource;
    #endregion

    #region Methods
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        hitParticlesDamage = gameObject.transform.Find("Particles").Find("DamageParticles").GetComponent<ParticleSystem>();
        hitParticlesHeal = gameObject.transform.Find("Particles").Find("HealingParticles").GetComponent<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = initialHealth;
    }

    public void TakeDamage(int attackAmount)
    {
        if (isDead) return;
        if (hitParticlesDamage != null)
        {
            hitParticlesDamage.Play();
        }
        currentHealth -= attackAmount;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        // if (isMissionTarget)
        // {
        // //The target is death, you did not keep it alive.
        // Debug.Log("The mission target is dead =(");
        // }
        isDead = true;
        audioSource.Stop();
        audioSource.Play();
        if (animator != null) animator.SetTrigger("IsDead");
        capsuleCollider.isTrigger = true;
        GetComponent<NavMeshAgent>().enabled = false;
        Destroy(gameObject, 4);
    }

    #endregion
}
