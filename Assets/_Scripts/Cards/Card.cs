using System.Net.Mime;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private TMPro.TextMeshProUGUI cardTitle;
    private TMPro.TextMeshProUGUI cardDesc;
    private Vector3 originPosition;
    private int originHierarchyPosition;
    private bool isOverPlayArea = false;

    public CardModel model;

    void Start()
    {
        setupText();
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

    private void setupText()
    {
        cardTitle = transform.Find("Title").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        cardDesc = transform.Find("Desc").gameObject.GetComponent<TMPro.TextMeshProUGUI>();

        cardTitle.text = model.title;
        cardDesc.text = model.desc;
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
