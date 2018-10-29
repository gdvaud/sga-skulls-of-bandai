using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerAsynchrone : SceneManagerBase {

    private const float CANVAS_ALPHA_MIN = 0;
    private const float CANVAS_ALPHA_MAX = 1;
    private const int NULL_SCENE_ID = -1;

    [Header("Async parameters")]
    [SerializeField] private Image loadingProgressBar = null;
    [SerializeField] private float fadeSpeed = 1;

    private int sceneLoaded = NULL_SCENE_ID;

    private IEnumerator LoadScene(int sceneId) {
        state = SceneLoadingState.FADE_IN;
        if (loadingCanvas != null) {
            while (loadingCanvas.alpha < CANVAS_ALPHA_MAX) {
                loadingCanvas.alpha += fadeSpeed * Time.deltaTime;
                if (loadingCanvas.alpha > CANVAS_ALPHA_MAX) {
                    loadingCanvas.alpha = CANVAS_ALPHA_MAX;
                }
                yield return null;
            }
        }

        state = SceneLoadingState.UNLOADING;
        if (sceneLoaded != NULL_SCENE_ID) {
            yield return SceneManager.UnloadSceneAsync(sceneLoaded);
        }
        sceneLoaded = sceneId;

        state = SceneLoadingState.LOADING;
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(sceneId, LoadSceneMode.Additive);
        while (!sceneLoading.isDone) {
            if (loadingProgressBar != null) {
                loadingProgressBar.fillAmount = sceneLoading.progress;
            }
            yield return null;
        }

        state = SceneLoadingState.FADE_OUT;
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneId));
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

        state = SceneLoadingState.LOADED;
    }

    public override void ChangeScene(string name) {
        ChangeScene(SceneUtility.GetBuildIndexByScenePath(name));
    }

    public override void ChangeScene(int sceneId) {
        if (state == SceneLoadingState.LOADED) {
            StartCoroutine(LoadScene(sceneId));
        }
    }

}
