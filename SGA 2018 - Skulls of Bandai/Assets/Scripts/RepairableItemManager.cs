using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairableItemManager : MonoBehaviour {
    public enum RepairState {
        DESTROYED, REPAIRING, REPAIRED
    }

    [SerializeField] private RepairableItem item;

    private RepairState state;

    private float repairEndTime;

    // Use this for initialization
    void Start() {
        repairEndTime = -1;
    }

    // Update is called once per frame
    void Update() {
        CheckInteraction();
        switch (state) {
            case RepairState.DESTROYED:
                GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case RepairState.REPAIRED:
                GetComponent<MeshRenderer>().material.color = Color.green;
                break;
            case RepairState.REPAIRING:
                GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
        }
    }

    private void CheckInteraction() {
        if (state == RepairState.REPAIRING && Time.time >= repairEndTime) {
            state = RepairState.REPAIRED;
        }
    }

    public void OnPlayerStartInteraction(GameEventMessage msg) {
        Debug.Log("Start");
        if ((msg.EventSender.transform.position - transform.position).sqrMagnitude < item.interactionRange) {
            if (state != RepairState.REPAIRED) {
                repairEndTime = Time.time + item.repairDuration;
                state = RepairState.REPAIRING;
            }
        }
    }

    public void OnPlayerEndInteraction(GameEventMessage msg) {
        Debug.Log("End");
        if (state != RepairState.REPAIRED) {
            repairEndTime = -1;
            state = RepairState.DESTROYED;
        }
    }
}
