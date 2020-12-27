using UnityEngine;

public class CharacterInputListener : MonoBehaviour
{
    #region Properties
    private ICharacterController characterController;
    public ICharacterController CharacterController { get { return (characterController == null) ? characterController = GetComponent<ICharacterController>() : characterController; } }
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
    }
    #endregion
}
