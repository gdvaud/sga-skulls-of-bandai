using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "InputControllerScheme")]
public class InputControllerScheme : ScriptableObject {

    [SerializeField] public string name;
    [SerializeField] public KeyCode interactionKey;
    [SerializeField] public KeyCode pauseKey;
}
