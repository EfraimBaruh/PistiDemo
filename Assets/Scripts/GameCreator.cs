using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCreator : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI betValue;

    private RoomInfo currentRoom;

    private float _bet;
    private int _playerCount = 4;

    public void SetCurrentRoom(RoomCard card)
    {
        currentRoom = card.roomInfo;
    }

    private void Start()
    {
        SetUpSlider();
    }

    private void SetUpSlider()
    {
        slider.minValue = currentRoom.minBet;
        slider.maxValue = currentRoom.maxBet;
    }

    public void UpdateBetValue()
    {
        _bet = slider.value;
        betValue.text = "Current Bet: " + slider.value;
    }

    public void SetPlayerCount(int playerCount)
    {
        _playerCount = playerCount;
    }

    public void CreateGame()
    {
        AppManager.Instance.SetGameType(_playerCount);
        AppManager.Instance.SetGameBet((int)_bet);

        GetComponent<ScriptableEventSystem.ScriptableEventInvoker>().Raise();
    }
}
