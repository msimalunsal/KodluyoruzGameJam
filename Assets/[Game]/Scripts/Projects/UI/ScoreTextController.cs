using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour
{
    #region Public Variables
    public Text coinText;
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnPlayerDataUpdated.AddListener(UpdateText);
        EventManager.OnGameStart.AddListener(InitilizePanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnPlayerDataUpdated.RemoveListener(UpdateText);
        EventManager.OnGameStart.RemoveListener(InitilizePanel);
    }

    private void InitilizePanel()
    {
        var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
        UpdateText(playerData);
    }

    void UpdateText(PlayerData playerData)
    {
        coinText.text = playerData.CoinAmount.ToString();
    }
    #endregion
}
