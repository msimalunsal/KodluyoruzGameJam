using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : Singleton<ObstacleManager>
{
    List<ObstacleBase> obstacles = new List<ObstacleBase>();

    public void AddObstacle(ObstacleBase obstacle)
    {
        if (!obstacles.Contains(obstacle))
        {
            obstacles.Add(obstacle);
        }
    }

    public void RemoveObstacle(ObstacleBase obstacle)
    {

    }
}
