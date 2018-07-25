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

    public const int DEFAULT_INT = -1;
    public const float DEFAULT_FLOAT = -1f;
    public const string DEFAULT_STRING = "DEFAULT_STRING";

    public int intValue = DEFAULT_INT;
    public int intValue1 = DEFAULT_INT;
    public int intValue2 = DEFAULT_INT;
    public float floatValue = DEFAULT_FLOAT;
    public float floatValue1 = DEFAULT_FLOAT;
    public float floatValue2 = DEFAULT_FLOAT;
    public bool boolValue;
    public bool boolValue1;
    public bool boolValue2;
    public string stringValue = DEFAULT_STRING;
    public string stringValue1 = DEFAULT_STRING;
    public string stringValue2 = DEFAULT_STRING;

    public GameEventMessage (Component gameEvent)
    {
        EventSender = gameEvent;
    }
	
}
