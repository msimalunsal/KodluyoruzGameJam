using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level", order = 1)]
public class Level : ScriptableObject
{
    #region Public Lists
    public List<GameObject> Grounds = new List<GameObject>();
    public List<GameObject> Obstacle = new List<GameObject>();
    public List<GameObject> Lane = new List<GameObject>();
    #endregion

    #region Public Random Methods
    public GameObject GetRandomLevelObject()
    {
        try
        {
            int rand = Random.Range(0, 6);
            return Obstacle[rand];
        }
        catch (System.Exception ex)
        {
            return null;
        }

    }

    public GameObject GetRandomTrack()
    {
        try
        {
            int rand = Random.Range(0, 3);
            return Grounds[rand].gameObject;
        }
        catch (System.Exception ex)
        {
            return null;
        }
    }
    #endregion
}

