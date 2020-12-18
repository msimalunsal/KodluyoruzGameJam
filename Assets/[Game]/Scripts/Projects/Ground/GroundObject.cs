using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObject : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    private void OnEnable()
    {
        GroundManager.Instance.AddGround(this);
    }

    private void OnDisable()
    {
        GroundManager.Instance.RemoveGround(this);
    }
}
