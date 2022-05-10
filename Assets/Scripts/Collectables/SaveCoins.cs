using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveCoins
{
    public static void SaveCoin(int numb)
    {
        string path = Application.persistentDataPath + "/cns.unt";
        Collectables.coins += numb;
        int coins = Collectables.coins;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, coins);
        stream.Close();
    }

    public static int LoadCoins()
    {
        string path = Application.persistentDataPath + "/cns.unt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            int coins = (int)formatter.Deserialize(stream);
            stream.Close();
            return coins;
        }
        else
        {
            Debug.Log("The file cant be found.");
            return 0;
        }
    }
}
