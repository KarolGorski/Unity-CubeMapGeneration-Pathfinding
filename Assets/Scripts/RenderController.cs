using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderController : MonoBehaviour {
    [SerializeField]
    MapInfo mapInfo;
    [SerializeField]
    List<GameObject> mapPartsPrefabsList;
    [SerializeField]
    GameObject dynamicParent;

    [SerializeField]
    Material pathMaterial;
    [SerializeField]
    Material visitedMaterial;

    public void RenderMap()
    {
        mapInfo.renderedMapDictionary = new Dictionary<Vector2, MapNode>();

        Debug.LogError("Rendering obstacles by all their form not implemented");
        foreach(KeyValuePair<Vector2, string> mapSquare in mapInfo.generatedMapDictionary)
        {
            GameObject prefab = returnPrefabForName(mapSquare.Value);
            if (prefab.name.Contains(Keys.NodeTypes.OBSTACLE))
                prefab = returnPrefabForName(Keys.NodeTypes.OBSTACLE);
            GameObject temp = GameObject.Instantiate(prefab, mapSquare.Key, prefab.transform.rotation, dynamicParent.transform);
            MapNode tempNode = temp.AddComponent<MapNode>();
            tempNode.typeOfNode = mapSquare.Value;
            mapInfo.renderedMapDictionary.Add(temp.transform.position, tempNode);
            if (tempNode.typeOfNode.Equals(Keys.NodeTypes.START))
                mapInfo.startNode = tempNode;
            else if (tempNode.typeOfNode.Equals(Keys.NodeTypes.FINISH))
                mapInfo.finishNode = tempNode;
        }
    }

    public void RenderPath()
    {
        foreach (KeyValuePair<Vector2,MapNode> node in mapInfo.renderedMapDictionary)
        {
            if (node.Value.visited)
                node.Value.meshRenderer.material = visitedMaterial;
            if (node.Value.path)
                node.Value.meshRenderer.material = pathMaterial;
        }
    }

    GameObject returnPrefabForName(string name)
    {
        return mapPartsPrefabsList.Find(prefab => prefab.name == name);
    }
}
