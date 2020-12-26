using UnityEngine;

public class FailController : MonoBehaviour, IDamageable
{
    public void Damage()
    {
        EventManager.OnLevelFail.Invoke();
    }
}
