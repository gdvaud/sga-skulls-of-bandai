using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMenu : MonoBehaviour {

    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;
    private GameManager gm;

    // Use this for initialization
    void Start() {
        gm = FindObjectOfType<GameManager>();
        lose.SetActive(false);
        win.SetActive(false);

        if (gm.nbItem == 0) {
            win.SetActive(true);
        } else {
            lose.SetActive(true);
        }
    }
}
