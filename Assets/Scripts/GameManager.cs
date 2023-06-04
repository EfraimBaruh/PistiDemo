using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<Card> allCards = new List<Card>();

    private Queue<Card> AvailableCards = new();
    private List<Queue<Card>> playerQueues = new List<Queue<Card>>(); 

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
        foreach (Card card in allCards)
            AvailableCards.Enqueue(card);
    }

    public IEnumerator GameCore()
    {

        yield return null;
    }

    private void ShuffleCards(List<Card> carList)
    {

    }

}
