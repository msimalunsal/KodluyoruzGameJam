using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObject : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        GroundManager.Instance.AddGround(this);
    }

    private void OnDisable()
    { 
       if (Managers.Instance == null)
            return;
        GroundManager.Instance.RemoveGround(this);
    }
}
