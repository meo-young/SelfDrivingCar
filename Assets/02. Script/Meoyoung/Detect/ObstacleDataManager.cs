using System.Collections.Generic;
using UnityEngine;

public class ObstacleDataManager : MonoBehaviour
{
    [Header("# Obstacle Tag Info")]
    [SerializeField] List<string> obstacleTagList;

    public List<string> GetObstacleTagList()
    {
        return obstacleTagList;
    }
}
