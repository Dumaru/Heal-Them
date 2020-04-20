using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTarget : MonoBehaviour
{
    #region Fields
    EnemyHealth enemyHealth;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }


}
