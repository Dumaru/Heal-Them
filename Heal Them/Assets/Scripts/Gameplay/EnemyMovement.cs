using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(FieldOfView))]
public class EnemyMovement : MonoBehaviour
{
    #region Fields
    private Transform playerTarget;
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private bool chasingPlayer = false;
    private FieldOfView enemyFieldOfView;
    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        enemyFieldOfView = GetComponent<FieldOfView>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chasingPlayer)
        {
            navMeshAgent.enabled = true;
            navMeshAgent.SetDestination(playerTarget.position);
        }
        else
        {
            navMeshAgent.enabled = false;
        }
        // Check if visible targets
        chasingPlayer = false;
        foreach (Transform targetTransform in enemyFieldOfView.visibleTargets)
        {
            if (targetTransform != null && targetTransform.gameObject.CompareTag("Player"))
            {
                chasingPlayer = true;
                break;
            }
        }
    }

    #endregion


}
