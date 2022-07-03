using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel
{
    [SerializeField] public string title;
    [SerializeField] public string desc;

    public Sprite sprite;

    public CardModel(CardData data)
    {
        title = data.Title;
        desc = data.Desc;
        sprite = data.Sprite;
    }
}
