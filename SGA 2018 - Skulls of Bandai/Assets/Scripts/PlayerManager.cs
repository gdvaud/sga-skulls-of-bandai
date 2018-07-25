using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public Player player;

    private bool wasInteracting;

    [Header("Events")]
    [SerializeField] private GameEvent playerStartInteractionEvent;
    [SerializeField] private GameEvent playerEndInteractionEvent;

    // Use this for initialization
    void Start() {
        wasInteracting = false;
    }

    #region UPDATE
    // Update is called once per frame
    void Update() {
        CheckInputs();
        MovePlayer();
    }

    private void MovePlayer() {
        Vector3 direction = Vector3.zero;

        direction.z = Input.GetAxis("Vertical");
        direction.x = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody>().velocity = (direction * player.movementSpeed);
    }

    private void CheckInputs() {
        if (wasInteracting) {
            if (Input.GetAxis("Fire1") == 0) {
                wasInteracting = false;
                playerEndInteractionEvent.Fire(new GameEventMessage(this));
            }
        } else {
            if (Input.GetAxis("Fire1") > 0) {
                wasInteracting = true;
                playerStartInteractionEvent.Fire(new GameEventMessage(this));
            }
        }
    }
    #endregion

    #region EVENTS
    #endregion
}
