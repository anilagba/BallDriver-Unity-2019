using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class Login : MonoBehaviour
{
    public static PlayGamesPlatform platform;

    void Start()
    {
        PlayGamesPlatform.Instance.localUser.Authenticate((bool success) =>
        {

        });

        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            platform = PlayGamesPlatform.Activate();
        }
    }
}
