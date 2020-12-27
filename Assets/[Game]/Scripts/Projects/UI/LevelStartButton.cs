using UnityEngine.UI;

public class LevelStartButton : Button
{
    #region Protected Methods
    protected override void OnEnable()
    {
        base.OnEnable();
        onClick.AddListener(StartLevel);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        onClick.RemoveListener(StartLevel);
    }
    #endregion

    #region Private Methods
    void StartLevel()
    {
        LevelManager.Instance.StartLevel();
        EventManager.OnPlayerStartedRunning.Invoke();
    }
    #endregion
}
