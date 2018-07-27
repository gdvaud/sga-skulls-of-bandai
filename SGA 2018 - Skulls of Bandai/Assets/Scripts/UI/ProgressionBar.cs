using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionBar : MonoBehaviour {

    [SerializeField] private RectTransform bob;
    [SerializeField] private RectTransform car;
    [SerializeField] private int minPos = 0;
    [SerializeField] private int maxPos = 1920;

    public void OnItemRepairedChanged(GameEventMessage msg) {
        Vector2Int values = (Vector2Int)msg.value;
        float progression = ((float)values.x) / values.y;

        Vector2 pos = bob.anchoredPosition;
        pos.x = (maxPos - minPos) * progression;
        bob.anchoredPosition = pos;
    }

    public void OnTimerValueChanged(GameEventMessage msg) {
        Vector2 values = (Vector2)msg.value;
        float progression = values.x / values.y;

        Vector2 pos = car.anchoredPosition;
        pos.x = (maxPos - minPos) * progression;
        car.anchoredPosition = pos;
    }
}
