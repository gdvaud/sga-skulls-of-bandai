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
        Vector3 direction = Vector3.zero;
        direction.z = Input.GetAxisRaw("Vertical");
        direction.x = Input.GetAxisRaw("Horizontal");
        OnMoving(direction);
        // =========================
    }

    public void OnMoving(Vector3 direction) {
        if (onMovingEvent != null) {
            onMovingEvent.Fire(new EventMessage<Vector3>(this, direction));
        } else {
            Debug.LogWarning("OnMoving event not assigned");
        }
    }

    public void OnInteraction(bool started) {
        if (onInteractionEvent != null) {
            onInteractionEvent.Fire(new EventMessage<bool>(this, started));
        } else {
            Debug.LogWarning("OnInteraction event not assigned");
        }
    }

    public void OnPause() {
        if (onPauseEvent != null) {
            onPauseEvent.Fire(new EventMessage(this));
        } else {
            Debug.LogWarning("OnPause event not assigned");
        }
    }

    public void OnQuit() {
        if (onQuitEvent != null) {
            onQuitEvent.Fire(new EventMessage(this));
        } else {
            Debug.LogWarning("OnQuit event not assigned");
        }
    }

    public void print(EventMessage msg) {
        Debug.Log(msg);
    }
}
