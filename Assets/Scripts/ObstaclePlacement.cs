using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePlacement{

    public bool TryToPlaceRandomObstacle(Dictionary<Vector2, string> generatedMapDic, Vector2 startPoint, string obstacleToSet)
    {
        if (!generatedMapDic[startPoint].Equals(Keys.NodeTypes.MAP)) return false;

        if (obstacleToSet.Equals(Keys.NodeTypes.OBSTACLE_1_1))
            return TryToPlaceObstacle1x1(generatedMapDic, startPoint);
        else if (obstacleToSet.Equals(Keys.NodeTypes.OBSTACLE_2_1))
            return TryToPlaceObstacle2x1(generatedMapDic, startPoint);
        else if (obstacleToSet.Equals(Keys.NodeTypes.OBSTACLE_1_2))
            return TryToPlaceObstacle1x2(generatedMapDic, startPoint);
        else if (obstacleToSet.Equals(Keys.NodeTypes.OBSTACLE_2_2))
            return TryToPlaceObstacle2x2(generatedMapDic, startPoint);

        return false;
    }

    private bool TryToPlaceObstacle1x1(Dictionary<Vector2, string> generatedMapDic, Vector2 startPoint)
    {
        generatedMapDic[startPoint] = Keys.NodeTypes.OBSTACLE_1_1;
        return true;
    }

    private bool TryToPlaceObstacle2x1(Dictionary<Vector2, string> generatedMapDic, Vector2 startPoint)
    {
        Vector2 tempKey = startPoint + new Vector2(1, 0);
        if (generatedMapDic.ContainsKey(tempKey))
            if (generatedMapDic[tempKey].Equals(Keys.NodeTypes.MAP))
            {
                generatedMapDic[startPoint] = Keys.NodeTypes.OBSTACLE_2_1;
                generatedMapDic[tempKey] = Keys.NodeTypes.OBSTACLE_2_1;
                return true;
            }
        return false;
    }

    private bool TryToPlaceObstacle1x2(Dictionary<Vector2, string> generatedMapDic, Vector2 startPoint)
    {
        Vector2 tempKey = startPoint + new Vector2(0, 1);
        if (generatedMapDic.ContainsKey(tempKey))
            if (generatedMapDic[tempKey].Equals(Keys.NodeTypes.MAP))
            {
                generatedMapDic[startPoint] = Keys.NodeTypes.OBSTACLE_1_2;
                generatedMapDic[tempKey] = Keys.NodeTypes.OBSTACLE_1_2;
                return true;
            }
        return false;
    }

    private bool TryToPlaceObstacle2x2(Dictionary<Vector2, string> generatedMapDic, Vector2 startPoint)
    {
        List<Vector2> tempKeys = new List<Vector2>() {
            startPoint + new Vector2(0, 1),
            startPoint + new Vector2(1, 0),
            startPoint + new Vector2(1, 1) };
        foreach( Vector2 key in tempKeys)
        {
            if (!generatedMapDic.ContainsKey(key))
                return false;
            if (!generatedMapDic[key].Equals(Keys.NodeTypes.MAP))
                return false;
        }
        foreach(Vector2 key in tempKeys)
        {
            generatedMapDic[key] = Keys.NodeTypes.OBSTACLE_2_2;
        }
        return true;
    }

}
