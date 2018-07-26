using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour {

    [SerializeField] private Canvas pauseMenu;

	// Use this for initialization
	void Start () {
        pauseMenu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Pause") > 0) {
            ShowPauseMenu();
        }
	}

    public void ShowPauseMenu() {
        pauseMenu.enabled = true;
    }

    public void HidePauseMenu() {
        pauseMenu.enabled = false;
    }
}
