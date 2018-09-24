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

    public MapNode CameFrom(MapNode node)
    {
        return cameFrom[node];
    }

    public void AddEdges(MapNode node, MapNode[] neighbours)
    {
        edges.Add(node, neighbours);
    }

    public void AddPreviousNode(MapNode currentNode, MapNode nodeBefore)
    {
        cameFrom.Add(currentNode, nodeBefore);
    }
    /// <summary>
    /// TO DO:
    ///     WRITE CONSTRUCTING GRAPH, Algorithm Selection and rendering
    /// </summary>
    /// <param name="nodes"></param>
    public void ConstructGraph(Dictionary<Vector2, MapNode> nodes)
    {

    }
}
