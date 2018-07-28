using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour {

    [SerializeField] private List<Sprite> sprites;
    private int index = 0;
    [SerializeField] float timeBetweenFrames = 0.2f;
    [SerializeField] private Image image;
    private float lastFrameChange = 0;

	// Use this for initialization
	void Start () {
        index = 0;
        image.sprite = sprites[index];
        lastFrameChange = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (lastFrameChange + timeBetweenFrames < Time.time) {
            index++;
            if (index >= sprites.Count) {
                index = 0;
            }

            lastFrameChange = Time.time;
            image.sprite = sprites[index];
        }
	}
}
