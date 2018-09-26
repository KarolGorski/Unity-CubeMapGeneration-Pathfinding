using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {

	public class NodeTypes
    {
        public static string MAP = "Map";
        public static string START = "StartPoint";
        public static string FINISH = "FinishPoint";
        public static string OBSTACLE = "Obstacle";
    }

    public class Materials
    {
        public static string PATH = "Path";
        public static string VISITED = "Visited";
        public static string FRONTIER = "Frontier";
    }


    public class Algorithms
    {
        public static string DIJKSTRA = "Dijkstra";
        public static string A_STAR = "A* algorithm";
        public static string BFS = "Breadth First Search";
    }

    public class Data
    {
        public static string SAVES_LIST = "Serialized list of every save";
    }
}
