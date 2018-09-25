using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFSAlgorithm : IPathAlgorithmBase{

    public bool Search(MapGraph mapGraph, MapNode startNode, MapNode finishNode, PathfindingInfo pathfindingInfo)
    {
        Queue<MapNode> frontier = new Queue<MapNode>();
        frontier.Enqueue(startNode);

        mapGraph.AddPreviousNode(startNode, startNode);

        while (frontier.Count > 0)
        {
            MapNode currentNode = frontier.Dequeue();
            pathfindingInfo.visitedByIterations.Add(currentNode.GetPosition());

            if (currentNode == finishNode)
            {
                Debug.Log("Path found!");
                pathfindingInfo.pathPositions= MarkThePath(mapGraph, startNode, finishNode);
                return true;
            }

            foreach (MapNode next in mapGraph.Neighbours(currentNode))
            {
                if (!mapGraph.IsVisited(next))
                {
                    if (!frontier.Contains(next))
                        frontier.Enqueue(next);
                    mapGraph.AddPreviousNode(next, currentNode);
                }
            }
            pathfindingInfo.FrontierByOrder.Add(frontier.ToArray());
            pathfindingInfo.iterations++;
        }
        Debug.Log("Path not found!");
        return false;
    }

    private List<Vector2> MarkThePath(MapGraph mapGraph, MapNode startNode, MapNode finishNode)
    {
        List<Vector2> pathPosList = new List<Vector2>();
        MapNode currentNode = finishNode;
        while (currentNode != startNode)
        {
            if (currentNode != mapGraph.CameFrom(currentNode))
            {
                pathPosList.Add(currentNode.GetPosition());
                currentNode = mapGraph.CameFrom(currentNode);
            }
            else break;

        }
        return pathPosList;
    }


}
