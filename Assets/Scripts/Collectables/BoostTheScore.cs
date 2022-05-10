using UnityEngine;

public class BoostTheScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Boost(20);
    }

    public void Boost(int multiplier)
    {
        CalculateScore calculateScore = FindObjectOfType<CalculateScore>();
        calculateScore.MultiplyScore(multiplier);
        Destroy(gameObject);
    }
}
