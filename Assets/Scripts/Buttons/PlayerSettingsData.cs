[System.Serializable]
public class PlayerSettingsData
{
    public float lineOffsetX;
    public float lineOffsetY;
    public float lineWidth;
    public float gameSpeed;

    public PlayerSettingsData(float x, float y, float w, float s)
    {
        lineOffsetX = x;
        lineOffsetY = y;
        lineWidth = w;
        gameSpeed = s;
    }
}
