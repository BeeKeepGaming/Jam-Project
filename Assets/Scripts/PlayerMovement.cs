
using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/* Eugene van den berg
 * Created 15/04/2023
 * Updated 20/04/2023
 * Version: 0
 */

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 250;
    public float jumpHight = 20;
    public LayerMask Ground;

    private int sprintSpeed = 1;
    private Vector3 move;
    private Vector2 look;
    public Rigidbody player;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

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
        if (context.performed)
        {
            sprintSpeed = 2;
        }
        else
        {
            sprintSpeed = 1;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        movePlayer();
        lookPlayer();
    }

    private void movePlayer()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movement = move.y * Camera.main.transform.forward + move.x * Camera.main.transform.right;

        transform.rotation = Quaternion.LookRotation(cameraForward.normalized, Vector3.up);
        var newMove = movement * moveSpeed * sprintSpeed * Time.fixedDeltaTime;
        player.velocity = new Vector3(newMove.x, player.velocity.y, newMove.z);
    }

    private void lookPlayer()
    {
        this.transform.Rotate(Vector3.up, look.x);
    }

    private void Jump()
    {
        player.AddForce(Vector3.up * jumpHight,ForceMode.Impulse);
    }

    /* Vector3.Scale. takes two vectors and multiplies it with each other to get a new vector
     * Quaternion.LookRotation transform the players rotation the the absolute of the camera
     */
}
