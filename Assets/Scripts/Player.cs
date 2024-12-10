using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.InputSystem;

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
    

    public bool attacking;
    /*
    [SerializeField] InputActionReference moveControl;
    [SerializeField] InputActionReference attackControl;

    private void OnEnable()
    {
        moveControl.action.Enable();
        attackControl.action.Enable();
    }

    private void OnDisable()
    {
        moveControl.action.Disable();
        attackControl.action.Disable();
    }
    */
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        //InputManager.Init(this);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        moveControl.action.performed += _ => {
            SetMoveDirection(_.ReadValue<Vector3>());
            Debug.Log("Move");
        };
        if (attackControl.action.WasPressedThisFrame())
        {
            attack();
        }*/

        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            dir += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += new Vector3(-1, 0, 0);

        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += new Vector3(1, 0, 0);

        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            attack();
        }

        moveDir = dir;
        //rb.velocity = (moveDir * moveSpeed);

        if (!attacking)
        {
            if (moveDir != new Vector3(0, 0, 0))
            {
                //rb.constraints = RigidbodyConstraints.None;
                if (walkvalue < 1)
                {
                    walkvalue += 0.1f;
                }
                animator.SetLayerWeight(1, walkvalue);
                //gameObject.transform.rotation = Quaternion.Euler(0, CamTransform.rotation.y, 0);

                Quaternion cameraRot = CamTransform.rotation;
                //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, CamTransform.rotation.y * 100, transform.rotation.z));
                transform.rotation = Quaternion.Euler(0, CamTransform.eulerAngles.y, 0);
                //transform.rotation = 

                //Debug.Log("S");
            }
            else
            {
                //rb.constraints = RigidbodyConstraints.FreezeRotationY;
                animator.SetLayerWeight(1, walkvalue);
                if (walkvalue > 0)
                {
                    walkvalue -= 0.1f;
                }
            }
            smoothedMoveDir = Vector3.SmoothDamp(smoothedMoveDir, moveDir, ref smoothedMoveVelo, 0.1f);
            smoothedMoveDir = CamTransform.forward * moveDir.z + CamTransform.right * moveDir.x;
            rb.velocity = new Vector3(smoothedMoveDir.x * moveSpeed, -3, smoothedMoveDir.z * moveSpeed);
        }
       

        


    }
    public void SetMoveDirection(Vector3 currentDir)
    {
        moveDir = currentDir;
    }

    public void attack()
    {
        if (!attacking)
        {
            animator.SetTrigger("Attack");
            //animator.SetLayerWeight(4, 1);
            attacking = true;
            animator.SetLayerWeight(1, 0);
            rb.velocity = Vector3.zero;
            StartCoroutine(AttackLock());
            

        }
    }


    IEnumerator AttackLock()
    {
        yield return new WaitForSeconds(1.2f);
        attacking = false;
    }
}
