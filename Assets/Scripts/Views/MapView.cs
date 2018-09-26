using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MapView : BaseView{

    [SerializeField]
    GenerationController generationController;

    public override void ShowView()
    {
        base.ShowView();
    }

    private void OnEnable()
    {
        Assert.IsNotNull(generationController, "There is no Generation Controller in MapView");
        generationController.Generate();
    }

    public override void HideView()
    {
        base.HideView();
    }
}
