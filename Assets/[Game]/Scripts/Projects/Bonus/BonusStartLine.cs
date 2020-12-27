using UnityEngine;

public class BonusStartLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Character>().CharacterControllerType;

        if (player == CharacterControllerType.Player)
        {
            LevelManager.Instance.FinishLevel();
        }
    }
}
