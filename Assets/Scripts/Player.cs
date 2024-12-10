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
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        InputManager.Init(this);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = (moveDir * moveSpeed);
        if (moveDir.x == -1 )
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (moveDir.x == 1)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (moveDir.z == 1)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveDir.z == -1)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (rb.velocity != new Vector3(0,0,0))
        {
            animator.SetLayerWeight(3, 1);
        }
        else
        {
            animator.SetLayerWeight(3, 0);
        }
    }
    internal void SetMoveDirection(Vector3 currentDir)
    {
        moveDir = currentDir;
    }
}
