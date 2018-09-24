using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode: MonoBehaviour{

    public bool visited;
    public bool rendered;
    public bool path;
    public MeshRenderer meshRenderer;
    public Vector3 nodePosition;
    public string typeOfNode;

    private void OnEnable()
    {
        visited = false;
        rendered = false;
        nodePosition = this.gameObject.transform.position;
        typeOfNode = Keys.NodeTypes.MAP;
        meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
    }

}
