using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class AppData
{
    private static PlayerData playerData;

    public static void Initialize()
    {


        if (!LoadGame())
        {
            DefaultSetup defaultSetup = Resources.Load<DefaultSetup>("DefaultSetUp");
            playerData = new PlayerData()
            {
                name = defaultSetup.initialName,
                gem = defaultSetup.initialGem
            };
        }


    }

    public static string GetPlayerName()
    {
        return playerData.name;
    }

    public static void SetPlayerName(string name)
    {
        playerData.name = name;
        SaveGame();
    }

    public static int GetPlayerGem()
    {
        return playerData.gem;
    }

    public static void UpdatePlayerGem(int value)
    {
        playerData.gem += value;
        SaveGame();
    }

    public static int GetPlayerWin()
    {
        return playerData.winCount;
    }

    public static void UpdatePlayerWin()
    {
        playerData.winCount++;
        SaveGame();
    }

    public static int GetPlayerLost()
    {
        return playerData.lostCount;
    }

    public static void UpdatePlayerLost()
    {
        playerData.lostCount++;
        SaveGame();
    }

    public static void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                     + "/PlayerData.dat");


        bf.Serialize(file, playerData);
        file.Close();
    }

    public static bool LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
                       + "/PlayerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                       File.Open(Application.persistentDataPath
                       + "/PlayerData.dat", FileMode.Open);

            playerData = (PlayerData)bf.Deserialize(file);
            file.Close();

            return true;
        }
        else
            return false;
    }

    public static void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
                      + "/PlayerData.dat"))
        {
            File.Delete(Application.persistentDataPath
                              + "/PlayerData.dat");
            
        }
    }

}
