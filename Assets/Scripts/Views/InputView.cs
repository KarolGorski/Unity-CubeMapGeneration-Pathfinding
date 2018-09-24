using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class InputView : BaseView {

    [SerializeField]
    Text mapSizeInput;
    [SerializeField]
    Text obstacleQuantityInput;

    [SerializeField]
    MapInfo currentMapInfo;

    void OnEnable()
    {
        Assert.IsNotNull(mapSizeInput, "map Size input textbox IS MISSING in GUIController");
        Assert.IsNotNull(obstacleQuantityInput, "obstacle quantity input textbox IS MISSING in GUIController");
    }

    public override void ShowView()
    {
        base.ShowView();
    }
    public override void HideView()
    {
        Debug.Log("HIDE VIEW -INPUT!");
        WriteInputToMap();
        Debug.Log("HIDE VIEW -INPUT2!");
        base.HideView();
        Debug.Log("HIDE VIEW -INPUT3!");
    }

    void WriteInputToMap()
    {
        Debug.Log(mapSizeInput.text + "  "+obstacleQuantityInput.text);
        if (!int.TryParse(mapSizeInput.text, out currentMapInfo.mapSize))
            Debug.LogError("NOT IMPLEMENTED FAILING INT IN GUI CONTROLLER  1!");
        if (!int.TryParse(obstacleQuantityInput.text, out currentMapInfo.obstacleQuantity))
            Debug.LogError("NOT IMPLEMENTED FAILING INT IN GUI CONTROLLER  2!");
    }
}
