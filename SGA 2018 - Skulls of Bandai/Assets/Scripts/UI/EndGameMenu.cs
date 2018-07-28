using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameMenu : MonoBehaviour {

    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;
    private GameManager gm;

	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>();
        if (gm.nbItem == 0) {
            win.SetActive(true);
            lose.SetActive(false);
        } else {
            win.SetActive(false);
            lose.SetActive(true);
        }
    }
}
