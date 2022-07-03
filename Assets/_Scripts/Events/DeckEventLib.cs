using System;
using UnityEngine;

public class DeckEventLib
{
    public static readonly GenericEvent<EventArgs> cardAdded = new GenericEvent<EventArgs>();
    public static readonly GenericEvent<EventArgs> cardRemoved = new GenericEvent<EventArgs>();
}
