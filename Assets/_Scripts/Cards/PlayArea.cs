using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(
            rectTransform.rect.width,
            rectTransform.rect.height
        );
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CardEventLib.cardPlayed.onEventCalled += onCardPlayed;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        CardEventLib.cardPlayed.onEventCalled -= onCardPlayed;
    }

    private void onCardPlayed(object sender, CardEventLib.CardPlayedEventArgs args)
    {
        GameObject card = args.card;

        //TODO implement logik for card effect execution
        print(Input.mousePosition);
        print(card.GetComponent<Card>().model.title);
    }

}
