using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AStarAlgorithm : IPathAlgorithmBase {

    private class PriorityQueue
    {
        Queue<KeyValuePair<MapNode, float>> queue;

        public PriorityQueue()
        {
            queue = new Queue<KeyValuePair<MapNode, float>>();
        }

        public void Enqueue(MapNode node, float priority)
        {
            KeyValuePair<MapNode, float> temp = new KeyValuePair<MapNode, float>(node, priority);
            queue.Enqueue(temp);
            SortDescending();
        }

        private void SortDescending()
        {
            queue.OrderByDescending(x => x.Value);
        }

        public KeyValuePair<MapNode, float> Dequeue()
        {
            return queue.Dequeue();
        }

        public bool IsEmpty()
        {
            return queue.Count == 0;
        }

        public MapNode[] ReturnCurrentFrontier()
        {
            List<MapNode> currentFrontier=new List<MapNode>();
            foreach(KeyValuePair<MapNode, float> k in queue)
            {
                currentFrontier.Add(k.Key);

            }
            return currentFrontier.ToArray();
        }

        public bool Contains(MapNode node)
        {
            foreach (KeyValuePair<MapNode, float> k in queue)
            {
                if (k.Key.Equals(node))
                    return true;
            }
            return false;
        }
    }

    private float Heuristic(MapNode a, MapNode b)
    {
        return Vector2.Distance(a.GetPosition(), b.GetPosition());
    }


    public bool Search(MapGraph mapGraph, MapNode startNode, MapNode finishNode, PathfindingInfo pathfindingInfo)
    {
        PriorityQueue frontier = new PriorityQueue();
        Dictionary<MapNode, float> cost_of_node = new Dictionary<MapNode, float>();

        frontier.Enqueue(startNode, Heuristic(startNode, finishNode));
        mapGraph.AddPreviousNode(startNode, startNode);
        cost_of_node.Add(startNode, 0);

        while(!frontier.IsEmpty())
        {
            MapNode currentNode = frontier.Dequeue().Key;
            pathfindingInfo.visitedByIterations.Add(currentNode.GetPosition());

            if(currentNode.Equals(finishNode))
            {
                Debug.Log("Path found!");
                return true;
            }

            foreach(MapNode next in mapGraph.Neighbours(currentNode))
            {
                float new_cost = cost_of_node[currentNode] + Heuristic(currentNode, next);
                if(!cost_of_node.ContainsKey(next) || new_cost < cost_of_node[next])
                {
                    if (!cost_of_node.ContainsKey(next))
                        cost_of_node.Add(next, new_cost);
                    else
                        cost_of_node[next] = new_cost;

                    float priority = new_cost + Heuristic(next, finishNode);
                    if (!frontier.Contains(next))
                        frontier.Enqueue(next, priority);
                    mapGraph.AddPreviousNode(next, currentNode);
                }
            }
            pathfindingInfo.FrontierByOrder.Add(frontier.ReturnCurrentFrontier());
            pathfindingInfo.iterations++;
        }
        Debug.Log("Path not found!");
        return false;
    }


}
