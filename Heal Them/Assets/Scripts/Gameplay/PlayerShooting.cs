using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private GameObject projectile;
    ProjectileType projectileType = ProjectileType.Kill;
    HUD hud;
    #endregion

    private void Start()
    {
        hud = FindObjectOfType<HUD>();
    }
    private void Update()
    {
        CheckMouseInput();
    }
    private void CheckMouseInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Main Projectile");
            projectileType = ProjectileType.Kill;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Healing Projectile");
            projectileType = ProjectileType.Heal;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Dragging Projectile");
            projectileType = ProjectileType.Drag;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Shoot a projectile
            if (projectileType.Equals(ProjectileType.Kill) && hud.ammoLeft > 0)
            {
                GameObject projectileTemp = Instantiate(projectile, weapon.transform.position, weapon.transform.rotation);
                projectileTemp.GetComponent<Projectile>().ProjectileType = projectileType;
                hud.UpdateAmmo(-1);
            }
            else if (projectileType.Equals(ProjectileType.Heal) && hud.antidotesLeft > 0)
            {
                GameObject projectileTemp = Instantiate(projectile, weapon.transform.position, weapon.transform.rotation);
                projectileTemp.GetComponent<Projectile>().ProjectileType = projectileType;
                hud.UpdateAntidotes(-1);
            }
        }
    }
}