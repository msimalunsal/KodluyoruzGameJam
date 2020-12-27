using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class GameManager : MonoBehaviour
=======
public class GameManager : Singleton<GameManager>
>>>>>>> e0a193a27833b18600e1eb1d05d70bf8ab62b9ab
{
    public bool isGameStarted;
    public bool IsGameStarted { get { return isGameStarted; } private set { isGameStarted = value; } }

<<<<<<< HEAD
    private void Start()
    {
        StartGame();
    }

=======
>>>>>>> e0a193a27833b18600e1eb1d05d70bf8ab62b9ab
    public void StartGame()
    {
        if (IsGameStarted)
            return;

        IsGameStarted = true;
        EventManager.OnGameStart.Invoke();
<<<<<<< HEAD
=======

>>>>>>> e0a193a27833b18600e1eb1d05d70bf8ab62b9ab
    }

    public void EndGame()
    {
        if (!IsGameStarted)
            return;

        IsGameStarted = false;
        EventManager.OnGameOver.Invoke();
    }
}
