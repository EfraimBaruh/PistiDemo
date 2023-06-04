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

public class Card : PressableButton
{
     public Suits suit;
     public Pips pip;

    protected override void ButtonClick()
    {
        transform.DOMove(Vector3.zero, 0.3f);
    }
}
