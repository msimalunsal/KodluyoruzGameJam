using UnityEngine;

public abstract class ObstacleBase : MonoBehaviour
{
    public virtual void OnEnable() 
    {
        ObstacleManager.Instance.AddObstacle(this);
    }
    public virtual void OnDisable() { }
}
