using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneManagerBase : Manager {

    [Header("Base parameters")]
    [SerializeField] protected bool isDebuging = false;
    [SerializeField] protected CanvasGroup loadingCanvas = null;
    [SerializeField] protected string initialScene;
    [SerializeField] protected SceneLoadingStateEvents[] onStateChangedEvents;

    private Dictionary<SceneLoadingState, GameEvent> dicOnStateChangedEvents;

    private SceneLoadingState _state;
    protected SceneLoadingState state {
        get { return _state; }
        set {
            _state = value;
            GameEvent evnt = null;
            dicOnStateChangedEvents.TryGetValue(_state, out evnt);
            if (evnt != null) {
                evnt.Fire(null);
            }
        }
    }

    protected void Start() {
        Debug.Log("Started " + isDebuging);
        dicOnStateChangedEvents = new Dictionary<SceneLoadingState, GameEvent>();
        UpdateOnStateChangedEvents();
        if (!isDebuging) {
            ChangeScene(initialScene);
        } else {
            OnSceneLoaded();
        }
    }

    protected void OnSceneLoaded() {
        if (loadingCanvas != null) {
            loadingCanvas.alpha = 0;
        }
    }

    public abstract void ChangeScene(string name);
    public abstract void ChangeScene(int id);

    protected void UpdateOnStateChangedEvents() {
        dicOnStateChangedEvents.Clear();
        foreach (SceneLoadingStateEvents e in onStateChangedEvents) {
            dicOnStateChangedEvents.Add(e.state, e.evnt);
        }
    }

    [System.Serializable]
    protected class SceneLoadingStateEvents {
        public SceneLoadingState state;
        public GameEvent evnt;
    }
}
