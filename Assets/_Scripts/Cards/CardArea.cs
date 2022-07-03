using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardArea : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject deckCardNumber;
    [SerializeField] private GameObject discardDeckCardNumber;

    private int maxCardsInHand = 3;

    private CardDeck deck;
    private CardDeck discardDeck;
    private List<GameObject> cardsInHand = new List<GameObject>();

    void Start()
    {
        deck = new CardDeck(loadCardDeck());
        discardDeck = new CardDeck();

        updateUi();
    }

    private void OnEnable()
    {
        CardEventLib.cardPlayed.onEventCalled += onCardPlayed;
        DeckEventLib.cardAdded.onEventCalled += onUpdateUi;
        DeckEventLib.cardRemoved.onEventCalled += onUpdateUi;
    }

    private void OnDisable()
    {
        CardEventLib.cardPlayed.onEventCalled -= onCardPlayed;
        DeckEventLib.cardAdded.onEventCalled -= onUpdateUi;
        DeckEventLib.cardRemoved.onEventCalled -= onUpdateUi;
    }

    public void onClickRedraw()
    {
        clearHand(hand);
        redraw();
    }

    public void onCardPlayed(object sender, CardEventLib.CardPlayedEventArgs args)
    {
        GameObject card = args.card;
        CardModel model = card.GetComponent<Card>().model;

        cardsInHand.Remove(card);
        discardDeck.addCard(model);
        Destroy(card);

        if(cardsInHand.Count == 0)
        {
            redraw();
        }
    }

    private void redraw()
    {
        drawCards(hand, maxCardsInHand);
    }

    private void onUpdateUi(object sender, EventArgs args)
    {
        updateUi();
    }

    private void clearHand(GameObject hand)
    {
        for (int i = 0; i < hand.transform.childCount; i++)
        {
            GameObject card = hand.transform.GetChild(i).gameObject;
            CardModel model = card.GetComponent<Card>().model;

            discardDeck.addCard(model);

            Destroy(card);
        }
    }

    private void drawCards(GameObject hand, int cardsToDraw)
    {
        if (deck.getCards().Count < cardsToDraw)
        {
            refillDeckWithDiscardedCards();
        }

        List<CardModel> drawnCards = deck.drawCards(cardsToDraw);

        drawnCards.ForEach(card =>
        {
            cardsInHand.Add(initCard(hand, card));

            deck.removeCard(card);
        });
    }

    private GameObject initCard(GameObject parent, CardModel model)
    {
        GameObject card = Instantiate(
            cardPrefab,
            Vector3.zero,
            Quaternion.identity,
            hand.transform
        );

        card.GetComponent<Card>().model = model;
        card.transform.Find("Image").GetComponent<Image>().sprite = model.sprite;

        return card;
    }

    private List<CardModel> loadCardDeck()
    {
        List<CardData> cardsData = ResourceSystem.Instance.Cards;
        List<CardModel> models = new List<CardModel>();

        foreach (var data in cardsData)
        {
            models.Add(new CardModel(data));
            models.Add(new CardModel(data));
            models.Add(new CardModel(data));
            models.Add(new CardModel(data));
            models.Add(new CardModel(data));
            models.Add(new CardModel(data));
        }

        return models;
    }

    private void refillDeckWithDiscardedCards()
    {
        deck.addCards(discardDeck.getCards());
        discardDeck.removeAll();
    }

    private void updateUi()
    {
        deckCardNumber.GetComponent<TMPro.TextMeshProUGUI>().text =
            deck.getCards().Count.ToString();

        discardDeckCardNumber.GetComponent<TMPro.TextMeshProUGUI>().text =
            discardDeck.getCards().Count.ToString();
    }
}
