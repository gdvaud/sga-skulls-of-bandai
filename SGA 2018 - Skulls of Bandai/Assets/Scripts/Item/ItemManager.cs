using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    [SerializeField] private ItemState state;
    [SerializeField] private float reparationDuration = 1f;
    private float reperationStartTime;
    [SerializeField] private GameEvent ItemRepairedEvent;
    [SerializeField] private GameEvent ItemSpawnedEvent; 

	// Use this for initialization
	void Start () {
        state = ItemState.DESTROYED;
        reperationStartTime = 0;
        ItemSpawnedEvent.Fire(new GameEventMessage(this));
    }
	
	// Update is called once per frame
	void Update () {
		if (state == ItemState.REPAIRING) {
            if (Time.time > reperationStartTime + reparationDuration) {
                state = ItemState.REPAIRED;
                ItemRepairedEvent.Fire(new GameEventMessage(this));
            }
        }
	}

    public void OnInteractionStarted(GameEventMessage msg) {
        if (state == ItemState.PLAYER_IN_RANGE) {
            state = ItemState.REPAIRING;
            reperationStartTime = Time.time;
        }
    }

    public void OnInteractionEnded(GameEventMessage msg) {
        if (state == ItemState.REPAIRING) {
            state = ItemState.PLAYER_IN_RANGE;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Player")) {
            if (state != ItemState.REPAIRED) {
                state = ItemState.PLAYER_IN_RANGE;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag.Equals("Player")) {
            if (state != ItemState.REPAIRED) {
                state = ItemState.DESTROYED;
            }
        }
    }
}
