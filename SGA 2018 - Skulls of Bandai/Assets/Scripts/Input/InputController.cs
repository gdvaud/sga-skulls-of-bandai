using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Manager {

    [Header("Key configurations")]
    [SerializeField] private InputControllerScheme schemes;

    [Header("Events")]
    [SerializeField] private GameEvent onMovingEvent;
    [SerializeField] private GameEvent onInteractionEvent;
    [SerializeField] private GameEvent onPauseEvent;
    [SerializeField] private GameEvent onQuitEvent;
    
    private void Update() {
        CheckInputs();
    }

    private void CheckInputs() {
        // === Pause 
        if (Input.GetKeyDown(schemes.pauseKey)) {
            OnPause();
        }
        // =========================

        // === Interaction 
        if (Input.GetKeyDown(schemes.interactionKey)) {
            OnInteraction(true);
        }
        if (Input.GetKeyUp(schemes.interactionKey)) {
            OnInteraction(false);
        }
        // =========================

        // === Direction 
        Vector2 direction = Vector2.zero;
        direction.x = Input.GetAxisRaw("Vertical");
        direction.y = Input.GetAxisRaw("Horizontal");
        //OnMoving(direction);
        // =========================
    }

    public void OnMoving(Vector2 direction) {
        if (onMovingEvent != null) {
            onMovingEvent.Fire(new EventMessage<Vector2>(this, direction));
        } else {

        }
    }

    public void OnInteraction(bool started) {
        if (onInteractionEvent != null) {
            onInteractionEvent.Fire(new EventMessage<bool>(this, started));
        } else {

        }
    }

    public void OnPause() {
        if (onPauseEvent != null) {
            onPauseEvent.Fire(new EventMessage(this));
        } else {

        }
    }

    public void OnQuit() {
        if (onQuitEvent != null) {
            onQuitEvent.Fire(new EventMessage(this));
        } else {

        }
    }

    public void print(EventMessage msg) {
        Debug.Log(msg);
    }
}
