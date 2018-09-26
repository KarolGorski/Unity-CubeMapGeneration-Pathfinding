using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGraph{

    private Dictionary<MapNode, MapNode[]> edges;
    private Dictionary<MapNode, MapNode> cameFrom;

    public MapGraph(Dictionary<Vector2, MapNode> nodes)
    {
        edges = new Dictionary<MapNode, MapNode[]>();
        cameFrom = new Dictionary<MapNode, MapNode>();
        ConstructGraph(nodes);
    }

    public MapNode[] Neighbours(MapNode node)
    {
        return edges[node];
    }

    public bool IsVisited(MapNode node)
    {
        if (cameFrom.ContainsKey(node))
            return true;
        else return false;
    }

    public MapNode CameFrom(MapNode node)
    {
        if (cameFrom.ContainsKey(node))
            return cameFrom[node];
        else
            return node;
    }

    public void AddEdges(MapNode node, MapNode[] neighbours)
    {
        edges.Add(node, neighbours);
    }

    public void AddPreviousNode(MapNode currentNode, MapNode nodeBefore)
    {
        if(!cameFrom.ContainsKey(currentNode))
            cameFrom.Add(currentNode, nodeBefore);
    }

    public void ConstructGraph(Dictionary<Vector2, MapNode> nodes)
    {
        foreach(KeyValuePair<Vector2, MapNode> currentNode in nodes)
        {
            List<MapNode> currentNeighbours = new List<MapNode>();

            for(float i=-1;i<=1;i++)
                for(float j=-1;j<=1;j++)
                    CheckAndAddIfNeighbourAtPos(nodes, currentNode.Key, new Vector2(i,j), currentNeighbours);

            if (currentNeighbours.Count > 0)
                edges.Add(currentNode.Value, currentNeighbours.ToArray());
        }
    }

    private void CheckAndAddIfNeighbourAtPos(Dictionary<Vector2, MapNode> nodes, Vector2 currentNodePos, Vector2 offsetToAdd, List<MapNode> neighboursList)
    {
        Vector2 neighbourVec = currentNodePos + offsetToAdd;
        if (nodes.ContainsKey(neighbourVec))
            if (!nodes[neighbourVec].GetNodeType().Equals(Keys.NodeTypes.OBSTACLE))
                neighboursList.Add(nodes[neighbourVec]);
    }
}
