public class RepairableItem : Item {

    public override void OnInteractionFinished() {
        state = ItemState.REPAIRED;
    }
}
