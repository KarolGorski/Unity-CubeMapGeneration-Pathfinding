﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarAlgorithm : IPathAlgorithmBase {

    List<MapNode> openList;
    List<MapNode> closedList;

    public AStarAlgorithm()
    {
        openList = new List<MapNode>();
        closedList = new List<MapNode>();
    }

    public List<Vector2> FindShortestWay(Dictionary<Vector2, MapNode> MapNodes, MapNode startNode, MapNode finishNode)
    {
        closedList.Add(startNode);
        Debug.LogError("A* Pathfinding not implemented");
        return new List<Vector2>();
    }

    public bool Search(MapGraph mapGraph, MapNode startNode, MapNode finishNode)
    {
        return true;
    }

    public bool Search(MapGraph mapGraph, MapNode startNode, MapNode finishNode, float timeOffset, RenderController renderController)
    {
        throw new System.NotImplementedException();
    }

    public bool Search(MapGraph mapGraph, MapNode startNode, MapNode finishNode, PathfindingInfo pathfindingInfo)
    {
        throw new System.NotImplementedException();
    }
}