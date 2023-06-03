using TMPro;
using UnityEngine;

public enum Value
{
    name,
    gem,
    winCount,
    lostCount
}

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIValue : MonoBehaviour
{
    [SerializeField] private Value value;    // Start is called before the first frame update

    private TextMeshProUGUI field;

    private void Awake()
    {
        field = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        UpdateValue();
    }

    public void UpdateValue()
    {
        switch (value)
        {
            case Value.name:
                field.text = AppData.GetPlayerName();
                break;
            case Value.gem:
                field.text = AppData.GetPlayerGem().ToString();
                break;
            case Value.winCount:
                field.text = AppData.GetPlayerWin().ToString();
                break;
            case Value.lostCount:
                field.text = AppData.GetPlayerLost().ToString();
                break;
        }
    }
}
