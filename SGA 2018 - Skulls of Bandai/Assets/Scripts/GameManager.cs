using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private int nbItem;
    [SerializeField] private float maxTimerDuration = 60f;
    private float timeSpent;
    private bool isGameEnded;
    private SceneManagerBase sceneManager;

    // Use this for initialization
    void Start() {
        sceneManager = GetComponent<SceneManagerBase>();
        timeSpent = 0f;
        isGameEnded = false;
    }

    private void Update() {
        timeSpent += Time.deltaTime;
        if (!isGameEnded && timeSpent > maxTimerDuration) {
            sceneManager.ChangeScene("EndGame");
            isGameEnded = true;
        }
    }

    public void OnItemSpawned(GameEventMessage msg) {
        nbItem ++;
    }

    public void OnItemRepaired(GameEventMessage msg) {
        nbItem--;
        if (nbItem == 0) {
            Debug.Log("Ended");
            sceneManager.ChangeScene("EndGame");
        }
    }
}
