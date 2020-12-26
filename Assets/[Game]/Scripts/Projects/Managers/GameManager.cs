using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isGameStarted;
    public bool IsGameStarted { get { return isGameStarted; } private set { isGameStarted = value; } }

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
}
