using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Transform tableSlot;
    public List<Transform> playerSlots;
    public List<Card> allCards = new List<Card>();

    public UnityEvent onTableStart;

    private List<List<Card>> playersHoldings = new List<List<Card>>();
    private Queue<Card> _availableCards = new();
    private Queue<Card> _tableCards = new();


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

    private void DraftForPlayers()
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
    }

    private float GetCardAngle(int index)
        {return -10f* index + 15;}


}
