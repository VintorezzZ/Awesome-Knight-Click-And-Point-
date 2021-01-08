using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Image fillImage_1;
    public Image fillImage_2;
    public Image fillImage_3;
    public Image fillImage_4;
    public Image fillImage_5;
    public Image fillImage_6;

    private int[] fadeImages = new[] {0, 0, 0, 0, 0, 0};

    private Animator anim;
    private bool canAttack;

    private PlayerMove playerMove;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
    }


    
    void Update()
    {
        if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }

        CheckToFade();
        CheckInput();
    }

    private void CheckInput()
    {
        if (anim.GetInteger("Atk") == 0)
        {
            // 1-6 we are attacking, else 0 - we are moving
            if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            {
                playerMove.FinishedMovement = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // FadeImages[0] meaning image thats at index 0 e.g. the first image
            if (playerMove.FinishedMovement && fadeImages[0] != 1 && canAttack)
            {
                fadeImages[0] = 1;
                anim.SetInteger("Atk", 1);
                
                // set the target position to the current player position
                // so that the player does not move
                playerMove.TargetPos = transform.position;
                RemoveCursorPoint();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // FadeImages[0] meaning image thats at index 1 e.g. the first image
            if (playerMove.FinishedMovement && fadeImages[1] != 1 && canAttack)
            {
                fadeImages[1] = 1;
                anim.SetInteger("Atk", 2);
                
                // set the target position to the current player position
                // so that the player does not move
                playerMove.TargetPos = transform.position;
                RemoveCursorPoint();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (playerMove.FinishedMovement && fadeImages[2] != 1 && canAttack)
            {
                fadeImages[2] = 1;
                anim.SetInteger("Atk", 3);
                
                // set the target position to the current player position
                // so that the player does not move
                playerMove.TargetPos = transform.position;
                RemoveCursorPoint();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (playerMove.FinishedMovement && fadeImages[3] != 1 && canAttack)
            {
                fadeImages[3] = 1;
                anim.SetInteger("Atk", 4);
                
                // set the target position to the current player position
                // so that the player does not move
                playerMove.TargetPos = transform.position;
                RemoveCursorPoint();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (playerMove.FinishedMovement && fadeImages[4] != 1 && canAttack)
            {
                fadeImages[4] = 1;
                anim.SetInteger("Atk", 5);
                
                // set the target position to the current player position
                // so that the player does not move
                playerMove.TargetPos = transform.position;
                RemoveCursorPoint();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (playerMove.FinishedMovement && fadeImages[5] != 1 && canAttack)
            { 
                fadeImages[5] = 1; 
                anim.SetInteger("Atk", 6);
                
                // set the target position to the current player position
                // so that the player does not move
                playerMove.TargetPos = transform.position;
                RemoveCursorPoint();
            }
        }
        else
        {
            anim.SetInteger("Atk", 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            // Rotates the player to mouse position 
            
            Vector3 targetPos = Vector3.zero;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                targetPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }

            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(targetPos - transform.position), 15f * Time.deltaTime);

        }
    }
    private void CheckToFade()
    {
        if (fadeImages[0] == 1) 
        {
            if (FadeAndWait(fillImage_1, 1f))
            {
                fadeImages[0] = 0;
            }
        } 
        if (fadeImages[1] == 1) 
        {
            if (FadeAndWait(fillImage_2, 0.7f))
            {
                fadeImages[1] = 0;
            }
        }
        if (fadeImages[2] == 1) 
        {
            if (FadeAndWait(fillImage_3, 0.1f))
            {
                fadeImages[2] = 0;
            }
        }
        if (fadeImages[3] == 1) 
        {
            if (FadeAndWait(fillImage_4, 0.2f))
            {
                fadeImages[3] = 0;
            }
        }
        if (fadeImages[4] == 1) 
        {
            if (FadeAndWait(fillImage_5, 0.3f))
            {
                fadeImages[4] = 0;
            }
        }
        if (fadeImages[5] == 1) 
        {
            if (FadeAndWait(fillImage_6, 0.08f))
            {
                fadeImages[5] = 0;
            }
        }
    }
    
    bool FadeAndWait(Image fadeImg, float fadeTime)
    {
        bool faded = false;

        if (fadeImg == null)
            return faded;

        if (!fadeImg.gameObject.activeInHierarchy)
        {
            fadeImg.gameObject.SetActive(true);
            fadeImg.fillAmount = 1;
        }

        fadeImg.fillAmount -= fadeTime * Time.deltaTime;

        if (fadeImg.fillAmount <= 0.0f)
        {
            fadeImg.gameObject.SetActive(false);
            faded = true;
        }
        
        return faded;
    }

    void RemoveCursorPoint()
    {
        GameObject cursorObj = GameObject.FindGameObjectWithTag("Cursor");
        if (cursorObj)
            Destroy(cursorObj);
    }
}
