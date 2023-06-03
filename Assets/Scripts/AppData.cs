using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppData
{
    private static PlayerData playerData;

    public static void Initialize()
    {
        playerData = new PlayerData()
        {
            name = "player 07",
            gem = 1000
        };
        
    }

    public static string GetPlayerName()
    {
        return playerData.name;
    }

    public static void SetPlayerName(string name)
    {
        playerData.name = name;
    }

    public static int GetPlayerGem()
    {
        return playerData.gem;
    }

    public static void UpdatePlayerGem(int value)
    {
        playerData.gem += value;
    }

    public static int GetPlayerWin()
    {
        return playerData.winCount;
    }

    public static void UpdatePlayerWin()
    {
        playerData.winCount++;
    }

    public static int GetPlayerLost()
    {
        return playerData.lostCount;
    }

    public static void UpdatePlayerLost()
    {
        playerData.lostCount++;
    }

}
