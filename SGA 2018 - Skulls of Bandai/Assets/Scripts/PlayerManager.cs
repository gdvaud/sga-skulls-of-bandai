using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Manager {

    [SerializeField] private float movementSpeed = 400f;
    [SerializeField] private float interactionRange = 2f;
    [SerializeField] private LayerMask interactionMask;

    private Item interactingItem;

    private Rigidbody rigidbody;
    private Animator animator;
    private InventoryManager inventory;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        inventory = GetComponent<InventoryManager>();
        interactingItem = null;
    }

    public void OnMoveAction(EventMessage msg) {
        if (msg is EventMessage<Vector3>) {
            Vector3 direction = ((EventMessage<Vector3>)msg).Value;
            Vector3 target = transform.position + direction;

            transform.LookAt(target, transform.up);
            rigidbody.velocity = direction * movementSpeed * Time.deltaTime;
            animator.SetFloat("MoveSpeed", direction.magnitude);
        } else {
            Debug.LogWarning("OnMoveAction called with a msg not of type EventMessage<Vector3> instead " + msg.GetType());
        }
    }

    public void OnInteraction(bool started) {
        if (interactingItem == null && started) {
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRange, interactionMask);
            if (colliders.Length > 0) {
                interactingItem = colliders[0].gameObject.GetComponent<Item>();
            } else {
                Debug.LogWarning("No interactable item in range");
            }
        } else if (interactingItem != null && !started) {
            interactingItem = null;
        } else {
            Debug.LogWarning("Already interacting");
        }
    }
}
