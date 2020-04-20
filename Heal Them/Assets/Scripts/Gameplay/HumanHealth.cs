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
    #endregion

    #region Methods
    private void Start()
    {
        animator = GetComponent<Animator>();
        hitParticlesDamage = gameObject.transform.Find("Particles").Find("DamageParticles").GetComponent<ParticleSystem>();
        hitParticlesHeal = gameObject.transform.Find("Particles").Find("HealingParticles").GetComponent<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = initialHealth;
    }

    public void TakeDamage(int attackAmount)
    {
        if (isDead) return;
        currentHealth -= attackAmount;
        hitParticlesDamage.Play();
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
        animator.SetTrigger("IsDead");
        isDead = true;
        capsuleCollider.isTrigger = true;
        GetComponent<NavMeshAgent>().enabled = false;
        Destroy(gameObject, 2);
    }

    #endregion
}
