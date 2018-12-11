using UnityEngine;

public class PlayerManager : Manager {

    [SerializeField] private float movementSpeed = 400f;
    [SerializeField] private float interactionRange = 2f;
    [SerializeField] private LayerMask interactionMask;

    private Item interactingItem;
    private float interactionDuration;

    public InventoryManager Inventory { get; private set; }

    private void Start() {
        Inventory = GetComponent<InventoryManager>();
        interactingItem = null;
    }

    private void Update() {
        if (interactingItem != null) {
            interactionDuration += Time.deltaTime;
            if (interactionDuration > interactingItem.InteractionTime) {
                interactingItem.OnInteractionFinished();
                interactingItem = null;
                interactionDuration = 0;
                Debug.Log("Done interacting");
            }
        }
    }

    public void OnMoveAction(EventMessage msg) {
        if (msg is EventMessage<Vector3>) {
            Vector3 direction = ((EventMessage<Vector3>)msg).Value;
            Vector3 target = transform.position + direction;

            transform.LookAt(target, transform.up);
            GetComponent<Rigidbody>().velocity = direction * movementSpeed * Time.deltaTime;
            GetComponent<Animator>().SetFloat("MoveSpeed", direction.magnitude);
        } else {
            Debug.LogWarning("OnMoveAction called with a msg not of type EventMessage<Vector3> instead " + msg.GetType());
        }
    }

    public void OnInteraction(EventMessage msg) {
        if (msg is EventMessage<bool>) {
            bool started = ((EventMessage<bool>)msg).Value;
            if (interactingItem == null && started) {
                // Interaction key pressed
                Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRange, interactionMask);
                if (colliders.Length > 0) {
                    interactingItem = colliders[0].gameObject.GetComponent<Item>();
                    interactingItem.InteractingPlayer = this;
                    Debug.Log("Interacting");
                } else {
                    Debug.LogWarning("No interactable item in range");
                }
            } else if (interactingItem != null && !started) {
                // Interaction key released
                interactingItem = null;
            }
        } else {
            Debug.LogWarning("OnMoveAction called with a msg not of type EventMessage<bool> instead " + msg.GetType());
        }
    }
}
