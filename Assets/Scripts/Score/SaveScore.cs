using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveScore
{
    public static void SaveScores(float score, float highScore)
    {
        string path = Application.persistentDataPath + "/rcs.unt";
        PlayerScore playerScore = new PlayerScore(score, highScore);
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, playerScore);
        stream.Close();
    }

    public static PlayerScore LoadScore()
    {
        string path = Application.persistentDataPath + "/rcs.unt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerScore playerScore = formatter.Deserialize(stream) as PlayerScore;
            stream.Close();
            return playerScore;
        }
        else
        {
            Debug.Log("The file cant be found.");
            SaveScores(0, 0);
            return null;
        }
    }
}
