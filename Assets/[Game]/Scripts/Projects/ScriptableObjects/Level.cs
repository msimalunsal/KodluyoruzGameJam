using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level", order = 1)]
public class Level : ScriptableObject
{
    [SerializeField]
    List<GameObject> Grounds = new List<GameObject>();
    [SerializeField]
    public List<GameObject> Obstacle = new List<GameObject>();
    [SerializeField]
    public List<GameObject> Lane = new List<GameObject>();
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
}

