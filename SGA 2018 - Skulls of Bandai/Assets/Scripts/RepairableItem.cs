using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/RepairableItem")]
public class RepairableItem : ScriptableObject {
    public enum RepairState {
        DESTROYED, REPAIRING, REPAIRED
    }

    public RepairState state;
}
