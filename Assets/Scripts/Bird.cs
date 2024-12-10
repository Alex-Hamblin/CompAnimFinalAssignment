using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Splines;

public class Bird : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] bool follow;
    [SerializeField] Transform birdLocation;
    [SerializeField] bool goToMoogle;
    // Start is called before the first frame update
    void Start()
    {
        agent.enabled = true;
        gameObject.GetComponent<SplineAnimate>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            agent.destination = player.position;
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && follow == false)
        {
            gameObject.GetComponent<SplineAnimate>().enabled = false;
            agent.enabled = true;
            follow = true;
        }
        if (other.tag == "MoogleZone")
        {
            agent.SetDestination(birdLocation.position);
            follow = false;
        }
    }

}
