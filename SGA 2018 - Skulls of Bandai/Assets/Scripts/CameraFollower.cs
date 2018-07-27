using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    private Vector3 oldPlayerPosition = Vector3.zero;
    private bool isFirst;

    private void Start() {
        isFirst = true;
    }

    public void OnPlayerMoved(GameEventMessage msg) {
        Vector3 playerPosition = (Vector3)msg.value;
        if (!isFirst) {
            transform.position += playerPosition - oldPlayerPosition;
        } else {
            isFirst = false;
        }
        oldPlayerPosition = playerPosition;
    }
}
