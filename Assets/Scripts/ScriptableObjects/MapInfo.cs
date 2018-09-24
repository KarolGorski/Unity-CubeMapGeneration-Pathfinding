using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MapInfo : ScriptableObject {

    public int mapSize;
    public int obstacleQuantity;
    public Dictionary<Vector2, string> generatedMapDictionary;
    public Dictionary<Vector2, MapNode> renderedMapDictionary;
    public MapNode startNode, finishNode;
}
