using TMPro;
using UnityEngine;

public class TotalNumberCalculator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinTxt;
    [SerializeField] TextMeshProUGUI coinTxtShopPanel;

    private void Awake()
    {
        Collectables.coins = SaveCoins.LoadCoins();
    }

    private void Update()
    {
        coinTxt.text = Collectables.coins.ToString();

        if (coinTxtShopPanel != null) coinTxtShopPanel.text = Collectables.coins.ToString();
    }

    public void UpgradeNumber()
    {
        SaveCoins.SaveCoin(1);
    }
}
