using UnityEngine;

public abstract class BonusBase : MonoBehaviour
{
    public virtual void SetBonus()
    {
        var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
        playerData.CoinAmount += 10;
        SaveLoadManager.SavePDP(playerData, SavedFileNameHolder.PlayerData);
        Debug.Log(playerData.CoinAmount);
    }
}
