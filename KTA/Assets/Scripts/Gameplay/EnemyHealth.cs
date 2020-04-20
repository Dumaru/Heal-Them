using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    #region Fields
    public GameObject healthyBody;
    public bool isMissionTarget = false;
    public float initialZombieHealth = 100;
    public float currentHealth;
    public EnemyState state = EnemyState.Zombie;
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
        hitParticlesDamage = gameObject.transform.Find("DamageParticles").GetComponent<ParticleSystem>();
        hitParticlesHeal = gameObject.transform.Find("HealingParticles").GetComponent<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = initialZombieHealth;
    }

    public void TakeDamage(int attackAmount, ContactPoint contactPoint, ProjectileType projectileType)
    {
        if (isDead) return;
        audioSource.Stop();
        audioSource.Play();
        if (projectileType.Equals(ProjectileType.Kill))
        {
            currentHealth -= attackAmount;
            hitParticlesDamage.transform.position = contactPoint.point;
            hitParticlesDamage.Play();
            if (currentHealth <= 0)
            {
                Death();
            }
        }
        else if (projectileType.Equals(ProjectileType.Heal))
        {
            // Turn back to human
            state = EnemyState.Human;
            hitParticlesHeal.transform.position = contactPoint.point;
            hitParticlesHeal.Play();
            // Debug.Log("It's now a human");
        }
    }

    public void TurnToZombie()
    {
        currentHealth = initialZombieHealth;
        state = EnemyState.Zombie;
    }

    private void Death()
    {
        // if (isMissionTarget)
        // {
        // //The target is death, you did not keep it alive.
        // Debug.Log("The mission target is dead =(");
        // }
        animator.SetTrigger("Dead");
        isDead = true;
        capsuleCollider.isTrigger = true;
        GetComponent<NavMeshAgent>().enabled = false;
        Destroy(gameObject, 2);
    }

    #endregion
}