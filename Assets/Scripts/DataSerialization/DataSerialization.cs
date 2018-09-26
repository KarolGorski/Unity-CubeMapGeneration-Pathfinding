using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSerialization : MonoBehaviour {

    [SerializeField]
    MapInfo mapInfo;
    [SerializeField]
    Text saveText;
    [SerializeField]
    RenderController renderController;

    private List<string> saves;

    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey(Keys.Data.SAVES_LIST))
            saves = new List<string>();
        else
            saves = JsonUtility.FromJson<List<string>>(PlayerPrefs.GetString(Keys.Data.SAVES_LIST));
    }

    public List<string> GetListOfSaves()
    {
        return saves;
    }

    public void SaveData()
    {
        if(saveText.text.Length!=0)
        {
            MapInfoData temp = new MapInfoData(mapInfo);
            PlayerPrefs.SetString(saveText.text, JsonUtility.ToJson(temp));
            saves.Add(saveText.text);
            PlayerPrefs.SetString(Keys.Data.SAVES_LIST, JsonUtility.ToJson(saves));
        }
        Debug.Log("Data Saved");
    }
    public void LoadData(Text loadText)
    {
        if(PlayerPrefs.HasKey(loadText.text))
        {
            MapInfoData temp = JsonUtility.FromJson<MapInfoData>(PlayerPrefs.GetString(loadText.text));
            temp.UnpackToMapInfo(mapInfo);
            renderController.RenderMap();
        }
        Debug.Log("Data Loaded");
    }

    private class MapInfoData
    {
        private int mapSize;
        private int obstacleQuantity;
        private Dictionary<Vector2, MapNode> generatedMapDictionary;
        private MapNode startNode, finishNode;

        public MapInfoData(MapInfo mapInfo)
        { 
            mapSize = mapInfo.mapSize;
            obstacleQuantity = mapInfo.obstacleQuantity;
            generatedMapDictionary = mapInfo.generatedMapDictionary;
            startNode = mapInfo.startNode;
            finishNode = mapInfo.finishNode;
        }

        public void UnpackToMapInfo(MapInfo mapInfo)
        {
            mapInfo.mapSize = mapSize;
            mapInfo.obstacleQuantity = obstacleQuantity;
            mapInfo.generatedMapDictionary = generatedMapDictionary;
            mapInfo.startNode = startNode;
            mapInfo.finishNode = startNode;
        }
    }

    public void DeleteAllSaves()
    {
        foreach(string s in saves)
        {
            PlayerPrefs.DeleteKey(s);
            saves.Clear();
        }
    }
}
