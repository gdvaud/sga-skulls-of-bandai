using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="GameEvents/GameEvent")]
public class GameEvent : ScriptableObject {

    public string eventName = "GameEvent";
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void AddListerner(GameEventListener eventListener)
    {
        listeners.Add(eventListener);
    }


    public void RemoveListerner(GameEventListener eventListener)
    {
        listeners.Remove(eventListener);
    }

    public void Fire(GameEventMessage message)
    {
        message.GameEventSender = this;
        foreach (GameEventListener listener in listeners)
            listener.SendEvent(message);
    }
}
