using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private int attackAmount = 10;
    [SerializeField]
    private ProjectileType projectileType = ProjectileType.Kill;
    [SerializeField]
    private float force = 100;
    private Rigidbody projectileRb;
    private Timer lifeTimer;
    private float duration = 5;

    #endregion

    #region Properties
    public ProjectileType ProjectileType
    {
        get => projectileType;
        set
        {
            projectileType = value;
            // Change color
        }
    }
    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = gameObject.AddComponent<Timer>();
        lifeTimer.Duration = duration;
        lifeTimer.AddTimerFinishedListener(HandleLifeTimerFinishedEvent);
        StartMoving(this.transform.forward);
    }

    private void HandleLifeTimerFinishedEvent()
    {
        Destroy(gameObject, 2);
    }

    public void StartMoving(Vector3 direction)
    {
        projectileRb = GetComponent<Rigidbody>();
        projectileRb.AddForce(direction * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Enemy hitted
            Debug.Log("Enemy hitted " + gameObject.name);
            EnemyHealth tempEnemeyHealth = other.gameObject.GetComponent<EnemyHealth>();
            tempEnemeyHealth.TakeDamage(attackAmount, other.GetContact(0), projectileType);
        }
        lifeTimer.Run();
    }
    #endregion

}
