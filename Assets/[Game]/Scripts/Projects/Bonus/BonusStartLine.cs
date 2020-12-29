using UnityEngine;
using DG.Tweening;

public class BonusStartLine : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Character>().CharacterControllerType;

        if (player == CharacterControllerType.Player)
        {
            BonusManager.Instance.IncreaseBonusGroundSpeed(other.transform.localScale.x);
        }
    }
}
