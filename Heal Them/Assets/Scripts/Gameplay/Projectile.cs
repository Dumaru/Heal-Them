using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float force = 100;
    private Rigidbody projectileRb;
    private Timer lifeTimer;
    private float duration = 5;
    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = gameObject.AddComponent<Timer>();
        lifeTimer.Duration = duration;
        lifeTimer.AddTimerFinishedListener(HandleLifeTimerFinishedEvent);
        lifeTimer.Run();
        StartMoving(this.transform.forward);
    }

    private void HandleLifeTimerFinishedEvent()
    {
        Destroy(gameObject);
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
}
