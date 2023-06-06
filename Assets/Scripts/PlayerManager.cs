using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private List<Card> _playerCards = new List<Card>();

    public void EnablePlayer()
    {
        foreach(Transform child in transform)
        {
            Card card = child.GetComponent<Card>();
            _playerCards.Add(card);

            card.SetButtonInteractable(true);
            card.SwitchCardFace(true);
        }
    }
}