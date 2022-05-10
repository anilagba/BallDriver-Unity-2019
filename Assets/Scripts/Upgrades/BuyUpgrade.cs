using UnityEngine;
using TMPro;
using System.Collections;

public class BuyUpgrade : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI upgradeTxt;
    [SerializeField] TextMeshProUGUI totalCoinsTxt;
    [SerializeField] TextMeshProUGUI neededCoinsTxt;
    [SerializeField] TextMeshProUGUI warningTxt;
    [SerializeField] int neededCoins;

    private void Awake()
    {
        warningTxt.enabled = false;
        neededCoinsTxt.text = neededCoins.ToString();
    }

    private void Update()
    {
        DisplayNumbers();
    }

    #region DisplayNumbers
    private void DisplayNumbers()
    {
        if (gameObject.name == "slowdown") upgradeTxt.text = SaveUpgrades.LoadSlowDown().ToString();
        else if (gameObject.name == "sizedec") upgradeTxt.text = SaveUpgrades.LoadSizeDecrease().ToString();
        else if (gameObject.name == "bouncydec") upgradeTxt.text = SaveUpgrades.LoadBouncinessDecrease().ToString();
        else if (gameObject.name == "boxbreaker") upgradeTxt.text = SaveUpgrades.LoadBoxBreaker().ToString();
        else return;
    }
    #endregion

    #region BuySlowDown
    public void BuySlowDown()
    {
        if (SaveCoins.LoadCoins() >= neededCoins)
        {
            SaveCoins.SaveCoin(-neededCoins);
            SaveUpgrades.SaveSlowDown(1);
            upgradeTxt.text = SaveUpgrades.LoadSlowDown().ToString();
            totalCoinsTxt.text = SaveCoins.LoadCoins().ToString();
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(RemoveWarningTxt());
        }
    }
    #endregion

    #region BuySizeDecrease
    public void BuySizeDecrease()
    {
        if (SaveCoins.LoadCoins() >= neededCoins)
        {
            SaveCoins.SaveCoin(-neededCoins);
            SaveUpgrades.SaveSizeDecrease(1);
            upgradeTxt.text = SaveUpgrades.LoadSizeDecrease().ToString();
            totalCoinsTxt.text = SaveCoins.LoadCoins().ToString();
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(RemoveWarningTxt());
        }
    }
    #endregion

    #region BuyBouncinessDecrease
    public void BuyBouncinessDecrease()
    {
        if (SaveCoins.LoadCoins() >= neededCoins)
        {
            SaveCoins.SaveCoin(-neededCoins);
            SaveUpgrades.SaveBouncinessDecrease(1);
            upgradeTxt.text = SaveUpgrades.LoadBouncinessDecrease().ToString();
            totalCoinsTxt.text = SaveCoins.LoadCoins().ToString();
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(RemoveWarningTxt());
        }
    }
    #endregion

    #region BuyBoxBreaker
    public void BuyBoxBreaker()
    {
        if (SaveCoins.LoadCoins() >= neededCoins)
        {
            SaveCoins.SaveCoin(-neededCoins);
            SaveUpgrades.SaveBoxBreaker(1);
            upgradeTxt.text = SaveUpgrades.LoadBoxBreaker().ToString();
            totalCoinsTxt.text = SaveCoins.LoadCoins().ToString();
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(RemoveWarningTxt());
        }
    }
    #endregion

    #region RemoveWarningTxt
    private IEnumerator RemoveWarningTxt()
    {
        warningTxt.enabled = true;
        warningTxt.text = "Not enough coins";
        yield return new WaitForSecondsRealtime(2);
        warningTxt.enabled = false;
    }
    #endregion
}
