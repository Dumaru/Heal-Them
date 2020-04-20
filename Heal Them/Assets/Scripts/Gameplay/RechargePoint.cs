using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargePoint : MonoBehaviour
{
    HUD hud;
    [SerializeField]
    protected int amount;
    [SerializeField]
    protected ProjectileType projectileType;
    // Start is called before the first frame update
    void Start()
    {
        hud = FindObjectOfType<HUD>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (projectileType.Equals(ProjectileType.Kill))
            {
                hud.UpdateAmmo(amount);
            }
            else if (projectileType.Equals(ProjectileType.Heal))
            {
                // hud.UpdateAntidotes(amount);
            }
            Destroy(gameObject, 0.3f);
        }

    }
}
