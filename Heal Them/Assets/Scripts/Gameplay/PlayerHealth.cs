using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Fields
    public int initialHealh = 100;
    public int currentHealth;

    HUD hud;
    #endregion

    #region Properties
    public bool IsPlayerDeath => currentHealth <= 0;
    #endregion
    private void Start()
    {
        hud = FindObjectOfType<HUD>();
        currentHealth = initialHealh;
    }

    internal void TakeDamage(int attackDamage)
    {
        currentHealth -= attackDamage;
        hud.UpdateHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("The player is dead");
        }

    }
}