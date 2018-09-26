using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PathfindingInfo : ScriptableObject {

    public string AlgorithmUsed;
    public int iterations;
    public bool pathFound;
    public List<Vector2> pathPositions;
    public List<Vector2> visitedByIterations;
    public List<MapNode[]> FrontierByOrder;

    public void  CleanInfo()
    {
        AlgorithmUsed = "";
        iterations = 0;
        pathFound = false;
        pathPositions = new List<Vector2>();
        visitedByIterations = new List<Vector2>();
        FrontierByOrder = new List<MapNode[]>();
    }
}
