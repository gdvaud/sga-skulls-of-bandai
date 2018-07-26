using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventMessage  {
    public Component EventSender
    {
        get;set;
    }

    public GameEvent GameEventSender
    {
        get;set;
    }

    public object value = null;

    public GameEventMessage (Component gameEvent)
    {
        EventSender = gameEvent;
    }

    public GameEventMessage(Component gameEvent, object val) {
        EventSender = gameEvent;
        value = val;
    }

}
