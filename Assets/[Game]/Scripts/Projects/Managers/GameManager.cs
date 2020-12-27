using UnityEngine;

[System.Serializable]
public class GameData
{
    public int PointMultiplier;
}

public class GameManager : Singleton<GameManager>
{
    #region Properties
    bool isGameStarted;
    public bool IsGameStarted { get { return isGameStarted; } private set { isGameStarted = value; } }
    #endregion

    #region Variables
    public GameData GameData = new GameData();
    #endregion

    #region Public Methods
    public void StartGame()
    {
        if (IsGameStarted)
            return;

        IsGameStarted = true;
        EventManager.OnGameStart.Invoke();

    }

    public void EndGame()
    {
        if (!IsGameStarted)
            return;

        IsGameStarted = false;
        EventManager.OnGameOver.Invoke();
    }
    #endregion
}
