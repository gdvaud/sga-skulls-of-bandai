using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Code below insipred from : https://unity3d.com/fr/learn/tutorials/projects/survival-shooter/player-health

public class JaugeBar : MonoBehaviour {

    public float minValue = 0f;
    public float maxValue = 1f;
    [Range(0, 1)]
    public float currentValue;
    public Image jaugeInterieur;

    // Use this for initialization
    void Start () {
        // Set the initial health of the object.
        jaugeInterieur.fillAmount = .5f;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        // Increase current Repair state
        jaugeInterieur.fillAmount = currentValue;
    }
}