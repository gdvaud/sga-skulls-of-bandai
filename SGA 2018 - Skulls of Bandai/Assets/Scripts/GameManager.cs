using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int nbItem { get; set; }
    public int totalItems { get; set; }
    [SerializeField] private float maxTimerDuration = 60f;
    private float timeSpent;
    private bool isGameEnded;
    private SceneManagerBase sceneManager;
    [SerializeField] private GameEvent ItemRepairedCountChangedEvent;
    [SerializeField] private GameEvent OnTimerValueChangedEvent;
    [SerializeField] private GameEvent OnPauseValueChangedEvent;
    private bool isPaused;

    // Use this for initialization
    void Start() {
        sceneManager = GetComponent<SceneManagerBase>();
        timeSpent = 0f;
        nbItem = 0;
        totalItems = 0;
        isGameEnded = false;
        isPaused = false;
    }

    private void Update() {
        if (!isPaused) {
            timeSpent += Time.deltaTime;
            OnTimerValueChangedEvent.Fire(new GameEventMessage(this, new Vector2(timeSpent, maxTimerDuration)));
            if (!isGameEnded && timeSpent > maxTimerDuration) {
                sceneManager.ChangeScene("EndGame");
                isGameEnded = true;
            }
        }
    }

    public void OnItemSpawned(GameEventMessage msg) {
        nbItem++;
        totalItems++;
    }

    public void OnItemRepaired(GameEventMessage msg) {
        nbItem--;
        ItemRepairedCountChangedEvent.Fire(new GameEventMessage(this, new Vector2Int(nbItem, totalItems)));
        if (nbItem == 0) {
            Debug.Log("Ended");
            sceneManager.ChangeScene("EndGame");
        }
    }
    public void OnPause(GameEventMessage msg) {
        OnPauseValueChangedEvent.Fire(new GameEventMessage(this, true));
    }

    public void OnResume(GameEventMessage msg) {
        OnPauseValueChangedEvent.Fire(new GameEventMessage(this, false));
    }

    public void OnPausedValueChanged(GameEventMessage msg) {
        isPaused = (bool)msg.value;
    }

}
