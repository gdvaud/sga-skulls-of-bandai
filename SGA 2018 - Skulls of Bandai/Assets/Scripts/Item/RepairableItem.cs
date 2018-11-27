public class RepairableItem : Item {

    protected override void OnInteractîonFinished() {
        playerInteracting.ItemInteractionFinished();
    }

    public override void StartInteraction(PlayerManager player) {
        if (!IsInteracting()) {
            playerInteracting = player;
        }
    }
}
