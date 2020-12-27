using UnityEngine;

public class GroundObject : MonoBehaviour
{
    #region Public Variables
    public Transform startPoint;
    public Transform endPoint;
    #endregion

    #region Private Methods
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
    #endregion
}
