using UnityEngine;

public abstract class Item : MonoBehaviour {

    [SerializeField] private float interactionTime;
    public float InteractionTime {
        get { return interactionTime; }
        protected set { interactionTime = value; }
    }

    protected ItemState state;

    private ItemManager itemManager;
    public PlayerManager InteractingPlayer { get; set; }

    protected void Start() {
        state = ItemState.UNTOUCHED;
        itemManager = FindObjectOfType<ItemManager>();
        itemManager.AddItem(this);
    }

    public virtual void OnInteractionFinished() {
        InteractingPlayer = null;
    }

    public bool IsRepaired() {
        return state == ItemState.REPAIRED;
    }

    protected enum ItemState {
        UNTOUCHED,
        CARRIED,
        REPAIRED
    }
}
