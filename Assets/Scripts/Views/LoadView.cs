using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadView : BaseView {

    [SerializeField]
    DataSerialization dataSerialization;
    [SerializeField]
    GameObject uiParentOfLoadButtons;
    [SerializeField]
    GameObject loadButtonPrefab;

    private List<GameObject> listOfButtons;

    public override void ShowView()
    {
        base.ShowView();
    }

    public override void HideView()
    {
        base.HideView();
    }

    private void OnEnable()
    {
        if(listOfButtons==null)
            listOfButtons = new List<GameObject>();
        foreach (string loadText in dataSerialization.GetListOfSaves())
        {
            GameObject newButton = GameObject.Instantiate(loadButtonPrefab,uiParentOfLoadButtons.transform);
            listOfButtons.Add(newButton);
            LoadButton temp = newButton.GetComponent<LoadButton>();
            temp.loadButtonText.text = loadText;
            temp.buttonComponent.onClick.AddListener(delegate { dataSerialization.LoadData(temp.loadButtonText); });
            temp.buttonComponent.onClick.AddListener(delegate { this.HideView(); });
        }
        
    }

    public void DeleteAll()
    {
        foreach(GameObject b in listOfButtons)
        {
            Destroy(b);
        }
        listOfButtons.Clear();
        dataSerialization.DeleteAllSaves();
    }
}
