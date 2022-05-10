using UnityEngine;
using TMPro;
using GooglePlayGames;

public class GameOverScores : MonoBehaviour
{
    float highScore;
    [HideInInspector] public float score;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI highScoreTxt;
    [SerializeField] string id;

    private void Start()
    {
        AddScore();
        DisplayTexts();
    }

    private void AddScore()
    {
        score = FindObjectOfType<ScoreHolder>().score;
        highScore = SaveScore.LoadScore().highScore;

        if (score > highScore) highScore = score;

        SaveScore.SaveScores(score, highScore);
        PlayGamesPlatform.Instance.ReportScore((int)(highScore * 100), id, (bool ok) => { });
    }

    private void DisplayTexts()
    {
        scoreTxt.text = "Score  " + score.ToString("f2");
        highScoreTxt.text = "High Score  " + highScore.ToString("f2");
    }
}
