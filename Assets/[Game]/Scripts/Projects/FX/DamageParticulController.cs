using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageParticulController :Singleton<DamageParticulController>
{
    ParticleSystem particle;
    private void OnEnable()
    {
        particle = GetComponent<ParticleSystem>();
    }
    public void PlayEffect()
    {
        particle.Play();
    }
}
