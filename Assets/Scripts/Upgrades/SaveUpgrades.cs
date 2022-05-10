using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveUpgrades
{
    #region SaveSlowDown
    public static void SaveSlowDown(int numb)
    {
        string path = Application.persistentDataPath + "/sld.unt";
        Upgrades.slowDown = LoadSlowDown() + numb;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, Upgrades.slowDown);
        stream.Close();
    }
    #endregion

    #region LoadSlowDown
    public static int LoadSlowDown()
    {
        string path = Application.persistentDataPath + "/sld.unt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Upgrades.slowDown = (int)formatter.Deserialize(stream);
            stream.Close();
            return Upgrades.slowDown;
        }
        else
        {
            Debug.Log("The file cant be found.");
            return 0;
        }
    }
    #endregion

    #region SaveSizeDecrease
    public static void SaveSizeDecrease(int numb)
    {
        string path = Application.persistentDataPath + "/szd.unt";
        Upgrades.sizeDec = LoadSizeDecrease() + numb;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, Upgrades.sizeDec);
        stream.Close();
    }
    #endregion

    #region LoadSizeDecrease
    public static int LoadSizeDecrease()
    {
        string path = Application.persistentDataPath + "/szd.unt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Upgrades.sizeDec = (int)formatter.Deserialize(stream);
            stream.Close();
            return Upgrades.sizeDec;
        }
        else
        {
            Debug.Log("The file cant be found.");
            return 0;
        }
    }
    #endregion

    #region SaveBouncinessDecrease
    public static void SaveBouncinessDecrease(int numb)
    {
        string path = Application.persistentDataPath + "/bd.unt";
        Upgrades.bouncyDec = LoadBouncinessDecrease() + numb;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, Upgrades.bouncyDec);
        stream.Close();
    }
    #endregion

    #region LoadBouncinessDecrease
    public static int LoadBouncinessDecrease()
    {
        string path = Application.persistentDataPath + "/bd.unt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Upgrades.bouncyDec = (int)formatter.Deserialize(stream);
            stream.Close();
            return Upgrades.bouncyDec;
        }
        else
        {
            Debug.Log("The file cant be found.");
            return 0;
        }
    }
    #endregion

    #region SaveBoxBreaker
    public static void SaveBoxBreaker(int numb)
    {
        string path = Application.persistentDataPath + "/bb.unt";
        Upgrades.boxBreaker = LoadBoxBreaker() + numb;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, Upgrades.boxBreaker);
        stream.Close();
    }
    #endregion

    #region LoadBoxBreaker
    public static int LoadBoxBreaker()
    {
        string path = Application.persistentDataPath + "/bb.unt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Upgrades.boxBreaker = (int)formatter.Deserialize(stream);
            stream.Close();
            return Upgrades.boxBreaker;
        }
        else
        {
            Debug.Log("The file cant be found.");
            return 0;
        }
    }
    #endregion
}
