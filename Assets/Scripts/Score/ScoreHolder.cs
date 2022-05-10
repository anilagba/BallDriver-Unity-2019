using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    public float score;
    private void Start()
    {
        if (FindObjectsOfType<ScoreHolder>().Length > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
}
