using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class RewardedAdScript : MonoBehaviour
{
    private static RewardedAd rewardedAd;
    [SerializeField] string adUnitId;
    public bool isLoaded;

    void Update()
    {
        if (rewardedAd.IsLoaded()) isLoaded = true;
        else if (!rewardedAd.IsLoaded()) isLoaded = false;
    }

    void Start()
    {
        if (FindObjectsOfType<RewardedAdScript>().Length > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);

        rewardedAd = CreateAndLoadRewardedAd();
    }

    #region WatchAd
    public void WatchAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }
    #endregion

    #region CreateAndLoadRewardedAd
    public RewardedAd CreateAndLoadRewardedAd()
    {
#if UNITY_ANDROID
        string adUnitId = this.adUnitId;
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            string adUnitId = "unexpected_platform";
#endif

        RewardedAd rewardedAd = new RewardedAd(adUnitId);

        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
        return rewardedAd;
    }
    #endregion

    #region HandleUserEarnedReward
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        SaveCoins.SaveCoin((int)amount);
    }
    #endregion

    #region HandleRewardedAdLoaded
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        CreateAndLoadRewardedAd();
    }
    #endregion

    #region HandleRewardedAdClosed
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        rewardedAd = CreateAndLoadRewardedAd();
    }
    #endregion

    #region HandleRewardedAdOpening
    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {

    }
    #endregion
}
