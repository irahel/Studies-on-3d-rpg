using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {
    [HideInInspector] 
    public float stop_distance = 3f;
    public NavMeshAgent playerAgent;
    private bool hasInteracted;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.destination = this.transform.position;
        playerAgent.stoppingDistance = stop_distance;
        //Interact();
    }

    void Update()
    {
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with this");
    }
}
