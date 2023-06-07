using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum Pips
{
    Ace = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13
}

public enum Suits
{
    Clubs = 0,
    Diamonds = 1,
    Hearts = 2,
    Spades = 3
}

[RequireComponent(typeof(Image))]
public class Card : PressableButton
{
    public Suits suit;
    public Pips pip;

    public Sprite cardBackground;
    public Sprite cardForeground;

    private Image _image;
    private bool showCard;

    protected override void Awake()
    {
        base.Awake();

        _image = GetComponent<Image>();

        SwitchCardFace(showCard);
        SetButtonInteractable(false);
    }

    protected override void ButtonClick()
    {
        transform.DOMove(Vector3.zero, 0.3f);

        if (transform.parent.GetComponent<PlayerManager>())
            transform.parent.GetComponent<PlayerManager>().UseCard(this);
    }

    public void SwitchCardFace(bool show)
    {
        showCard = show;

        _image.sprite = showCard ? cardForeground : cardBackground;

        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(showCard);
    }
}
