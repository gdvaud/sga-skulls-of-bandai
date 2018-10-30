using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Manager {

    [SerializeField] private float movementSpeed = 400f;

    private Rigidbody rigidbody;
    private Animator animator;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public void OnMoveAction(EventMessage msg) {
        Vector3 direction = ((EventMessage<Vector3>)msg).Value;

        Vector3 target = transform.position + direction;

        transform.LookAt(target, transform.up);

        rigidbody.velocity = direction * movementSpeed * Time.deltaTime;

        animator.SetFloat("MoveSpeed", direction.magnitude);
    }
}
