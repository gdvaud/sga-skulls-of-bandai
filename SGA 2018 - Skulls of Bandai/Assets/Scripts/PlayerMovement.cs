using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public PlayerData player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = Vector3.zero;

        direction.z = Input.GetAxis("Vertical");
        direction.x = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody>().velocity = (direction * player.movementSpeed);
    }
}
