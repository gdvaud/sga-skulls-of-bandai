using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public Player player;

    [Header("Events")]
    [SerializeField] private GameEvent playerInteractionEvent;

	// Use this for initialization
	void Start () {
		
	}

    #region UPDATE
    // Update is called once per frame
    void Update () {
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
        if (Input.GetAxis("Fire1") > 0) {
            playerInteractionEvent.Fire(new GameEventMessage(this));
        }
    }
    #endregion

    #region EVENTS
    public void OnItemPickUp(GameEventMessage msg) {
        Debug.Log("Item picked up");
    }
    #endregion
}
