using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : BaseView{

    [SerializeField]
    GenerationController generationController;

    public override void ShowView()
    {
        base.ShowView();
        generationController.Generate();
    }

    public override void HideView()
    {
        base.HideView();
    }
}
