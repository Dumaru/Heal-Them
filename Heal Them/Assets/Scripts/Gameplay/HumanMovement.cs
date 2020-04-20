using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    #region Fields
    Transform targetTransform;
    NavMeshAgent navMeshAgent;

    [SerializeField]
    bool chasingTarget = false;
    HumanHealth health;
    Transform safeZone;
    Animator animator;

    float speed = 2;
    public float DistanceToSafeZone => Vector3.Distance(transform.position, safeZone.position);
    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        safeZone = GameObject.Find("Safe Zone").transform;
        health = GetComponent<HumanHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        speed = navMeshAgent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        chasingTarget = health.state.Equals(HumanState.Live);
        animator.SetBool("IsMoving", chasingTarget);
        if (chasingTarget)
        {
            SetTarget(safeZone);
        }
    }

    public void DecreaseVelocity(float amount)
    {
        navMeshAgent.speed -= speed * amount;
    }
    public void ResetVelocity()
    {
        navMeshAgent.speed = speed;
    }

    public void SetTarget(Transform target)
    {
        navMeshAgent.enabled = true;
        navMeshAgent.SetDestination(target.position);
    }
    #endregion

}
