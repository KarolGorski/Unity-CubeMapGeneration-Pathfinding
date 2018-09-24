using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPathAlgorithmBase{

    bool Search(MapGraph mapGraph, MapNode startNode, MapNode finishNode);


}
