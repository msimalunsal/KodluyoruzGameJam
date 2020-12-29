using UnityEngine;
using UnityEngine.UI;

public class PlayButton : Button
{
    #region Protected Methods
    protected override void OnEnable()
    {
        base.OnEnable();
        onClick.AddListener(StartGame);
    }

    protected override void OnDisable()
    {
        base.OnEnable();
        onClick.RemoveListener(StartGame);
    }
    #endregion

    #region Private Methods
    void StartGame()
    {
        GameManager.Instance.StartGame();
    }
    #endregion
}
