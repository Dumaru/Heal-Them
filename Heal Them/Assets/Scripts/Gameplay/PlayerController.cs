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
    private Animator playerAnim;

    #endregion

    #region Properties

    #endregion

    #region Methods
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (GetComponent<PlayerHealth>().currentHealth > 0)
        {
            RotateTowardsMouse();
            Move(h, v);
            Animate(h, v);
        }
    }

    private void Animate(float h, float v)
    {
        Debug.Log("Animate");
        bool moving = h != 0 || v != 0;
        playerAnim.SetBool("IsMoving", moving);
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

    private void Move(float h, float v)
    {
        velocity = new Vector3(h, 0, v);
        velocity = velocity.normalized * moveSpeed;
        playerRb.MovePosition(playerRb.position + velocity * Time.fixedDeltaTime);
    }


    #endregion
}