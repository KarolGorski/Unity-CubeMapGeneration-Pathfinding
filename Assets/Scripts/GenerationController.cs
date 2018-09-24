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
        Assert.IsNotNull(renderController, "There is no render controller in generation controller!");
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
        mapInfo.generatedMapDictionary = new Dictionary<Vector2, string>();
        for (int i = 0; i < mapInfo.mapSize; i++)
        {
            for (int j = 0; j < mapInfo.mapSize; j++)
            {
                Vector2 tempVector = Vector2.zero + new Vector2((float)i, (float)j);
                mapInfo.generatedMapDictionary.Add(tempVector, Keys.NodeTypes.MAP);
            }
        }
    }

    private void GenerateStartAndFinishOnMap()
    {
        bool isStartSet=false;
        bool isFinishSet=false;
        while(!isStartSet)
        {
            Vector2 tempKey = ReturnRandomMapDictionaryKey();
            if (mapInfo.generatedMapDictionary[tempKey].Equals(Keys.NodeTypes.MAP))
            {
                mapInfo.generatedMapDictionary[tempKey] = Keys.NodeTypes.START;
                isStartSet = true;
            }
        }
        while (!isFinishSet)
        {
            Vector2 tempKey = ReturnRandomMapDictionaryKey();
            if (mapInfo.generatedMapDictionary[tempKey].Equals(Keys.NodeTypes.MAP))
            {
                mapInfo.generatedMapDictionary[tempKey] = Keys.NodeTypes.FINISH;
                isFinishSet = true;
            }
        }
    }

    private void GenerateObstaclesOnMap()
    {
        ObstaclePlacement obstaclePlacement = new ObstaclePlacement();
        for(int i = 0; i<mapInfo.obstacleQuantity; i++)
        {
            bool isObstacleSet = false;
            while (!isObstacleSet)
            {
                isObstacleSet = obstaclePlacement.TryToPlaceRandomObstacle(
                    mapInfo.generatedMapDictionary, 
                    ReturnRandomMapDictionaryKey(),
                    ReturnRandomObstacleFromObstacleList());
            }
        }
    }

    private Vector2 ReturnRandomMapDictionaryKey()
    {
        List<Vector2> mapKeyList = new List<Vector2>(mapInfo.generatedMapDictionary.Keys);
        return mapKeyList[Random.Range(0, mapKeyList.Count)];
    }

    private string ReturnRandomObstacleFromObstacleList()
    {
        return Keys.NodeTypes.OBSTACLE_TYPE_LIST[Random.Range(0, Keys.NodeTypes.OBSTACLE_TYPE_LIST.Count)];
    }

}
