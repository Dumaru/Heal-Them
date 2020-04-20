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
    Animator playerAnim;
    [SerializeField]
    private AudioClip shotAudio;
    AudioSource audioSource;
    #endregion

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
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
            audioSource.Stop();
            audioSource.PlayOneShot(shotAudio);
            if (hud.ammoLeft > 0 || hud.antidotesLeft > 0)
            {
                playerAnim.SetTrigger("Shoot");
            }
            // Shoot a projectile
            if (projectileType.Equals(ProjectileType.Kill) && hud.ammoLeft > 0)
            {
                GameObject projectileTemp = Instantiate(projectile, weapon.transform.position, weapon.transform.rotation);
                projectileTemp.GetComponent<Projectile>().ProjectileType = projectileType;
                // hud.UpdateAmmo(-1);
            }
            else if (projectileType.Equals(ProjectileType.Heal) && hud.antidotesLeft > 0)
            {
                GameObject projectileTemp = Instantiate(projectile, weapon.transform.position, weapon.transform.rotation);
                projectileTemp.GetComponent<Projectile>().ProjectileType = projectileType;
                // hud.UpdateAntidotes(-1);
            }
        }
    }
}