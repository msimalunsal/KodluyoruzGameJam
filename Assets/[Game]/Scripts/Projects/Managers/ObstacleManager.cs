using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : Singleton<ObstacleManager>
{
    #region Private Variables
    private float lastObstacleCreateTime;
    private float obstacleCreateWaitTime;
    #endregion

    #region Public Variables
    public bool canCreateObstacles;
    #endregion

    #region Private Methods
    private void Start()
    {
        obstacleCreateWaitTime = Random.Range(3f, 6f);
    }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.AddListener(() => canCreateObstacles = true);


    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnLevelStart.RemoveListener(() => canCreateObstacles = true);
    }

    private void Update()
    {
        if (!canCreateObstacles)
        {
            lastObstacleCreateTime = Time.time;     
                                                    
            return;
        }

        SpawnObstacles();

    }

    private void SpawnObstacles()
    {
        if (Time.time < lastObstacleCreateTime + obstacleCreateWaitTime)
            return;

        float chance = Random.Range(0f, 100f);

        if (chance < 60f)
        {
            lastObstacleCreateTime = Time.time; 
            EventManager.OnObstacleCreated.Invoke(); 
            return; 
        }

        List<GameObject> laneObjects = new List<GameObject>(LevelManager.Instance.level.Lane);

        //laneObjects.Shuffle();
        //Now we remove one lane object from the list to make sure our player has one lane without an obstacle.
        laneObjects.RemoveAt(Random.Range(0, laneObjects.Count));

        //We loop the list that contains two random lanes (different order each time because we suffle it.)
        float chanceForAnotherObstacle = Random.Range(0f, 1f);//This is our chance for second obstacle if we pass this float we will create a second obstacle.
                                                              //If not we will only create one obstacle 100 percent

        lastObstacleCreateTime = Time.time; //We set the last obstacle create time to Time.time to wait for next interval.

        for (int i = 0; i < laneObjects.Count; i++)
        {
            if (chanceForAnotherObstacle > 0.5f)
            {
                
                CreateObstacle(laneObjects[i].transform.position);
                chanceForAnotherObstacle = 0f;
                continue; //This statment will allow us the pass the code below in the for loop.
                          //We don't want to create two obstacles on the same lane however we also don't know if we passed the
                          //if statement.
            }

            CreateObstacle(laneObjects[i].transform.position);
            break; //This statment will allow us the quit from for loop. 
        }

        EventManager.OnObstacleCreated.Invoke();
    }
    #endregion

    #region Public Methods
    public GameObject CreateObstacle(Vector3 position )
    {
        Debug.Log("Create obstacle");
        Debug.Log(position);
        return Instantiate(LevelManager.Instance.level.GetRandomLevelObject(),
            new Vector3(position.x, position.y, position.z + 15f),
            Quaternion.identity,
            GroundManager.Instance.Grounds[GroundManager.Instance.Grounds.Count - 1].transform);
    }
    #endregion
}
