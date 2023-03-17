using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnnemyAI : MonoBehaviour
{

    // Agent de navigation
    private UnityEngine.AI.NavMeshAgent agent;

    [SerializeField]
    private UnityEvent m_OnTouch;

    [SerializeField]
    private int TaDistanceQueTuConsidèreAssezPetite = 3;


    public Transform target;

    void Start()
    {// Find the player character
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {

        if (target != null)
        {
            agent.destination = target.position;
        }
        if (Vector3.Distance(target.position, transform.position) < TaDistanceQueTuConsidèreAssezPetite)
        {
            m_OnTouch.Invoke();
        }
    }
    
}