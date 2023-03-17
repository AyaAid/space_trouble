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

    [SerializeField]
    private int TaDistanceQueTuConsidèreAssezPetite2 = 30;


    public Transform target;

    [SerializeField]
    public Transform[] destinations; // tableau de destinations


    void Start()
    {// Find the player character
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        StartCoroutine(ChangeDestinationCoroutine());
    }

    void Update()
    {


        if (Vector3.Distance(target.position, transform.position) < TaDistanceQueTuConsidèreAssezPetite)
        {
            m_OnTouch.Invoke();
        }
        if (Vector3.Distance(target.position, transform.position) < TaDistanceQueTuConsidèreAssezPetite2)
        {
            if (target != null)
            {
                agent.destination = target.position;
            }
        }
        if (Vector3.Distance(target.position, transform.position) >= TaDistanceQueTuConsidèreAssezPetite2)
        {
            StartCoroutine(ChangeDestinationCoroutine());
        }
    }
    IEnumerator ChangeDestinationCoroutine()
    {
        int currentDestinationIndex = 0;

        while (true)
        {
            yield return new WaitForSeconds(15f); // attendre 15 secondes

            currentDestinationIndex++;

            if (currentDestinationIndex >= destinations.Length)
            {
                currentDestinationIndex = 0;
            }

            agent.destination = destinations[currentDestinationIndex].position;
        }

    }

}