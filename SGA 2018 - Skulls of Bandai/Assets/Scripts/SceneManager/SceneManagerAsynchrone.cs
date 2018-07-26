using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerAsynchrone : SceneManagerBase {

    [SerializeField] private bool isDebuging = false;
    [SerializeField] private CanvasGroup loadingCanvas = null;
    [SerializeField] private Image loadingProgressBar = null;
    [SerializeField] private GameEvent sceneLoadStartedEvent;
    [SerializeField] private GameEvent sceneLoadEndedEvent;
    [SerializeField] private string firstSceneName;
    [SerializeField] private float fadeSpeed = 1;

    private int sceneLoaded = NULL_SCENE_ID;

    private const float CANVAS_ALPHA_MIN = 0;
    private const float CANVAS_ALPHA_MAX = 1;

    private const int NULL_SCENE_ID = -1;

    // Use this for initialization
    void Start() {
        isLoading = false;
        if (!isDebuging) {
            ChangeScene(SceneUtility.GetBuildIndexByScenePath(firstSceneName));
        }
    }

    private IEnumerator FadeInStartLoadingScene(int sceneId) {
        isLoading = true;
        sceneLoadStartedEvent.Fire(new GameEventMessage(this));

        if (loadingCanvas != null) {
            while (loadingCanvas.alpha < CANVAS_ALPHA_MAX) {
                loadingCanvas.alpha += fadeSpeed * Time.deltaTime;
                if (loadingCanvas.alpha > CANVAS_ALPHA_MAX) {
                    loadingCanvas.alpha = CANVAS_ALPHA_MAX;
                }
                yield return null;
            }
        }

        if (sceneLoaded != NULL_SCENE_ID) {
            yield return SceneManager.UnloadSceneAsync(sceneLoaded);
        }
        sceneLoaded = sceneId;

        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(sceneId, LoadSceneMode.Additive);
        while (!sceneLoading.isDone) {
            if (loadingProgressBar != null) {
                loadingProgressBar.fillAmount = sceneLoading.progress;
            }
            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneId));
        StartCoroutine(FadeOutEndLoadingScene());
    }

    private IEnumerator FadeOutEndLoadingScene() {
        if (loadingCanvas != null) {
            while (loadingCanvas.alpha > CANVAS_ALPHA_MIN) {
                loadingCanvas.alpha -= fadeSpeed * Time.deltaTime;
                if (loadingCanvas.alpha < CANVAS_ALPHA_MIN)
                    loadingCanvas.alpha = CANVAS_ALPHA_MIN;
                yield return null;
            }
        }

        if (loadingProgressBar != null) {
            loadingProgressBar.fillAmount = 0;
        }
        sceneLoadEndedEvent.Fire(new GameEventMessage(this));
        isLoading = false;
    }

    public override void ChangeScene(string name) {
        ChangeScene(SceneUtility.GetBuildIndexByScenePath(name));
    }

    public override void ChangeScene(int sceneId) {
        StartCoroutine(FadeInStartLoadingScene(sceneId));
    }
}
