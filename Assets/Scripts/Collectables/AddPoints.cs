using UnityEngine;

public class AddPoints : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Add(2);
    }

    public void Add(int multiplier)
    {
        CalculateScore calculateScore = FindObjectOfType<CalculateScore>();

        if (GetComponent<BoxCollider2D>())
        {
            calculateScore.AddPoint(25 * multiplier);
            Destroy(gameObject);
        }
        else if (GetComponent<CircleCollider2D>())
        {
            calculateScore.AddPoint(10 * multiplier);
            FindObjectOfType<TotalNumberCalculator>().UpgradeNumber();
            Destroy(gameObject);
        }
    }
}
