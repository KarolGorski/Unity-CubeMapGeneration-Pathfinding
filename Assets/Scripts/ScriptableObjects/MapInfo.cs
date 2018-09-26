using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MapInfo : ScriptableObject {

    public int mapSize;
    public int obstacleQuantity;
    public Dictionary<Vector2, MapNode> generatedMapDictionary;
    public MapNode startNode, finishNode;
    public MapGraph mapGraph;

}
