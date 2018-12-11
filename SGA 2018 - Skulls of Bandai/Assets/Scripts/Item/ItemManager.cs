using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Manager {

    [SerializeField] private List<Item> items;

    private void FixedUpdate() {
        CheckIfItemsRepaired();
    }

    private void CheckIfItemsRepaired() {
        foreach(Item i in items) {
            if (!i.IsRepaired()) {
                return;
            }
        }
        // All item repaired
        Debug.Log("Items repaired");
    }

    public void AddItem(Item item) {
        if (!items.Contains(item)) {
            items.Add(item);
        }
    }

    public void RemoveItem(Item item) {
        if (items.Contains(item)) {
            items.Remove(item);
        }
    }
}
