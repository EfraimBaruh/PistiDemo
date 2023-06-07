using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerCount
{
    Two = 2,
    Four = 4
}

public class AppManager : MonoBehaviour
{
    public static AppManager Instance { get; private set; }

    public PlayerCount playerCount = PlayerCount.Two;
    public int gameBet = 0;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;

            AppData.Initialize();
        }

        DontDestroyOnLoad(this);
    }

    public void SetGameType(int playerCount)
    {
        this.playerCount = (PlayerCount)playerCount;
    }

    public void SetGameBet(int bet)
    {
        gameBet = bet;
    }

    private void OnApplicationQuit()
    {
        AppData.SaveGame();
    }
}
