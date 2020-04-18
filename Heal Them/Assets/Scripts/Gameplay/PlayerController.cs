using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    #region Fields
    public float moveSpeed = 6;

    private Rigidbody playerRb;
    private Camera viewCamera;
    private Vector3 velocity;

    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private GameObject projectile;

    #endregion

    #region Properties

    #endregion

    #region Methods
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }

    void Update()
    {
        RotateTowardsMouse();
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
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

    /// <summary>
    /// Rotares the player game object towards where the mouse position is
    /// </summary>
    private void RotateTowardsMouse()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        // Sets the vector components to get the angle
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        // Sets the angle between the player position and the mouse position
        // angle = Atan(sin/cos) in radians, so it converts that value to degrees
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        // Finally, applies the rotation to the transform
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle + 90, 0));
    }


    void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + velocity * Time.fixedDeltaTime);
    }
    #endregion
}