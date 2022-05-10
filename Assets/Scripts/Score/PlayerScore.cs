[System.Serializable]
public class PlayerScore
{
    private float HighScore;

    public float highScore
    {
        get { return HighScore; }
        private set { HighScore = value; }
    }

    public float score;

    public PlayerScore(float score, float highScore)
    {
        this.score = score;
        this.highScore = highScore;
    }
}
