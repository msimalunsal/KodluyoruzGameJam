using UnityEngine;
using DG.Tweening;

public class CharacterController : MonoBehaviour, ICharacterController, IRotateable, IScaleable
{
    #region Properties
    public LaneObject CurrentLane { get { return GroundManager.Instance.GetClosestLane(transform.position); } }
    Character character;
    Character Character { get { return (character == null) ? character = GetComponent<Character>() : character; } }
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.AddListener(RotateAround);
        EventManager.OnLevelStart.AddListener(Scale);
        EventManager.OnSwipeDetected.AddListener(Move);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.RemoveListener(RotateAround);
        EventManager.OnLevelStart.RemoveListener(Scale);
        EventManager.OnSwipeDetected.RemoveListener(Move);
    }
    #endregion
  
    #region Public Methods
    public void Move(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    public void Move(Swipe swipe, Vector2 direction)
    {     
        if (!Character.IsControlable)
            return;

        LaneObject laneObject = CurrentLane.GetLane(swipe);

        switch (swipe)
        {
            case Swipe.Left:
                if (laneObject == null)
                    return;

                SwitchToLane(laneObject);
                break;

            case Swipe.Right:
                if (laneObject == null)
                    return;

                SwitchToLane(laneObject);
                break;

            default:
                break;
        }
    }
    

    bool isSwitching;
    public void SwitchToLane(LaneObject laneObject)
    {
        if (isSwitching)
            return;

        isSwitching = true;

        transform.DOMove(new Vector3(laneObject.transform.position.x, transform.position.y, transform.position.z), 1f, false)
            .OnComplete(() =>
            {
                isSwitching = false;
            });
        Character.OnCharacterSwitchLane.Invoke();
    }

    public void RotateAround()
    {
        Character.IsControlable = true;
        transform.DORotate(new Vector3(360, 0, 0), .5f, RotateMode.FastBeyond360)
         .From(new Vector3(0, 0, 0))
         .SetLoops(-1)
         .SetEase(Ease.Linear);
    }

    bool isScaleable;
    public void Scale()
    {
        if (isScaleable)
            return;

        transform.DOScale(transform.localScale + new Vector3(.2f, .2f, .2f), 5f).SetEase(Ease.Linear).OnComplete(() => {
            if (transform.localScale.x >= 2.5f)
                isScaleable = true;
            Scale();
        });
    }
    #endregion
}
