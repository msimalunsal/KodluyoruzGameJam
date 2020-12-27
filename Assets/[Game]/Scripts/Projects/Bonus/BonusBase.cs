using UnityEngine;

public abstract class BonusBase : MonoBehaviour
{
    public int bonus;

    public virtual int GetBonus()
    {
        return bonus;
    }
}
