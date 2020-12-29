using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class HandAnimation : MonoBehaviour
{
    #region Variables
    RectTransform imageTransform;
    Tween handTween;
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        imageTransform = GetComponent<RectTransform>();
        EventManager.OnGameStart.AddListener(AnimationHand);
        EventManager.OnLevelStart.AddListener(() => { handTween.Kill(); });
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(AnimationHand);
        EventManager.OnLevelStart.RemoveListener(() => { handTween.Kill(); });
    }

    void AnimationHand()
    {
        handTween = imageTransform.DOAnchorPosX(365f, 1.5f, false)
            .From(new Vector2(-365f, imageTransform.anchoredPosition.y))
            .SetLoops(-1, LoopType.Yoyo)
            .OnComplete(() =>
            {
                AnimationHand();
            });
    }
    #endregion
}