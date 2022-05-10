using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class CalculateScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreMultiplierTxt;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI multipliedAddition;
    [SerializeField] Slider timeBar;
    [SerializeField] GameObject ball;
    [HideInInspector] public float score;
    [SerializeField] float multiplierDuration;
    [SerializeField] float multiplier;
    float extras;
    float scoreMultiplier;
    float multipliedScore;
    float func2;
    float func1;
    float timer;
    Vector2 currentPos;

    private void Awake()
    {
        if (SaveScore.LoadScore() != null) return;
        else SaveScore.SaveScores(0, 0);
    }

    private void Start()
    {
        scoreMultiplier = 1;
        currentPos = Vector2.zero;
        multipliedScore = 0;
        timeBar.minValue = 0;
    }
    private void Update()
    {
        Calculate();
    }

    #region Calculate
    private void Calculate()
    {
        //calculates the point according to distance of ball's x axis
        func1 = ball.transform.position.x + 6.02f;  //6.02 is for making the start score equals to 0   

        //calculates the point when the player gets
        //a score booster untill the effect ends
        func2 = scoreMultiplier * (ball.transform.position.x - currentPos.x) - (ball.transform.position.x - currentPos.x);

        score = func1 + multipliedScore + extras;   //extras = coins and starts
        multipliedAddition.text = func2.ToString("f2");
        scoreTxt.text = "Score " + score.ToString("f2");
    }
    #endregion

    #region AddPoint
    public void AddPoint(float point)
    {
        extras += point;
    }
    #endregion

    #region MultiplyScore
    public void MultiplyScore(int durat)
    {
        multiplierDuration = durat;
        timeBar.maxValue = durat;
        multipliedAddition.gameObject.SetActive(true);
        multipliedScore += func2;
        scoreMultiplier *= multiplier;
        if (scoreMultiplier > multiplier * 2) scoreMultiplier = multiplier * 3;
        currentPos = ball.transform.position;
        scoreMultiplierTxt.text = scoreMultiplier.ToString() + "x";
        StopAllCoroutines();
        //renew the effects
        StartCoroutine(RemoveEffect());
        StartCoroutine(CountDown());
    }
    #endregion

    #region RemoveEffect
    private IEnumerator RemoveEffect()
    {
        GameObject.FindWithTag("Lantern").GetComponent<Animator>().SetBool("Shine", true);
        yield return new WaitForSeconds(multiplierDuration);
        multipliedScore += func2;
        scoreMultiplier = 1;
        scoreMultiplierTxt.text = scoreMultiplier.ToString() + "x";
        multipliedAddition.gameObject.SetActive(false);
        GameObject.Find("Lantern").GetComponent<Animator>().SetBool("Shine", false);
    }
    #endregion

    #region CountDown
    private IEnumerator CountDown()
    {
        timeBar.gameObject.SetActive(true);
        timer = 0;
        timeBar.value = multiplierDuration;
        float currentTime = Time.time;
        while (timer <= multiplierDuration)
        {
            timer = Time.time - currentTime;
            timeBar.value = multiplierDuration - timer;
            yield return new WaitForSeconds(0);
            if (timeBar.value <= 0) timeBar.gameObject.SetActive(false);
        }
    }
    #endregion
}
