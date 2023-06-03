using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class RoomCard : MonoBehaviour
{
    public RoomInfo roomInfo;

    public TextMeshProUGUI title;
    public TextMeshProUGUI range;
    public Image lockImage;
    public Button playNow;
    public Button createTableButton;

    private bool _available;

    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        title.text = roomInfo.roomName;
        range.text = "Bet Range" + ": \n" + roomInfo.minBet + "-" + roomInfo.maxBet;

        // If player gem is enough to enter the room 
        _available = AppData.GetPlayerGem() <= roomInfo.entryThreshold;
        lockImage.enabled = _available;
        playNow.enabled = _available;
        createTableButton.enabled = _available;

    }


    public void UpdateScale()
    {
        float x = transform.position.x;
        x = Mathf.Abs(x);

        if (x > 3)
            transform.DOScale(Vector3.one, 0.2f);

        else
        {
            transform.DOScale(Vector3.one * (-0.1f * x + 1.4f), 0.2f);
        }
    }
}

[System.Serializable]
public class RoomInfo
{
    public string roomName;

    public int minBet;
    public int maxBet;

    public int entryThreshold;
}
