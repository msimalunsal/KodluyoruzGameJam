using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LaneHolder
{
    public LaneObject LaneObject;
    public Swipe SwipeDirection;
}

public class LaneObject : MonoBehaviour
{
    #region Public Variables
    public List<LaneHolder> ConnectedLanes = new List<LaneHolder>();
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        GroundManager.Instance.AddLane(this);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        GroundManager.Instance.RemoveLane(this);
    }
    #endregion

    #region Public Methods
    public LaneObject GetLane(Swipe swipe)
    {
        for (int i = 0; i < ConnectedLanes.Count; i++)
        {
            if (ConnectedLanes[i].SwipeDirection.Equals(swipe))
                return ConnectedLanes[i].LaneObject;
        }

        return null;
    }
    #endregion
}