using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMessage {

    public Component EventSender {
        get; set;
    }

    public GameEvent GameEventSender {
        get; set;
    }

    public EventMessage(Component gameEvent) {
        EventSender = gameEvent;
    }
}
