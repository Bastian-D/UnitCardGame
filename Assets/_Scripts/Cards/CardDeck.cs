using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck
{
    private List<CardModel> cards = new List<CardModel>();

    public CardDeck()
    { }

    public CardDeck(List<CardModel> cards)
    {
        this.cards = cards;
    }

    public List<CardModel> getCards()
    {
        return cards;
    }

    public void addCard(CardModel card, bool shuffel = false)
    {
        cards.Add(card);

        if (shuffel)
        {
            this.shuffel();
        }

        DeckEventLib.cardAdded.callEvent(EventArgs.Empty);
    }

    public void addCards(List<CardModel> cards, bool shuffel = true)
    {
        if (shuffel)
        {
            this.shuffel(cards);
        }

        this.cards.AddRange(cards);

        DeckEventLib.cardAdded.callEvent(EventArgs.Empty);
    }

    public List<CardModel> drawCards(int cardsToDraw)
    {   
        int avalibleIndices = cards.Count - 1;

        if(avalibleIndices < cardsToDraw)
        {
            return cards.GetRange(0, avalibleIndices);
        }

        return cards.GetRange(0, cardsToDraw);
    }

    public void removeCard(CardModel card)
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
            CardModel item = cards[i];
            int randNum = UnityEngine.Random.Range(i, cards.Count);

            cards[i] = cards[randNum];
            cards[randNum] = item;
        }
    }

    public void shuffel(List<CardModel> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            CardModel item = list[i];
            int randNum = UnityEngine.Random.Range(i, list.Count);

            list[i] = list[randNum];
            list[randNum] = item;
        }
    }

}
