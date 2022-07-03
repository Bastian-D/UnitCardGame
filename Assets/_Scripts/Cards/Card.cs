using System.Net.Mime;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private TMPro.TextMeshProUGUI title;
    private TMPro.TextMeshProUGUI desc;
    private Sprite sprite;
    private Vector3 originPosition;
    private int originHierarchyPosition;
    private bool isOverPlayArea = false;

    public CardData data;

    void Start()
    {
        setup();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D()
    {
        isOverPlayArea = true;
    }

    private void OnCollisionExit2D()
    {
        isOverPlayArea = false;
    }

    private void setup()
    {
        title = transform.Find("Title").GetComponent<TMPro.TextMeshProUGUI>();
        desc = transform.Find("Desc").GetComponent<TMPro.TextMeshProUGUI>();
        sprite = transform.Find("Image").GetComponent<Image>().sprite;

        title.text = data.Title;
        desc.text = data.Desc;
        sprite = data.Sprite;
    }

    public void onMsgDragStarted()
    {
        originPosition = transform.position;

        originHierarchyPosition = gameObject.transform.GetSiblingIndex();
        gameObject.transform.SetAsLastSibling();
    }
    public void onMsgDragEnded()
    {
        if (isOverPlayArea)
        {
            CardEventLib.cardPlayed.callEvent(
                new CardEventLib.CardPlayedEventArgs(gameObject)
            );
        }
        else
        {
            transform.position = originPosition;
            gameObject.transform.SetSiblingIndex(originHierarchyPosition);
        }
    }
}
