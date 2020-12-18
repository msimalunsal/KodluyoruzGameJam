using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GroundController : MonoBehaviour
{
    Rigidbody rigidbody;
    public Rigidbody Rigidbody { get { return (rigidbody != null) ? rigidbody = GetComponent<Rigidbody>() : rigidbody; } }

    private void FixedUpdate()
    {
        GroundMovement(10f);
    }
    void GroundMovement(float speed)
    {
        //for (int i = 0; i < 1; i++)
        //{
        //    Tracks[i].transform.position += Vector3.back * LevelManager.Instance.DifficulityData.TrackSpeed * Time.deltaTime;
        //}

        gameObject.transform.position += Vector3.back * speed * Time.deltaTime;

    }
}
