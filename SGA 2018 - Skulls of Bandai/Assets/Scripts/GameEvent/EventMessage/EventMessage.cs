using UnityEngine;

public class EventMessage {

    public Component EventSender {
        get; set;
    }

    public GameEvent GameEventSender {
        get; set;
    }

    public EventMessage() : this(null) { }

    public EventMessage(Component sender) {
        EventSender = sender;
    }
}

public class EventMessage<T> : EventMessage {

    public T Value {
        get; private set;
    }

    public EventMessage() : this(null, default(T)) { }

    public EventMessage(Component sender) : this(sender, default(T)) { }

    public EventMessage(Component sender, T value) : base(sender) {
        Value = value;
    }
}