using UnityEngine;

public abstract class Item : MonoBehaviour {

    [SerializeField] protected float interactionTime;
    protected float interactionTimeSpent;

    protected PlayerManager playerInteracting;
    private ItemManager itemManager;

    protected void Start() {
        playerInteracting = null;
        itemManager = FindObjectOfType<ItemManager>();
    }

    protected void OnEnable() {
        if (itemManager != null) {
            itemManager.AddItem(this);
        }
    }

    protected void OnDisable() {
        if (itemManager != null) {
            itemManager.RemoveItem(this);
        }
    }

    protected void Update() {
        if (playerInteracting != null) {
            interactionTimeSpent += Time.deltaTime;
            if (interactionTimeSpent > interactionTime) {
                OnInteractîonFinished();
            }
        }
    }

    // Called when the interaction timer has ended
    protected abstract void OnInteractîonFinished();

    // Called when a player interacts with the item
    public abstract void StartInteraction(PlayerManager player);

    // Returns if a player is already interacting
    protected bool IsInteracting() {
        return playerInteracting != null;
    }

    // Called when interaction is ended (usualy before the end of the timer)
    public void EndInteraction() {
        playerInteracting = null;
    }
}
