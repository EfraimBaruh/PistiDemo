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
        this.playerCount = playerCount == 4 ? PlayerCount.Four : PlayerCount.Two;
    }

    private void OnApplicationQuit()
    {
        AppData.SaveGame();
    }
}
