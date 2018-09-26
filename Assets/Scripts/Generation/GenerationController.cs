using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GenerationController : MonoBehaviour {

    [SerializeField]
    MapInfo mapInfo;
    [SerializeField]
    RenderController renderController;

    private void OnEnable()
    {
        Assert.IsNotNull(mapInfo, "There is no map informations in generation controller!");
        Assert.IsNotNull(renderController, "There is no render controller reference in generation controller!");
    }

    public void Generate()
    {
        GenerateCleanMap();
        GenerateStartAndFinishOnMap();
        GenerateObstaclesOnMap();
        renderController.RenderMap();

    }

    private void GenerateCleanMap()
    {
        Debug.Log("Generating Clean map");
        mapInfo.generatedMapDictionary = new Dictionary<Vector2, MapNode>();
        for (int i = 0; i < mapInfo.mapSize; i++)
        {
            for (int j = 0; j < mapInfo.mapSize; j++)
            {
                Vector2 tempVector = Vector2.zero + new Vector2((float)i, (float)j);
                mapInfo.generatedMapDictionary.Add(tempVector, new MapNode(tempVector, Keys.NodeTypes.MAP));
            }
        }
    }

    private void GenerateStartAndFinishOnMap()
    {
        Debug.Log("Generating SandF");
        bool isStartSet=false;
        bool isFinishSet=false;
        while(!isStartSet)
        {
            Vector2 tempKey = ReturnRandomMapDictionaryKey();
            Debug.Log(tempKey.ToString());
            if (mapInfo.generatedMapDictionary[tempKey].GetNodeType().Equals(Keys.NodeTypes.MAP))
            {
                MapNode tempNode = mapInfo.generatedMapDictionary[tempKey];
                tempNode.ChangeType(Keys.NodeTypes.START);
                mapInfo.startNode = tempNode;
                isStartSet = true;
            }
        }
        while (!isFinishSet)
        {
            Vector2 tempKey = ReturnRandomMapDictionaryKey();
            Debug.Log(tempKey.ToString());
            if (mapInfo.generatedMapDictionary[tempKey].GetNodeType().Equals(Keys.NodeTypes.MAP))
            {
                MapNode tempNode = mapInfo.generatedMapDictionary[tempKey];
                tempNode.ChangeType(Keys.NodeTypes.FINISH);
                mapInfo.finishNode = tempNode;
                isFinishSet = true;
            }
        }
    }

    private void GenerateObstaclesOnMap()
    {
        Debug.Log("Generating Obstacles");
        for (int i = 0; i<mapInfo.obstacleQuantity; i++)
        {
            bool isObstacleSet = false;
            while (!isObstacleSet)
            {
                isObstacleSet = TryToPlaceObstacle(ReturnRandomMapDictionaryKey());
            }
        }
    }

    private Vector2 ReturnRandomMapDictionaryKey()
    {
        List<Vector2> mapKeyList = new List<Vector2>(mapInfo.generatedMapDictionary.Keys);
        return mapKeyList[Random.Range(0, mapKeyList.Count)];
    }

    private bool TryToPlaceObstacle(Vector2 place)
    {
        if (!mapInfo.generatedMapDictionary[place].GetNodeType().Equals(Keys.NodeTypes.MAP))
            return false;
        mapInfo.generatedMapDictionary[place].ChangeType(Keys.NodeTypes.OBSTACLE);
        return true;
    }
}
