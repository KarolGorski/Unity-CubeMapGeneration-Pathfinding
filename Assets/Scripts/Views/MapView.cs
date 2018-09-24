using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : BaseView{

    [SerializeField]
    GenerationController generationController;

    public override void ShowView()
    {
        Debug.Log("SHOW VIEW - MAP1!");
        base.ShowView();
        Debug.Log("SHOW VIEW - MAP2!");
        generationController.Generate();
    }

    public override void HideView()
    {
        base.HideView();
    }
}
