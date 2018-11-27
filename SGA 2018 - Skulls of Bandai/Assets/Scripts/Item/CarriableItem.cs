using UnityEngine;

public class CarriableItem : Item {

    protected override void OnInteractîonFinished() {
        Debug.Log("Finished");
        if (!playerInteracting.Inventory.AddItem(this)) {
            Debug.LogWarning("Inventory is full");
        }
        playerInteracting.ItemInteractionFinished();
    }

    public override void StartInteraction(PlayerManager player) {
        if (!IsInteracting() && !player.Inventory.IsFull()) {
            playerInteracting = player;
        }
    }
}
