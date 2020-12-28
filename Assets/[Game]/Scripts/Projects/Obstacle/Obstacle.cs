
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    #region OnTrigger
    private void OnTriggerEnter(Collider collision)
    {
        IDamageable IDamageable = collision.GetComponent<IDamageable>();
        if (IDamageable != null)
        {
            IDamageable.Damage();
            DamageParticulController.Instance.PlayEffect();
        }
    }
    #endregion
}
