using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AStarAlgorithm : IPathAlgorithmBase {

    private class PriorityQueue
    {
        List<KeyValuePair<MapNode, float>> queue;

        public PriorityQueue()
        {
            queue = new List<KeyValuePair<MapNode, float>>();
        }

        public void Enqueue(MapNode node, float priority)
        {
            KeyValuePair<MapNode, float> temp = new KeyValuePair<MapNode, float>(node, priority);
            queue.Add(temp);
            SortAscending();
        }

        private void SortAscending()
        {
            queue=queue.OrderBy(x => x.Value).ToList();
        }

        public KeyValuePair<MapNode, float> Dequeue()
        {
            KeyValuePair<MapNode, float> temp = queue[0];
            queue.RemoveAt(0);
            return temp;
        }

        public bool IsEmpty()
        {
            return queue.Count == 0;
        }

        public MapNode[] ReturnCurrentNodesAsArray()
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


        public string DebugQueue()
        {
            string temp = "";
            foreach(KeyValuePair<MapNode, float> k in queue)
            {
                temp += k.Value.ToString()+", ";
            }
            return temp;
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
                Debug.Log("Path found! "+this.ToString());
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
            pathfindingInfo.FrontierByOrder.Add(frontier.ReturnCurrentNodesAsArray());
            pathfindingInfo.iterations++;
        }
        Debug.Log("Path not found!");
        return false;
    }


}
