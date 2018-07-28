using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematiqueMenu : MonoBehaviour {

    [SerializeField] private GameObject clean;
    [SerializeField] private GameObject broken;
    [SerializeField] private GameObject disco;
    private float startTime;
    [SerializeField] private float cleanEnd;
    [SerializeField] private float discoEnd;
    [SerializeField] private float brokenEnd;
    private SceneManagerBase sceneManagerInGame;

    private void Start() {
        startTime = Time.time;
        sceneManagerInGame = FindObjectOfType<SceneManagerBase>();
    }

    private void Update() {
        clean.SetActive(false);
        broken.SetActive(false);
        disco.SetActive(false);
        if (Time.time - startTime > brokenEnd) {
            sceneManagerInGame.ChangeScene("Main");
        } else if (Time.time - startTime > discoEnd) {
            broken.SetActive(true);
        } else if (Time.time - startTime > cleanEnd) {
            disco.SetActive(true);
        } else {
            clean.SetActive(true);
        }
    }
}
