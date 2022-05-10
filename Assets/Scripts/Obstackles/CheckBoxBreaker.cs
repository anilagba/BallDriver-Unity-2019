using UnityEngine;

public class CheckBoxBreaker : MonoBehaviour
{
    BoxBreaker ball;

    private void Awake()
    {
        ball = FindObjectOfType<BoxBreaker>();
    }

    void Update()
    {
        Check();
    }

    private void Check()
    {
        if (ball.avoidNumber > 0) gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        else gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
