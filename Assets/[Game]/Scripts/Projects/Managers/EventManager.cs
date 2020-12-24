using UnityEngine.Events;

public static class EventManager 
{
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();
    public static UnityEvent OnPlayerStartedRunning=new UnityEvent();

    #region Level Events
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();
    #endregion

    public static UnityEvent OnObstacleCreated = new UnityEvent();

}
