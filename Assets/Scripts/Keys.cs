using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {

	public class NodeTypes
    {
        public static string MAP = "MapSingleSquare";
        public static string START = "StartPoint";
        public static string FINISH = "FinishPoint";

        public static string OBSTACLE = "Obstacle";
        public static string OBSTACLE_1_1 = "Obstacle1x1";
        public static string OBSTACLE_2_1 = "Obstacle2x1";
        public static string OBSTACLE_1_2 = "Obstacle1x2";
        public static string OBSTACLE_2_2 = "Obstacle2x2";
        public static List<string> OBSTACLE_TYPE_LIST = new List<string>() { "Obstacle1x1", "Obstacle2x1", "Obstacle1x2", "Obstacle2x2" };
    }

    public class Algorithms
    {
        public static string DIJKSTRA = "Dijkstra";
        public static string A_STAR = "A*";
    }
}
