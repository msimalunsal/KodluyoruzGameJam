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
<<<<<<< HEAD
    public List<GameObject> Lane= new List<GameObject>();
=======
    public List<GameObject> Lane = new List<GameObject>();
>>>>>>> e0a193a27833b18600e1eb1d05d70bf8ab62b9ab
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
<<<<<<< HEAD

=======
>>>>>>> e0a193a27833b18600e1eb1d05d70bf8ab62b9ab
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

