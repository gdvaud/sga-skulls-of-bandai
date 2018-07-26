using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    private SceneManagerBase sceneManagerInGame;

    // Use this for initialization
    void Start() {
        sceneManagerInGame = FindObjectOfType<SceneManagerBase>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnChangeScene(string sceneName) {
        sceneManagerInGame.ChangeScene(sceneName);
    }

    public void OnChangeScene(int sceneID) {
        sceneManagerInGame.ChangeScene(sceneID);
    }

    public void OnQuitGame() {
        Application.Quit();
    }
}
