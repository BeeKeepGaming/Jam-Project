using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

/* Eugene van den berg
 * Created 15/04/2023
 * Updated 20/04/2023
 * Version: 0
 */

public class PlayerMovement : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;

    public float moveSpeed;
    public int sprintSpeed = 1;
    private Vector2 move, look;
    private bool sprinting = false;
    public Rigidbody player;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        sprinting = context.ReadValue<bool>();
    }

    void FixedUpdate()
    {
        movePlayer();
        lookPlayer();
    }

    public void movePlayer()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movement = move.y * cameraForward + move.x * Camera.main.transform.right;

        player.velocity = movement * moveSpeed * sprintSpeed * Time.fixedDeltaTime;

        transform.rotation = Quaternion.LookRotation(cameraForward.normalized, Vector3.up);
    }

    public void lookPlayer()
    {
        this.transform.Rotate(Vector3.up, look.x);
    }

    #region What I've learned
    /* Vector3.Scale. takes two vectors and multiplies it with each other to get a new vector
     * Quaternion.LookRotation transform the players rotation the the absolute of the camera
     */
    #endregion
}
