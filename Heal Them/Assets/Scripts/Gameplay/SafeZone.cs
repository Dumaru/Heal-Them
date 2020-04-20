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
        if (other.gameObject.CompareTag("Human"))
        {
            HumanHealth humanHealth = other.gameObject.GetComponent<HumanHealth>();
            if (humanHealth.state.Equals(HumanState.Live))
            {
                // Mision cumplida
                Debug.Log("Increase points");
                Destroy(other.gameObject, 2);

            }
        }
    }
}
