using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragged = false;

    void Update()
    {
        if (isDragged)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void onStartDrag()
    {
        isDragged = true;
        SendMessage("onMsgDragStarted");
    }

    public void onEndDrag()
    {
        isDragged = false;
        SendMessage("onMsgDragEnded");
    }
}
