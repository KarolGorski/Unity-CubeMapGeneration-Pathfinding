using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGraph{

    public List<MapNode> listOfMapNodes;
    public bool[][] tableOfNodesEdges;

    

    public MapGraph(int mapSize)
    {
        if(listOfMapNodes==null)
            listOfMapNodes = new List<MapNode>();
        tableOfNodesEdges = new bool[mapSize][];

       // mapNodesDictionary = new Dictionary<Vector2, MapNode>();
    }

    public void ConstructGraph(int mapSize, int obstaclesQuantity)
    {
        listOfMapNodes = new List<MapNode>();

    }

    public void DeconstructGraph()
    {
        
        listOfMapNodes.Clear();
        tableOfNodesEdges = null;

    }

    public void AddNode(MapNode node)
    {
        listOfMapNodes.Add(node);
       // mapNodesDictionary.Add(node.transform.position, node);
    }
}
