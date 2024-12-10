using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Vector3 moveDir;
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = (moveDir * moveSpeed);
    }
    internal void SetMoveDirection(Vector3 currentDir)
    {
        moveDir = currentDir.normalized;
    }
}
