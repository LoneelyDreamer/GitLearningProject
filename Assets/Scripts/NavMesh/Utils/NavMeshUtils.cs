using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshUtils
{
    public static float GetPathLenght(NavMeshPath path)
    {
        float pathLenght = 0;

        if (path.corners.Length > 1) 
        {
            for (int i = 1; i < path.corners.Length; i++)
            {
                pathLenght += Vector3.Distance(path.corners[i - 1], path.corners[i]);
            }
        }

        return pathLenght;
    }
    public static bool TryGetPath(Vector3 soursePosition, Vector3 targetPosition, NavMeshQueryFilter queryFilter, NavMeshPath pathToTarget)
    {
        if (NavMesh.CalculatePath(soursePosition, targetPosition, queryFilter, pathToTarget) && pathToTarget.status != NavMeshPathStatus.PathInvalid)
            return true;
        else
            return false;
    }

    public static bool TryGetPath(NavMeshAgent agent, Vector3 targetPosition, NavMeshPath pathToTarget)
    {
        if (agent.CalculatePath(targetPosition,  pathToTarget) && pathToTarget.status != NavMeshPathStatus.PathInvalid)
            return true;
        else
            return false;
    }
}
