using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class Obstacle : ObstacleBase
{

=======
public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        IDamageable IDamageable = collision.GetComponent<IDamageable>();
        if (IDamageable != null)
        {
            IDamageable.Damage();
        }
    }
>>>>>>> e0a193a27833b18600e1eb1d05d70bf8ab62b9ab
}
