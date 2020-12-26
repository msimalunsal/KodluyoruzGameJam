using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
