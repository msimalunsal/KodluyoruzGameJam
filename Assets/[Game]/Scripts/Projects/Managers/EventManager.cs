<<<<<<< HEAD
﻿using UnityEngine.Events;

public static class EventManager 
{
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();
    public static UnityEvent OnPlayerStartedRunning=new UnityEvent();
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnObstacleCreated = new UnityEvent();

}
=======
﻿using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    #region Game State Events
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();
    #endregion

    #region Player Events
    public static UnityEvent OnPlayerStartedRunning=new UnityEvent();
    #endregion

    #region Level Events
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();
    #endregion

    #region Obstacle State Events
    public static UnityEvent OnObstacleCreated = new UnityEvent();
    #endregion

    #region Input Events
    public static UnityEvent OnTapDetected = new UnityEvent();
    public static SwipeEvent OnSwipeDetected = new SwipeEvent();
    public static UnityEvent OnSwipeFail = new UnityEvent();
    #endregion
}
public class SwipeEvent : UnityEvent<Swipe, Vector2> { }
>>>>>>> e0a193a27833b18600e1eb1d05d70bf8ab62b9ab
