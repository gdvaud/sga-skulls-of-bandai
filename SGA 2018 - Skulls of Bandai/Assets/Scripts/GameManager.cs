using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private SceneManagerBase sceneManager;

    public enum GameState {
        IN_MENU,
        IN_GAME,
        PAUSE,
        END_GAME
    }

    private GameState gameState;
    private bool isLoading;

	// Use this for initialization
	void Start () {
        sceneManager = FindObjectOfType<SceneManagerBase>();
        gameState = GameState.IN_MENU;
	}
}
