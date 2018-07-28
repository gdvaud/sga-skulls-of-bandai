using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    [SerializeField] private GameEvent OnInteractionStartedEvent;
    [SerializeField] private GameEvent OnInteractionEndedEvent;
    private bool wasPressingInteractionKey;
    [SerializeField] private GameEvent OnMovingEvent;
    [SerializeField] private GameEvent OnPausingEvent;
    private bool wasPressingPauseKey;

    private void Start() {
        wasPressingPauseKey = false;
        wasPressingInteractionKey = false;
    }

    // Update is called once per frame
    private void Update() {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.z = Input.GetAxis("Vertical");
        moveDirection.x = Input.GetAxis("Horizontal");
        OnMovingEvent.Fire(new GameEventMessage(this, moveDirection));

        if (wasPressingInteractionKey) {
            if (Input.GetAxis("Interact") == 0) {
                wasPressingInteractionKey = false;
                Debug.Log("Interaction End");
                OnInteractionEndedEvent.Fire(new GameEventMessage(this));
            }
        } else {
            if (Input.GetAxis("Interact") > 0) {
                wasPressingInteractionKey = true;
                Debug.Log("Interaction Start");
                OnInteractionStartedEvent.Fire(new GameEventMessage(this));
            }
        }

        if (wasPressingPauseKey) {
            if (Input.GetAxis("Pause") == 0) {
                wasPressingPauseKey = false;
                Debug.Log("Pause end");
            }
        } else {
            if (Input.GetAxis("Pause") > 0) {
                wasPressingPauseKey = true;
                Debug.Log("Pause Start");
                OnPausingEvent.Fire(new GameEventMessage(this));
            }
        }
    }
}
