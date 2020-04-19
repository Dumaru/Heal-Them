using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Fields
    public float initialHealh = 100;
    public float currentHealth;

    #endregion

    #region Properties
    public bool IsPlayerDeath => currentHealth <= 0;
    #endregion
    private void Start()
    {
        currentHealth = initialHealh;
    }

    internal void TakeDamage(int attackDamage)
    {
        currentHealth -= attackDamage;
        if (currentHealth <= 0)
        {
            Debug.Log("The player is dead");
        }
    }
}