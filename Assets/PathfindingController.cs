﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingController : MonoBehaviour {

    private IPathAlgorithmBase pathfindingAlgorithm;
    [SerializeField]
    MapInfo mapInfo;
    public List<Vector2> DoPathfinding()
    {
        return pathfindingAlgorithm.FindShortestWay(mapInfo.renderedMapDictionary, mapInfo.startNode, mapInfo.finishNode);
    }

    public void SetPathfindingAlgorithm(string algorithm)
    {
        if(algorithm.Equals(Keys.Algorithms.A_STAR))
            pathfindingAlgorithm = new AStarAlgorithm();
    }
}
