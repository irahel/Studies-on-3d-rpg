using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

    NavMeshAgent playerAgent;
    Animator m_Animator;
    float movings;
    // Use this for initialization
    void Start()
    {
        movings = 0;
        m_Animator = GetComponent<Animator>();
        playerAgent = GetComponent<NavMeshAgent>();
        m_Animator.SetBool("Crouch", false);
        m_Animator.speed = 1;
        m_Animator.SetBool("OnGround", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            getInteraction();
        }

       
        //ssm_Animator.SetFloat("Turn", 1, 0.1f, Time.deltaTime);
        Debug.Log(playerAgent.pathStatus == NavMeshPathStatus.PathComplete);
        
        movings = ( playerAgent.velocity.magnitude / playerAgent.speed);
        
       
        //m_Animator.SetFloat("JumpLeg", jumpLeg);
        m_Animator.SetFloat("Forward", movings, 0.01f, Time.deltaTime);
    }

    void getInteraction()
    {
 
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.tag == "interactable_Object")
            {
                //Debug.Log("Interactable interacted");
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else
            {
                playerAgent.stoppingDistance = 0;
                playerAgent.destination = interactionInfo.point;
            }
        }
    }
}

