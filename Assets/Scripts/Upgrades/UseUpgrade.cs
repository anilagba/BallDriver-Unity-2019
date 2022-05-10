using UnityEngine;
using TMPro;
using System.Collections;

public class UseUpgrade : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LeftNumberTxt;
    [SerializeField] TextMeshProUGUI warningTxt;
    [SerializeField] PhysicsMaterial2D ballMaterial;
    float slowMultiplier;
    int usedUpgrades;
    GameObject ball;

    private void Start()
    {
        slowMultiplier = 1.15f;
        ball = GameObject.Find("Ball");
    }

    private void Update()
    {
        if (Time.timeScale != 0) return;
        else DisplayNumbers();
    }

    #region DisplayNumbers
    public void DisplayNumbers()
    {
        if (gameObject.name == "slowdown") LeftNumberTxt.text = SaveUpgrades.LoadSlowDown().ToString();
        else if (gameObject.name == "sizedec") LeftNumberTxt.text = SaveUpgrades.LoadSizeDecrease().ToString();
        else if (gameObject.name == "bouncydec") LeftNumberTxt.text = SaveUpgrades.LoadBouncinessDecrease().ToString();
        else if (gameObject.name == "boxbreaker") LeftNumberTxt.text = SaveUpgrades.LoadBoxBreaker().ToString();
        else return;
    }
    #endregion

    #region UseSlowDown
    public void UseSlowDown()
    {
        if (SaveUpgrades.LoadSlowDown() > 0 && usedUpgrades <= 2)
        {
            usedUpgrades++;
            SaveUpgrades.SaveSlowDown(-1);
            LeftNumberTxt.text = SaveUpgrades.LoadSlowDown().ToString();
            FindObjectOfType<FollowCamera>().multiplier *= slowMultiplier;
        }
        else
        {
            if (usedUpgrades == 3) ManageWarningTxt(1);
            else if (SaveUpgrades.LoadSlowDown() <= 0) ManageWarningTxt(0);
            else if (usedUpgrades == 3 && SaveUpgrades.LoadSlowDown() <= 0) ManageWarningTxt(2);
            else return;
        }
    }
    #endregion

    #region UseSizeDec
    public void UseSizeDec()
    {
        if (SaveUpgrades.LoadSizeDecrease() > 0 &&
            (ball.transform.localScale.x > 0.3f && ball.transform.localScale.y > 0.3f))
        {
            SaveUpgrades.SaveSizeDecrease(-1);
            LeftNumberTxt.text = SaveUpgrades.LoadSizeDecrease().ToString();
            ball.transform.localScale /= 1.3f;
        }
        else if (SaveUpgrades.LoadSizeDecrease() <= 0)
        {
            ManageWarningTxt(0);
        }
        else if (ball.transform.localScale.x <= 0.3f)
        {
            ManageWarningTxt(4);
        }
        else ManageWarningTxt(2);
    }
    #endregion

    #region UseBouncyDec
    public void UseBouncyDec()
    {
        if (SaveUpgrades.LoadBouncinessDecrease() > 0 && ballMaterial.bounciness > 0)
        {
            SaveUpgrades.SaveBouncinessDecrease(-1);
            LeftNumberTxt.text = SaveUpgrades.LoadBouncinessDecrease().ToString();
            ball.GetComponent<CircleCollider2D>().enabled = false;
            ballMaterial.bounciness -= 0.2f;
            ball.GetComponent<CircleCollider2D>().enabled = true;
        }
        else if (ballMaterial.bounciness <= 0)
        {
            ManageWarningTxt(3);
        }
        else
        {
            ManageWarningTxt(0);
        }
    }
    #endregion

    #region UseBoxBreaker
    public void UseBoxBreaker()
    {
        if (SaveUpgrades.LoadBoxBreaker() > 0)
        {
            SaveUpgrades.SaveBoxBreaker(-1);
            LeftNumberTxt.text = SaveUpgrades.LoadBoxBreaker().ToString();
            FindObjectOfType<BoxBreaker>().IncreaseAvoidNumb(10);
        }
        else
        {
            ManageWarningTxt(0);
        }
    }
    #endregion

    #region ManageWarningTxt
    private void ManageWarningTxt(int i)
    {
        StopAllCoroutines();
        StartCoroutine(RemoveWarningTxt(i));
    }
    #endregion

    #region RemoveWarningTxt
    private IEnumerator RemoveWarningTxt(int i)
    {
        warningTxt.text = WarningTxt(i);
        yield return new WaitForSecondsRealtime(2);
        warningTxt.text = "";
    }
    #endregion

    #region WarningTxt
    private string WarningTxt(int i)
    {
        string[] texts = new string[6];
        texts[0] = "You dont have enough upgrades.";
        texts[1] = "You have already used 3 upgrades.";
        texts[2] = "You can not use this now.";
        texts[3] = "The bounciness is at its min";
        texts[4] = "The ball is already at its min size";
        return texts[i];
    }
    #endregion
}
