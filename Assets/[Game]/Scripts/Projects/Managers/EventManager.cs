using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    #region Game State Events
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();
    #endregion

    #region Player Events
    public static UnityEvent OnPlayerStartedRunning=new UnityEvent();
    public static PlayerDataEvent OnPlayerDataUpdated = new PlayerDataEvent();
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

    #region Bonus Events
    public static UnityEvent OnCollectBonus = new UnityEvent();
    #endregion
}
public class SwipeEvent : UnityEvent<Swipe, Vector2> { }
public class PlayerDataEvent : UnityEvent<PlayerData> { }