using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Fields
    public int initialHealh = 100;
    public int currentHealth;
    HUD hud;
    AudioSource audioSource;
    Animator animator;

    ParticleSystem hitParticles;
    #endregion

    #region Properties
    public bool IsPlayerDeath => currentHealth <= 0;

    #endregion
    private void Start()
    {
        hitParticles = gameObject.transform.Find("Particles").Find("DamageParticles").GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        hud = FindObjectOfType<HUD>();
        currentHealth = initialHealh;
    }

    internal void TakeDamage(int attackDamage)
    {
        hitParticles.Play();
        audioSource.Stop();
        audioSource.Play();
        currentHealth -= attackDamage;
        hud.UpdateHealth(currentHealth);
        if (currentHealth <= 0)
        {
            animator.SetTrigger("IsDead");
            GetComponent<Rigidbody>().isKinematic = true;
            MenuManager.GoToMenu(MenuName.GameOver);
            Debug.Log("The player is dead");
        }

    }
}