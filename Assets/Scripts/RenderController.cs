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

    private Dictionary<Vector2, RenderedNode> renderedMap;

    public void RenderMap()
    {
        renderedMap = new Dictionary<Vector2, RenderedNode>();

        foreach(KeyValuePair<Vector2, MapNode> mapNode in mapInfo.generatedMapDictionary)
        {
            GameObject prefab = returnPrefabForName(mapNode.Value.GetNodeType());
            GameObject temp = GameObject.Instantiate(prefab, mapNode.Key, prefab.transform.rotation, dynamicParent.transform);
            RenderedNode tempNode = temp.AddComponent<RenderedNode>();
            tempNode.ChangeType(mapNode.Value.GetNodeType());
            renderedMap.Add(temp.transform.position, tempNode);
        }

        Camera.main.transform.position = new Vector3(mapInfo.mapSize, mapInfo.mapSize / 2, -mapInfo.mapSize -2f);
    }

    //public void RenderPath()
    //{
    //    foreach (KeyValuePair<Vector2,MapNode> rNode in mapInfo.generatedMapDictionary)
    //    {
    //        if (node.Value.visited)
    //            node.Value.meshRenderer.material = visitedMaterial;
    //        if (node.Value.path)
    //            node.Value.meshRenderer.material = pathMaterial;
    //    }
    //}

    GameObject returnPrefabForName(string name)
    {
        return mapPartsPrefabsList.Find(prefab => prefab.name == name);
    }
}
