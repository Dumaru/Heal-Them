using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    #region Fields
    public GameObject healthyBody;
    public float initialZombieHealth = 100;
    public float currentHealth;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead = false;
    #endregion

    #region Methods
    private void Start()
    {
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = initialZombieHealth;
    }

    internal void TakeDamage(int attackAmount, ContactPoint contactPoint, ProjectileType projectileType)
    {
        if (isDead) return;
        currentHealth -= attackAmount;
        hitParticles.transform.position = contactPoint.point;
        hitParticles.Play();
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
        capsuleCollider.isTrigger = true;
        GetComponent<NavMeshAgent>().enabled = false;

        Destroy(gameObject, 4);
    }

    #endregion
}