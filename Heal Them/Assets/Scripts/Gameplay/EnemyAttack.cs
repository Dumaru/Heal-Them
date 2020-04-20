using System;
using UnityEngine;
using UnityEngine.AI;

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
    bool attackingPlayer;
    HumanHealth humanHealth;
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
        if ((playerInRange || !attackingPlayer) && coolDownTimer.Finished)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (attackingPlayer && playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
        else if (!attackingPlayer)
        {
            humanHealth.TakeDamage(attackDamage);
            Debug.Log("Bite the human till he is dead");
        }
        coolDownTimer.Duration = timeBetweenAttacks;
        coolDownTimer.Run();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            attackingPlayer = true;
            coolDownTimer.Run();
            playerInRange = true;
        }
        else if (other.gameObject.CompareTag("Human"))
        {
            attackingPlayer = false;
            other.gameObject.GetComponent<HumanMovement>().DecreaseVelocity(0.5f);
            humanHealth = other.gameObject.GetComponent<HumanHealth>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            Debug.Log("Dejo de ser mordido");
            other.gameObject.GetComponent<HumanMovement>().ResetVelocity();
        }
    }
    #endregion
}