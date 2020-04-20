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
    bool chasingTarget = false;
    FieldOfView enemyFieldOfView;
    EnemyHealth health;
    Transform safeZone;
    Animator animator;
    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        safeZone = GameObject.Find("Safe Zone").transform;
        health = GetComponent<EnemyHealth>();
        enemyFieldOfView = GetComponent<FieldOfView>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is visible
        foreach (Transform targetTransf in enemyFieldOfView.visibleTargets)
        {
            Debug.Log("Visible tag " + targetTransf.tag);
            if (targetTransf != null &&
                targetTransf.gameObject.CompareTag("Human") &&
                targetTransf.gameObject.GetComponent<HumanMovement>().DistanceToSafeZone > 6
                )
            {
                targetTransform = targetTransf;
                break;

            }
            else if (targetTransf != null)
            {
                targetTransform = targetTransf;
                break;
            }
        }

        if (targetTransform != null)
        {
            SetTarget(targetTransform);
        }
        else
        {
            chasingTarget = false;
            navMeshAgent.enabled = false;
        }

        animator.SetBool("Walking", chasingTarget);

    }

    public void SetTarget(Transform target)
    {
        chasingTarget = true;
        navMeshAgent.enabled = true;
        navMeshAgent.SetDestination(target.position);

    }
    #endregion


}
