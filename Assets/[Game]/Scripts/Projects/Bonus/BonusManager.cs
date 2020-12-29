using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : Singleton<BonusManager>
{
    public void IncreaseBonusGroundSpeed(float speedMultiplier)
    {
        GroundManager.Instance.groundSpeed *= speedMultiplier;
    }
}
