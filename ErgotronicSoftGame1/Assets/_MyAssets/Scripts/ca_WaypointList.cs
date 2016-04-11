using UnityEngine;
using System.Collections;

public class ca_WaypointList : MonoBehaviour {

    public Transform[] waypoints;
    private Transform playerTarget;
    private int nextTarget = 0;
    private NavMeshAgent agent;
    private bool canPatrol = true;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        UpdateTarget(0);
	}
	
	// Update is called once per frame
	void Update () {
        if (canPatrol)
        {
            // Patrol Waypoints
            CheckArrive();
        }
        else
        {
            // Chase Player
            ChasePlayer();
        }
	}

    public void SetPartol(bool b)
    {
        if (b)
        {
            UpdateTarget(nextTarget);
        }
        canPatrol = b;
    }

    public void SetPlayerTarget(Transform player)
    {
        playerTarget = player;
    }

    private void ChasePlayer()
    {
        agent.destination = playerTarget.position;
    }

    private void UpdateTarget(int targetNum)
    {
        nextTarget = targetNum;
        agent.destination = waypoints[nextTarget].position;
    }

    private void CheckArrive()
    {
        if((waypoints[nextTarget].position - agent.transform.position).magnitude <= 2f)
        {
            nextTarget++;
            if (nextTarget >= waypoints.Length)
                nextTarget = 0;
            UpdateTarget(nextTarget);
        }
    }
}
