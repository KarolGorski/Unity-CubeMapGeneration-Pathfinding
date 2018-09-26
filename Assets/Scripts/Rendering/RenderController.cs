using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class RenderController : MonoBehaviour {

    [SerializeField]
    MapInfo mapInfo;
    [SerializeField]
    PathfindingInfo pathfindingInfo;
    [SerializeField]
    List<GameObject> mapPartsPrefabsList;
    [SerializeField]
    List<Material> mapPartsMaterialsList;
    [SerializeField]
    GameObject dynamicParent;
    [SerializeField]
    float visitedRenderTimeOffset = 0.1f;
    [SerializeField]
    float pathRenderTimeOffset = 0.1f;

    private Dictionary<Vector2, RenderedNode> renderedMap;

    public void OnEnable()
    {

        Assert.IsNotNull(mapInfo, "There is no map info in Render Controller");
        Assert.IsNotNull(pathfindingInfo, "There is no pathfinding info in Render Controller");
        if (mapPartsPrefabsList.Count==0)
            Debug.LogError("Map parts prefab list is empty in Render Controller");
        if (mapPartsMaterialsList.Count == 0)
            Debug.LogError("Map parts prefab list is empty in Render Controller");
        Assert.IsNotNull(dynamicParent, "There is no parent for dynamics G.O. in Render Controller");
    }

    public void RenderMap()
    {
        if(renderedMap!=null)
            CleanMap();
        renderedMap = new Dictionary<Vector2, RenderedNode>();

        foreach(KeyValuePair<Vector2, MapNode> mapNode in mapInfo.generatedMapDictionary)
        {
            GameObject prefab = ReturnPrefabForName(mapNode.Value.GetNodeType());
            GameObject temp = GameObject.Instantiate(prefab, mapNode.Key, prefab.transform.rotation, dynamicParent.transform);
            RenderedNode tempNode = temp.AddComponent<RenderedNode>();
            tempNode.ChangeType(mapNode.Value.GetNodeType());
            renderedMap.Add(temp.transform.position, tempNode);
        }

        Camera.main.transform.position = new Vector3(mapInfo.mapSize, mapInfo.mapSize / 2, -mapInfo.mapSize -2f);
    }

    public void RenderPathfinding()
    {
        StartCoroutine(RenderVisitedInOrder());
    }

    IEnumerator RenderVisitedInOrder()
    {
        int iterator = 0;
        foreach (Vector2 pos in pathfindingInfo.visitedByIterations)
        {
            if (iterator < pathfindingInfo.iterations)
            { 
                RenderFrontier(iterator);
                iterator++;
            }
            renderedMap[pos].ChangeMaterial(ReturnMaterialByNodeType(Keys.Materials.VISITED));
            yield return new WaitForSeconds(visitedRenderTimeOffset);
        }
        if(pathfindingInfo.pathFound)
            StartCoroutine(RenderPathInOrder());
        yield return null;
    }

    private void RenderFrontier(int iteration)
    {
        foreach(MapNode n in pathfindingInfo.FrontierByOrder[iteration])
        {
            renderedMap[n.GetPosition()].ChangeMaterial(ReturnMaterialByNodeType(Keys.Materials.FRONTIER));
        }
    }

    IEnumerator RenderPathInOrder()
    {
        foreach (Vector2 pos in pathfindingInfo.pathPositions)
        {
            renderedMap[pos].ChangeMaterial(ReturnMaterialByNodeType(Keys.Materials.PATH));
            yield return new WaitForSeconds(pathRenderTimeOffset);
        }
        renderedMap[mapInfo.startNode.GetPosition()].ChangeMaterial(ReturnMaterialByNodeType(Keys.Materials.PATH));
        yield return null;
    }

    Material ReturnMaterialByNodeType(string type)
    {
        Material mapMat=mapPartsMaterialsList[0];
        foreach (Material m in mapPartsMaterialsList)
        {
            if (m.name.Equals(Keys.NodeTypes.MAP)) mapMat = m;
            if (m.name.Equals(type)) return m;
        }
        return mapMat;
    }

    GameObject ReturnPrefabForName(string name)
    {
        return mapPartsPrefabsList.Find(prefab => prefab.name == name);
    }

    private void CleanMap()
    {
        foreach(KeyValuePair<Vector2,RenderedNode> k in renderedMap)
        {
            Destroy(k.Value.gameObject);
        }

    }
}
