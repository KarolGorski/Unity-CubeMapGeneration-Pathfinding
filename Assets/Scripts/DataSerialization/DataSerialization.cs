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
        {
            saves = JsonUtility.FromJson<List<string>>(PlayerPrefs.GetString(Keys.Data.SAVES_LIST));
        }
            
    }

    public List<string> GetListOfSaves()
    {
        Debug.Log("Returnig list of saves from p.prefs Count:" + saves.Count);
        return JsonUtility.FromJson<List<string>>(PlayerPrefs.GetString(Keys.Data.SAVES_LIST));
    }

    public void SaveData()
    {
        if(saveText.text.Length!=0)
        {
            MapInfoData temp = new MapInfoData(mapInfo);
            Debug.Log(temp.ToString());
            PlayerPrefs.SetString(saveText.text, JsonUtility.ToJson(temp));
            saves.Add(saveText.text);
            Debug.Log(saves.Count);
            PlayerPrefs.SetString(Keys.Data.SAVES_LIST, JsonUtility.ToJson(saves));
        }
        Debug.Log("Data Saved");
    }
    public void LoadData(Text loadText)
    {
        Debug.Log("Data Loading");
        if (PlayerPrefs.HasKey(loadText.text))
        {
            MapInfoData temp = JsonUtility.FromJson<MapInfoData>(PlayerPrefs.GetString(loadText.text));
            Debug.Log(temp.ToString());
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

        public override string ToString()
        {
            string temp = "";
            if(generatedMapDictionary!=null)
                foreach(var key in generatedMapDictionary)
                {
                    temp += key.ToString()+", ";
                }
            return "MapSize: " + mapSize.ToString() + " ObstacleQuantity: " + obstacleQuantity.ToString() + "Map: " + temp;
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
