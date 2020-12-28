using UnityEngine;
using DG.Tweening;

public class CharacterController : MonoBehaviour, ICharacterController, IScaleable
{
    #region Variables
    Tween scaleTween;
    Vector3 startLocalScale = new Vector3();
    #endregion

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

        startLocalScale = transform.localScale;

        EventManager.OnLevelStart.AddListener(() => { Character.IsControlable = true; });
        EventManager.OnLevelStart.AddListener(Scale);
        EventManager.OnSwipeDetected.AddListener(Move);
        Character.OnCharacterHit.AddListener(() =>
        {
            scaleTween.Kill();
            isScaleable = false;
            transform.localScale = startLocalScale;
            Scale();
        });

        EventManager.OnCollectBonus.AddListener(ReduceScale);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.AddListener(() => { Character.IsControlable = true; });
        EventManager.OnLevelStart.RemoveListener(Scale);
        EventManager.OnSwipeDetected.RemoveListener(Move);
        Character.OnCharacterHit.RemoveListener(() =>
        {
            scaleTween.Kill();
            isScaleable = false;
            transform.localScale = new Vector3(1, 1, 1);
            Scale();
        });

        EventManager.OnCollectBonus.RemoveListener(ReduceScale);
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


    bool isScaleable;
    public void Scale()
    {
        if (isScaleable)
            return;

        scaleTween = transform.DOScale(transform.localScale + new Vector3(.2f, .2f, .2f), 3f).SetEase(Ease.Linear).OnComplete(() => {
            if (transform.localScale.x >= 2.5f)
                isScaleable = true;
            Scale();
        });
    }

    public void ReduceScale()
    {
        scaleTween.Kill();
        isScaleable = false;

        scaleTween = transform.DOScale(new Vector3(0, 0, 0), 2.3f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                LevelManager.Instance.FinishLevel();
            });
    }
    #endregion
}
