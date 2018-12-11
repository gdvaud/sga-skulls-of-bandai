using UnityEngine;

public class CarriableItem : Item {

    public override void OnInteractionFinished() {
        state = ItemState.CARRIED;
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        InteractingPlayer.Inventory.AddItem(this);

        base.OnInteractionFinished();
    }
}
