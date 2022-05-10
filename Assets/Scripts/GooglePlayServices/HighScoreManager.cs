using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hghscrTxt;
    [SerializeField] private string id;

    private void Update()
    {
        if (SaveScore.LoadScore().highScore > 0) LoadHghScr();
        else LoadLeaderBoard(id);
    }

    #region OpenBoard
    public void OpenBoard()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(id);
    }
    #endregion

    #region LoadLeaderBoard
    public void LoadLeaderBoard(string id)
    {
        ILeaderboard lb = PlayGamesPlatform.Instance.CreateLeaderboard();
        lb.id = id;
        lb.LoadScores(success =>
        {
            if (success)
            {
                SaveScore.SaveScores(0, ((float)lb.localUserScore.value / 100));
                LoadHghScr();
                ////hghscrTxt.text = (lb.scores.Length).ToString();  //displays total added score number
                //hghscrTxt.text = (lb.scores.Rank).ToString(); //displays the current player's rank in leader board
            }
            else
            {
                LoadHghScr();
            }
        });
    }
    #endregion

    #region LoadHghScr
    private void LoadHghScr()
    {
        hghscrTxt.text = "High Score " + SaveScore.LoadScore().highScore.ToString("f2");
    }
    #endregion
}
