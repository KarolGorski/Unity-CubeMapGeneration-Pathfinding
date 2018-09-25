using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderedNode : MonoBehaviour {

    [SerializeField]
    MeshRenderer meshRenderer;
    [SerializeField]
    string TypeOfNode;

    public void ChangeType(string type)
    {
        TypeOfNode = type;
    }

    public string GetNodeType()
    {
        return TypeOfNode;
    }

    private void OnEnable()
    {
        this.meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    public void ChangeMaterial(Material mat)
    {
        meshRenderer.material = mat;
    }
}
