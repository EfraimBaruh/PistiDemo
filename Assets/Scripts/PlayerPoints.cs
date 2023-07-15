using TMPro;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public int playerID;

    private TextMeshProUGUI value;

    private int playerPoints;

    private void Start()
    {
        value = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnEnable()
    {
        GameManager.onPlayerWon += OnPlayerWon;


        int playerCount = (int)AppManager.Instance.playerCount;

        gameObject.SetActive(playerCount > playerID);
    }

    private void OnDisable()
    {
        GameManager.onPlayerWon -= OnPlayerWon;
    }

    private void OnPlayerWon(int player, int points)
    {
        if(player == playerID)
        {
            playerPoints += points;
            UpdatePlayerPoints();
        }
    }

    private void UpdatePlayerPoints()
    {
        value.text = playerPoints.ToString();

        // TODO: control game is over or anything.
    }
}
