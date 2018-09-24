using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFSAlgorithm : IPathAlgorithmBase{

    public bool Search(MapGraph mapGraph, MapNode startNode, MapNode finishNode)
    {
        Queue<MapNode> frontier = new Queue<MapNode>();
        frontier.Enqueue(startNode);
        mapGraph.AddPreviousNode(startNode, startNode);

        while(frontier.Count>0)
        {
            MapNode currentNode = frontier.Dequeue();

            if (currentNode == finishNode)
            {
                return true;
            }
                
            
            foreach(MapNode next in mapGraph.Neighbours(currentNode))
            {
                if(mapGraph.CameFrom(next)!=null)
                {
                    frontier.Enqueue(next);
                    mapGraph.AddPreviousNode(next, currentNode);
                }
            }
        }

        return false;
    }
}
