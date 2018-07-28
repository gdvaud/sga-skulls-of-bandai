using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField] private float movementSpeed = 400f;
    [SerializeField] private AnimationCurve moveSpeedCurve;
    [SerializeField] private GameEvent PlayerMovedEvent;
    private bool canMove;
    private Rigidbody rb;
    private Animator anim;

    private void Start() {
        canMove = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public void OnMoving(GameEventMessage msg) {
        if (canMove) {
            Vector3 direction = (Vector3)msg.value;

            Vector3 target = transform.position + direction;

            transform.LookAt(target, transform.up);

            rb.velocity = direction * movementSpeed * Time.deltaTime;

            anim.SetFloat("MoveSpeed", moveSpeedCurve.Evaluate(direction.magnitude));
            PlayerMovedEvent.Fire(new GameEventMessage(this, transform.position));
        } else {
            rb.velocity = Vector3.zero;
            anim.SetFloat("MoveSpeed", 0);
        }
    }

    public void OnPausedValueChanged(GameEventMessage msg) {
        canMove = !(bool)msg.value;
    }
}
