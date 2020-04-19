using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth.state.Equals(EnemyState.Human))
            {
                Destroy(other.gameObject, 2);
                if (enemyHealth.isMissionTarget)
                {
                    // Mision cumplida
                    Debug.Log("Mision cumplida, el objetivo regreso sano y salvo");
                }
            }
        }
    }
}
