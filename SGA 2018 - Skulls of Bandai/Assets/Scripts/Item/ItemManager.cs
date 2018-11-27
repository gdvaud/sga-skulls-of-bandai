using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Manager {

    private List<Item> items;

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
