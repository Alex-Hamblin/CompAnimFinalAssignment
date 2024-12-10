using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Vector3 moveDir;
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator animator;
    private Vector3 smoothedMoveDir;
    private Vector3 smoothedMoveVelo;
    [SerializeField] private Transform CamTransform;
    // Start is called before the first frame update
    [SerializeField] float walkvalue;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        InputManager.Init(this);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.velocity = (moveDir * moveSpeed);

        
        if (moveDir != new Vector3(0,0,0))
        {
            if (walkvalue < 1)
            {
                walkvalue += 0.1f;
            }
            animator.SetLayerWeight(3, walkvalue);
            gameObject.transform.rotation = Quaternion.Euler(0, CamTransform.rotation.y * 100, 0);
        }
        else
        {
            animator.SetLayerWeight(3, walkvalue);
            if (walkvalue >0)
            {
                walkvalue -= 0.1f;
            }
        }

        smoothedMoveDir = Vector3.SmoothDamp(smoothedMoveDir, moveDir, ref smoothedMoveVelo, 0.1f);
        smoothedMoveDir = CamTransform.forward * moveDir.z + CamTransform.right * moveDir.x;
        rb.velocity = new Vector3(smoothedMoveDir.x * moveSpeed, -3, smoothedMoveDir.z * moveSpeed);

        


    }
    internal void SetMoveDirection(Vector3 currentDir)
    {
        moveDir = currentDir;
    }

    internal void attack()
    {
        
        animator.SetLayerWeight(4, 1);
        
        
    }
}
