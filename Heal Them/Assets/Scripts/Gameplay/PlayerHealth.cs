using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Fields
    public int initialHealh = 100;
    public int currentHealth;
    HUD hud;
    AudioSource audioSource;
    #endregion

    #region Properties
    public bool IsPlayerDeath => currentHealth <= 0;
    #endregion
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hud = FindObjectOfType<HUD>();
        currentHealth = initialHealh;
    }

    internal void TakeDamage(int attackDamage)
    {
        audioSource.Stop();
        audioSource.Play();
        currentHealth -= attackDamage;
        hud.UpdateHealth(currentHealth);
        if (currentHealth <= 0)
        {
            MenuManager.GoToMenu(MenuName.GameOver);
            Debug.Log("The player is dead");
        }

    }
}