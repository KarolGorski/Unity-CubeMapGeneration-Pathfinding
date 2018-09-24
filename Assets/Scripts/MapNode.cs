using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode{

    private Vector2 nodePosition;
    private string typeOfNode;

    public MapNode(Vector2 nodePosition, string typeOfNode)
    {
        this.nodePosition = nodePosition;
        this.typeOfNode = typeOfNode;
    }

    public void ChangeType(string type)
    {
        typeOfNode = type;
    }

    public string GetNodeType()
    {
        return typeOfNode;
    }

    public Vector2 GetPosition()
    {
        return nodePosition;
    }
}
