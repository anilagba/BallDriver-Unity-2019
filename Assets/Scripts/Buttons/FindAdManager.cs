using UnityEngine;
using UnityEngine.UI;

public class FindAdManager : MonoBehaviour
{
    [SerializeField] Button button;

    private void Update()
    {
        if (FindObjectOfType<RewardedAdScript>().isLoaded) button.gameObject.SetActive(true);
        else if (!FindObjectOfType<RewardedAdScript>().isLoaded) button.gameObject.SetActive(false);
    }


    public void WatchAd()
    {
        FindObjectOfType<RewardedAdScript>().WatchAd();
    }
}
