using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<ScoreHolder>().score = FindObjectOfType<CalculateScore>().score;

        if (collision.name == "Ball") SceneManager.LoadScene(2);
        else return;
    }
}
