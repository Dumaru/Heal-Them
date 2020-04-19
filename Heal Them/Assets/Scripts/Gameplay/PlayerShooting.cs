using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private GameObject projectile;
    #endregion

    private void Update()
    {
        CheckMouseInput();
    }
    private void CheckMouseInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Shoot a projectile
            GameObject projectileTemp = Instantiate(projectile, weapon.transform.position, weapon.transform.rotation);
        }
    }
}