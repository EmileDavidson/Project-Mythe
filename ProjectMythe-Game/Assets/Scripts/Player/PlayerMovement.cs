using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveHor;
    private float moveVer;
    
    private bool _canMove = true;
    private bool _canRotate = true;
    
    //move an gravity speed
    [SerializeField] private float speed = 6f;
    [SerializeField] private float gravity = 20f;

    //controller movement
    [SerializeField] private Vector3 moveDirection = Vector3.zero;
    [SerializeField] private CharacterController controller;

    //jumps
    [SerializeField] private float jumpSpeed = 8f;
    [SerializeField] private int maxDoubleJumps = 2;
    private int jumps;
    
    //GameObjects
    [SerializeField] private Camera playerCam;
    [SerializeField] private Animator anim;

    // Update is called once per frame
    private void Update()
    {
        moveHor = Input.GetAxis("Horizontal");
        moveVer = Input.GetAxis("Vertical");
        Move();
    }

    public void Move()
    {
        if (_canMove == false) return;
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(moveHor / 2, 0, moveVer);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
            jumps = 0;
        } 
        else 
        {
            moveDirection = new Vector3(moveHor / 2, moveDirection.y, moveVer);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= speed;
            moveDirection.z *= speed;
            if (Input.GetKeyDown(KeyCode.Space) && jumps < maxDoubleJumps)
            {
                moveDirection.y = jumpSpeed;
                jumps++;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
