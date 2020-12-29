using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndPanel : Panel
{

    private void OnEnable()
    {
        HidePanel();
        if (Managers.Instance == null)
            return;
        EventManager.OnLevelFinish.AddListener(ShowPanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnLevelFinish.RemoveListener(ShowPanel);

    }
}
