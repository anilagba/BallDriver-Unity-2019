using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveDatas
{
    public static void SaveData(float x, float y, float w, float s)
    {
        string path = Application.persistentDataPath + "/data.unt";
        PlayerSettingsData playerData = new PlayerSettingsData(x, y, w, s);
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerSettingsData LoadData()
    {
        string path = Application.persistentDataPath + "/data.unt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerSettingsData playerData = formatter.Deserialize(stream) as PlayerSettingsData;
            stream.Close();
            return playerData;
        }
        else
        {
            Debug.Log("The file cant be found.");
            return null;
        }
    }
}
