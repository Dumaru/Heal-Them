using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{

    HUD hud;
    HumansManager humansManager;
    public int pointsWorth = 10;
    // Start is called before the first frame update
    void Start()
    {
        hud = FindObjectOfType<HUD>();
        humansManager = FindObjectOfType<HumansManager>();
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
                Debug.Log("Increase points");
                hud.UpdateScore(pointsWorth);
                Destroy(other.gameObject, 2);
            }
        }
    }
}
