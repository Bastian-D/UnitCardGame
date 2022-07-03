using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck
{
    private List<CardData> cards = new List<CardData>();

    public CardDeck()
    { }

    public CardDeck(List<CardData> cardsData)
    {
        cards = cardsData;
    }

    public List<CardData> getCards()
    {
        return cards;
    }

    public void addCard(CardData card, bool shuffel = false)
    {
        cards.Add(card);

        if (shuffel)
        {
            this.shuffel();
        }

        DeckEventLib.cardAdded.callEvent(EventArgs.Empty);
    }

    public void addCards(List<CardData> cards, bool shuffel = true)
    {
        if (shuffel)
        {
            this.shuffel(cards);
        }

        this.cards.AddRange(cards);

        DeckEventLib.cardAdded.callEvent(EventArgs.Empty);
    }

    public List<CardData> drawCards(int cardsToDraw)
    {   
        int avalibleIndices = cards.Count - 1;

        if(avalibleIndices < cardsToDraw)
        {
            return cards.GetRange(0, avalibleIndices);
        }

        return cards.GetRange(0, cardsToDraw);
    }

    public void removeCard(CardData card)
    {
        cards.Remove(card);

        DeckEventLib.cardRemoved.callEvent(EventArgs.Empty);
    }

    public void removeAll()
    {
        cards.Clear();

        DeckEventLib.cardRemoved.callEvent(EventArgs.Empty);
    }

    public void shuffel()
    {
        for (int i = 0; i < cards.Count - 1; i++)
        {
            CardData item = cards[i];
            int randNum = UnityEngine.Random.Range(i, cards.Count);

            cards[i] = cards[randNum];
            cards[randNum] = item;
        }
    }

    public void shuffel(List<CardData> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            CardData item = list[i];
            int randNum = UnityEngine.Random.Range(i, list.Count);

            list[i] = list[randNum];
            list[randNum] = item;
        }
    }

}
