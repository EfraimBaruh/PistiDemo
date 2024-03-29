using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerID;
    public bool isBotPlayer;

    private List<Card> _playerCards = new List<Card>();

    private void OnEnable()
    {
        GameManager.onNextPlayer += OnPlayersTurn;
    }

    private void OnDisable()
    {
        GameManager.onNextPlayer -= OnPlayersTurn;
    }

    public void EnablePlayer()
    {
        foreach(Transform child in transform)
        {
            Card card = child.GetComponent<Card>();
            _playerCards.Add(card);

            card.SetButtonInteractable(!isBotPlayer);
            card.SwitchCardFace(!isBotPlayer);
        }

    }

    public void UseCard(Card card)
    {
        if (_playerCards.Contains(card))
        {
            _playerCards.Remove(card);
            GameManager.Instance.OnPlayerUsesCard(playerID, card);
        }
    }

    private void OnPlayersTurn(int playerID)
    {

        if (playerID == this.playerID)
        {
            if (_playerCards.Count == 0)
            {
                GameManager.Instance.ReDraftForPlayers();
                return;
            }
        }
        if (!isBotPlayer)
        {
            _playerCards = new List<Card>();

            foreach (Transform child in transform)
            {
                Card card = child.GetComponent<Card>();
                _playerCards.Add(card);

                card.SetButtonInteractable(playerID == this.playerID);

                Debug.Log(_playerCards.Count);

            }
        }
        else
        {
            if (playerID == this.playerID)
                StartCoroutine(BotsTurn());
        }
    }

    private IEnumerator BotsTurn()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));

        int cardIndex = PickCard();
        Debug.Log(cardIndex);

        _playerCards[cardIndex].ClickCard();
    }

    private int PickCard()
    {
        int index = Random.Range(0, _playerCards.Count);

        if(MatchFound(ref index))
        {
            Debug.Log("Bot won");
        }

        return index;
    }

    private bool MatchFound(ref int cardIndex)
    {

        Card[] tableCards = GameManager.Instance.TableCardList();

        if (tableCards.Length == 0)
            return false;

        Card latestCard = tableCards[tableCards.Length - 1];

        foreach(Card card in _playerCards)
        {
            if(latestCard.pip == card.pip || card.pip == Pips.Jack)
            {
                cardIndex = _playerCards.IndexOf(card);
                return true;
            }
        }

        return false;
    }

}
