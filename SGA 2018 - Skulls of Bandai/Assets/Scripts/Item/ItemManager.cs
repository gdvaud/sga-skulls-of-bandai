using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

    [SerializeField] private ItemState state;
    [SerializeField] private float reparationDuration = 1f;
    private float reperationStartTime;
    [SerializeField] private GameEvent ItemRepairedEvent;
    [SerializeField] private GameObject jauge;
    [SerializeField] private Image jaugeSlider;
    [SerializeField] private GameEvent ItemSpawnedEvent; 

	// Use this for initialization
	void Start () {
        state = ItemState.DESTROYED;
        reperationStartTime = 0;
        jauge.SetActive(false);
        ItemSpawnedEvent.Fire(new GameEventMessage(this));
    }
	
	// Update is called once per frame
	void Update () {
		if (state == ItemState.REPAIRING) {
            if (Time.time > reperationStartTime + reparationDuration) {
                //end of reparing
                state = ItemState.REPAIRED;
                ItemRepairedEvent.Fire(new GameEventMessage(this));
                //Hide ProgressBar definitively
                jauge.SetActive(false);
                //Jaugeslider
            }
            else
            {
                //ProgressBar is increasing
                jaugeSlider.fillAmount = (Time.time- reperationStartTime )/ reparationDuration;
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
            //ProgressBar is increasing
            jaugeSlider.fillAmount = 0f;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Player")) {
            if (state != ItemState.REPAIRED) {
                state = ItemState.PLAYER_IN_RANGE;
                //Show ProgresssBar popup key notification
                jauge.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag.Equals("Player")) {
            if (state != ItemState.REPAIRED) {
                jaugeSlider.fillAmount = 0f;
                state = ItemState.DESTROYED;
                jauge.SetActive(false);
            }
        }
    }
}
