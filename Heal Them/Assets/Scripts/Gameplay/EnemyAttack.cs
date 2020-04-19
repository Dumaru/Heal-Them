using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    #region Fields
    public int attackDamage = 10;
    public float timeBetweenAttacks = 0.5f;
    GameObject player;
    PlayerHealth playerHealth;
    [SerializeField]
    bool playerInRange = false;
    Timer coolDownTimer;
    #endregion

    #region Methods
    private void Start()
    {
        coolDownTimer = gameObject.AddComponent<Timer>();
        coolDownTimer.Duration = timeBetweenAttacks;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (playerInRange && coolDownTimer.Finished)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
        coolDownTimer.Duration = timeBetweenAttacks;
        coolDownTimer.Run();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coolDownTimer.Run();
            playerInRange = true;
        }
    }
    #endregion
}