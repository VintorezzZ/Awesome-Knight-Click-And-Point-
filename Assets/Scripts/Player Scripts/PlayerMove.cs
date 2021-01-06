using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;
    private CharacterController charController;
    private CollisionFlags collisionFlags = CollisionFlags.None;

    private float moveSpped = 5f;
    private bool canMove;
    private bool finished_Movement = true;

    private Vector3 target_Pos = Vector3.zero;
    private Vector3 player_Move = Vector3.zero;
    
    private float player_ToPointDistance;

    private float gravity = 9.8f;
    private float height;

    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        CalculateHeight();
        CheckIfFinishedMovement();
    }

    bool isGrounded()
    {
        return collisionFlags == CollisionFlags.CollidedBelow;
    }

    void CalculateHeight()
    {
        if (isGrounded())
        {
            height = 0f;
        }
        else
        {
            height -= gravity * Time.deltaTime;
        }
    }

    void CheckIfFinishedMovement()
    {
        if (!finished_Movement)
        {
            if (!anim.IsInTransition(0) && !anim.GetCurrentAnimatorStateInfo(0).IsName("Stand") &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                //normalized time of the animation is represented time from 0 to 1
                // 0 is the beginning of the animation
                // 0.5 is the middle
                // 1 is the end of the animation
                finished_Movement = true;
            }
        }
        else
        {
            MoveThePlayer();
            player_Move.y = height * Time.deltaTime;
            // CollisionFlags returns if we are moving or not
            collisionFlags = charController.Move(player_Move);
        }
    }
    
    void MoveThePlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //print("POINT IN screen SPACE"+Input.mousePosition);
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit))
            {
                if (hit.collider is TerrainCollider)
                {
                    player_ToPointDistance = Vector3.Distance(transform.position, hit.point);

                    //print("POINT IN WORLD SPACE" + hit.point);
                    
                    if (player_ToPointDistance >= 1.0f) 
                    {
                        canMove = true;
                        target_Pos = hit.point;
                    }
                }
            }
        } // if mouse button down
        
        if (canMove)
        {
            anim.SetFloat("Walk", 1.0f);

            Vector3 target_Temp = new Vector3(target_Pos.x, transform.position.y, target_Pos.z);

            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(target_Temp - transform.position), 15.0f * Time.deltaTime);

            player_Move = transform.forward * moveSpped * Time.deltaTime;

            if (Vector3.Distance(transform.position, target_Pos) <= 0.1f) 
            {
                canMove = false;
            }
        }
        else
        {
            player_Move.Set(0, 0, 0);
            anim.SetFloat("Walk", 0f);
        }
    }
}
