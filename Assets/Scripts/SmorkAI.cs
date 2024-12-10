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
        }
        else
        {
            agent.destination = gameObject.transform.position; 
        }
        
    }
}
