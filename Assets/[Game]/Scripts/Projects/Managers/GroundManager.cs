using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : Singleton<GroundManager>
{
    List<GroundObject> grounds;

    public int groundCount = 3;
    public float groundSpeed = 5f;
    public List<GroundObject> Grounds { get { return (grounds == null) ? grounds = new List<GroundObject>() : grounds; } set { grounds = value; } }

    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(Initilize);
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(Initilize);
    }


    private void Initilize()
    {
        for (int i = 0; i < groundCount; i++)
        {
            CreateGround();
        }
    }

    private void CreateGround()
    {
        Vector3 createPos = Vector3.zero;

        if (Grounds != null)
        {
            if (Grounds.Count > 0)
            {
                createPos = Grounds[Grounds.Count - 1].endPoint.position + Vector3.forward * 4f;
            }
        }
        ////GameObject trackObj = Instantiate(LevelManager.Instance.CurrentLevel.GetRandomTrack(LevelManager.Instance.CurrentTheme), createPos, Quaternion.identity);
        GameObject groundObj = Instantiate(Grounds[0].gameObject, createPos, Quaternion.identity);
    }

    public void DisposeGround (GroundObject groundObject) 
    {
        RemoveGround(groundObject);
        Destroy(groundObject);
    }

    private void Update()
    {
        MoveGroundObjects();
        ManageGroundObjects();
    }

    #region Add&RemoveGround

    public void AddGround(GroundObject groundObject)
    {
        if (!Grounds.Contains(groundObject))
        {
            Grounds.Add(groundObject);
        }
    }
    public void RemoveGround(GroundObject groundObject)
    {
        if (Grounds.Contains(groundObject))
        {
            Grounds.Remove(groundObject);
        }
    }
    #endregion

    void MoveGroundObjects()
    {
        for (int i = 0; i < Grounds.Count; i++)
        {
            Grounds[i].transform.position += Vector3.back * groundSpeed * Time.deltaTime;
        }
    }
    void ManageGroundObjects()
    {
        for (int i = 0; i < Grounds.Count; i++)
        {
            if(Grounds[i].transform.position.z < -30)
            {
                DisposeGround(Grounds[i]);
                CreateGround();
            }
        }
    }
}

