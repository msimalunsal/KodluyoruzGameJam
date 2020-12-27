using UnityEngine;
using DG.Tweening;

public class BonusStartLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Character>().CharacterControllerType;

        if (player == CharacterControllerType.Player)
        {
            other.GetComponent<Character>().IsControlable = false;
            //other.transform.DOMoveX(GroundManager.Instance.MiddleLane.transform.position.x, 1f, false);
        }
    }
}
