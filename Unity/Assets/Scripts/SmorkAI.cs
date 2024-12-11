using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmorkAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform destination;
    [SerializeField] float distance;
    [SerializeField] float playerGap;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator animator;
    private float blendWeight;
    public GameObject attackTarget;
    public bool GoToTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, destination.position) > playerGap)
        {
            agent.destination = destination.position;
            distance = Vector3.Distance(gameObject.transform.position, destination.position);
            GoToTarget = false;
            
        }
        else
        {
            agent.destination = gameObject.transform.position; 
            
        }
        if (distance >= playerGap +0.1f)
        {
            if (blendWeight <1)
            {
                
                blendWeight += 0.01f;
            }
        }
        else if (distance <= playerGap + 0.1f)
        {
            if (blendWeight > 0)
            {
                blendWeight -= 0.01f;
                
            }
        }
        animator.SetLayerWeight(1, blendWeight);

        if (GoToTarget) 
        {
            if (Vector3.Distance(gameObject.transform.position, attackTarget.transform.position) > 1)
            {
                agent.destination = attackTarget.transform.position;

            }
            else
            {
                animator.SetTrigger("Attack");
            }
        }
    }
}
