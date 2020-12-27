using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [SerializeField]
    private int coinAmount;
    public int CoinAmount { get { return coinAmount; } set { coinAmount = value; EventManager.OnPlayerDataUpdated.Invoke(this); } }

}
