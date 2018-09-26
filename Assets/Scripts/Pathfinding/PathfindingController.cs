using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PathfindingController : MonoBehaviour {

    private IPathAlgorithmBase pathfindingAlgorithm;
    [SerializeField]
    MapInfo mapInfo;
    [SerializeField]
    PathfindingInfo pathfindingInfo;
    [SerializeField]
    Text algorithmLabelFromDropdown;
    [SerializeField]
    RenderController renderController;

    private void OnEnable()
    {
        Assert.IsNotNull(mapInfo, "There is no map info in Pathfinding Controller");
        Assert.IsNotNull(pathfindingInfo, "There is no pathfinding info in Pathfinding Controller");
        Assert.IsNotNull(algorithmLabelFromDropdown, "There is no algorithm label from dropdown UI in Pathfinding Controller");
        Assert.IsNotNull(renderController, "There is no renderController in Pathfinding Controller");
    }

    public void DoPathfinding()
    {
        pathfindingInfo.CleanInfo();
        mapInfo.mapGraph = new MapGraph(mapInfo.generatedMapDictionary);
        pathfindingInfo.pathFound=pathfindingAlgorithm.Search(mapInfo.mapGraph, mapInfo.startNode, mapInfo.finishNode, pathfindingInfo);
        pathfindingInfo.pathPositions = MarkThePath();
        renderController.RenderPathfinding();
    }

    public void SetPathfindingAlgorithm()
    {
        if(algorithmLabelFromDropdown.text.Equals(Keys.Algorithms.A_STAR))
            pathfindingAlgorithm = new AStarAlgorithm();
        if (algorithmLabelFromDropdown.text.Equals(Keys.Algorithms.BFS))
            pathfindingAlgorithm = new BFSAlgorithm();
        Debug.Log("Algorithm changed to: " + pathfindingAlgorithm.ToString());
    }

    private List<Vector2> MarkThePath()
    {
        List<Vector2> pathPosList = new List<Vector2>();
        MapNode currentNode = mapInfo.finishNode;
        while (currentNode != mapInfo.startNode)
        {
            if (currentNode != mapInfo.mapGraph.CameFrom(currentNode))
            {
                pathPosList.Add(currentNode.GetPosition());
                currentNode = mapInfo.mapGraph.CameFrom(currentNode);
            }
            else break;

        }
        return pathPosList;
    }
}
