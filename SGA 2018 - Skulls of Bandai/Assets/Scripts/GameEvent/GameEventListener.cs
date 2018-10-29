using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityMyEvent : UnityEvent<EventMessage>
{

}

public class GameEventListener : MonoBehaviour {
    [SerializeField]
    private GameEvent[] gameEvents;
    [SerializeField]
    private UnityMyEvent myEvent;
    
    private void OnEnable()
    {
        foreach (GameEvent evt in gameEvents)
            evt.AddListerner(this);
    }

    private void OnDisable()
    {
        foreach (GameEvent evt in gameEvents)
            evt.RemoveListerner(this);
    }

    public void SendEvent(EventMessage message)
    {
        myEvent.Invoke(message);
    }
}
