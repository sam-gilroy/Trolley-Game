﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Train : MonoBehaviour {

    public float speed;
    public bool leftPath = true;
    public Path[] pathList;
    protected NavMeshAgent agent;
    protected Path path;
    protected Transform currentTarget;
    protected int pathIndex;

    // Use this for initialization
    void Start () {
        path = pathList[0];
        agent = GetComponent<NavMeshAgent>();
        pathIndex = 0;
        agent.speed = speed;
    }
	
	// Update is called once per frame
	void Update () {
        if (path != null)
        {
            currentTarget = path.pathPoints[pathIndex].transform;

            if (Vector3.Distance(currentTarget.transform.position, transform.position) < 1.0f)
            {
                pathIndex++;
                if (pathIndex >= path.pathPoints.Count)
                {
                    if (path == pathList[0])
                    {
                        if (leftPath) path = pathList[1];
                        else path = pathList[2];
                        pathIndex = 0;
                    }
                    else path = null;
                }
            }

        }
        agent.SetDestination(currentTarget.position);
    }

    public void SetPath(Path p)
    {
        path = p;
    }

    public void SwitchDirection()
    {
        leftPath = !leftPath;
    }

}


