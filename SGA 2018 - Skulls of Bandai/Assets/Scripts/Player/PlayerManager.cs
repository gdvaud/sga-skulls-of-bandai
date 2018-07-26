using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField] private float movementSpeed = 400f;
    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMoving(GameEventMessage msg) {
        Vector3 direction = (Vector3) msg.value;
        rb.velocity = direction * movementSpeed * Time.deltaTime;
    }
}
