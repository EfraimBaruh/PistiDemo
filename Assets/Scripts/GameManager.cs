using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static Action<int> onNextPlayer;

    public Transform tableSlot;
    public List<Transform> playerSlots;
    public List<Card> allCards = new List<Card>();

    public UnityEvent onTableStart;

    private List<List<Card>> playersHoldings = new List<List<Card>>();
    private Queue<Card> _availableCards = new();
    private Queue<Card> _tableCards = new();

    private int currentPlayer;

    public Card[] TableCardList()
    {
        return _tableCards.ToArray();
    }


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
        }
    }

    private void Start()
    {
        StartCoroutine(GameCore());
    }

    public IEnumerator GameCore()
    {
        SetUpPlayers();

        ShuffleCards(ref allCards);

        foreach (Card card in allCards)
            _availableCards.Enqueue(card);


        DraftForPlayers();

        DraftForTable();

        yield return null;

        onTableStart.Invoke();

    }

    private void SetUpPlayers()
    {
        int playerCount = (int)AppManager.Instance.playerCount;

        Utils.Resize(playerSlots, playerCount);

        for (int i = 0; i < playerCount; i++)
            playersHoldings.Add(new List<Card>());
    }

    private void ShuffleCards(ref List<Card> carList)
    {
        Utils.Shuffle(carList);
    }

    public void DraftForPlayers()
    {

        for (int i = 0; i < playersHoldings.Count; i++)
        {
            for (int j = 0; j < 4; j++)
                playersHoldings[i].Add(_availableCards.Dequeue());
        }

        for (int i = 0; i < playersHoldings.Count; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Card card = playersHoldings[i][j];
                card.transform.SetParent(playerSlots[i]);
                card.transform.localEulerAngles = Vector3.forward * GetCardAngle(j);
            }
        }
    }

    private void DraftForTable()
    {
        // Set up initial cards on table.
        for (int j = 0; j < 4; j++)
        {
            Card card = _availableCards.Dequeue();
            _tableCards.Enqueue(card);
            card.transform.SetParent(tableSlot);
            card.transform.position = Vector3.zero;
            card.transform.localEulerAngles = Vector3.forward * GetCardAngle(j);
            card.SwitchCardFace(j == 3);

        }
        
    }

    public void OnPlayerUsesCard(int playerId, Card card)
    {
        playersHoldings[playerId].Remove(card);
        card.transform.SetParent(tableSlot);
        _tableCards.Enqueue(card);

        ControlPisti(playerId);
        NextPlayer();
    }

    private void ControlPisti(int playerId)
    {
        if (_tableCards.Count < 2)
            return;

        else
        {

            Card[] cards = _tableCards.ToArray();
            Debug.Log(cards.Length);

            if (cards[cards.Length-1].pip == cards[cards.Length-2].pip || cards[cards.Length - 1].pip == Pips.Jack)
            {
                if (cards.Length == 5)
                    Debug.Log("Pisti");
                else
                    Debug.Log("Points taken and cards");

                var y = 3 * (playerId % 2 == 0 ? -1 : 1);
                var x = 7 * (playerId % 3 == 0 ? 1 : -1);

                StartCoroutine(CollectCards(x, y));
               
            }
        }
    }

    private IEnumerator CollectCards(float X_target, float Y_target)
    {
        yield return new WaitForSeconds(0.3f);

        foreach (Card card in _tableCards)
        {
            card.SwitchCardFace(false);

            card.transform.DOMoveY(Y_target, 0.6f);

            card.transform.DOMoveX(X_target, 0.6f).OnComplete(() =>
            {
                card.transform.parent = null;
            });
        }

        _tableCards = new Queue<Card>();
    }

    private void NextPlayer()
    {
        currentPlayer++;
        currentPlayer = currentPlayer % playerSlots.Count;
        onNextPlayer.Invoke(currentPlayer);

    }

    private float GetCardAngle(int index)
        {return -10f* index + 15;}


}
