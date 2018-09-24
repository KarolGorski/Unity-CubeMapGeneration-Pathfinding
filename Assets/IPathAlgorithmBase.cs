using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPathAlgorithmBase{

    List<Vector2> FindShortestWay(Dictionary<Vector2, MapNode> MapNodes, MapNode startNode, MapNode finishNode);
	
}
