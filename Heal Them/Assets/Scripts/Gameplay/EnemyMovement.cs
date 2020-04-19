using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(FieldOfView))]
public class EnemyMovement : MonoBehaviour
{
    #region Fields
    Transform targetTransform;
    NavMeshAgent navMeshAgent;

    [SerializeField]
    bool chasingPlayer = false;
    FieldOfView enemyFieldOfView;
    EnemyHealth health;
    Transform safeZone;
    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        safeZone = GameObject.Find("Safe Zone").transform;
        health = GetComponent<EnemyHealth>();
        enemyFieldOfView = GetComponent<FieldOfView>();
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.state.Equals(EnemyState.Zombie))
        {
            // Check if player is visible
            foreach (Transform targetTransform in enemyFieldOfView.visibleTargets)
            {
                if (targetTransform != null && targetTransform.gameObject.CompareTag("Player"))
                {
                    SetTarget(targetTransform);
                    break;
                }
                else
                {
                    navMeshAgent.enabled = false;
                }
            }
        }
        else
        {
            // Send enemy to safe zone
            SetTarget(safeZone);
        }

    }

    public void SetTarget(Transform target)
    {
        navMeshAgent.enabled = true;
        navMeshAgent.SetDestination(target.position);

    }
    #endregion


}
