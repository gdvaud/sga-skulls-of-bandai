using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    [SerializeField] private GameObject pause;
    [SerializeField] private GameEvent OnResumeEvent;

    private void Start() {
        pause.SetActive(false);
    }

    public void OnPausedValueChanged(GameEventMessage msg) {
        pause.SetActive((bool)msg.value);
    }

    public void OnResume() {
        OnResumeEvent.Fire(new GameEventMessage(this));
    }
}
