using System;
using UnityEngine;

public class CardEventLib
{
    public static readonly GenericEvent<CardEventLib.CardPlayedEventArgs> cardPlayed =
        new GenericEvent<CardEventLib.CardPlayedEventArgs>();

    public readonly struct CardPlayedEventArgs
    {
        public readonly GameObject card;

        public CardPlayedEventArgs(GameObject card)
        {
            this.card = card;
        }
    }
}
