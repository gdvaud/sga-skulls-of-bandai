using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/RepairableItem")]
public class RepairableItem : ScriptableObject {

    public float interactionRange = 2f;
    public float repairDuration = 2f;
}
