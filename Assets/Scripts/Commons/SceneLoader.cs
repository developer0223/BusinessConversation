﻿namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System.Collections;

    // Unity
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    // Project
    // Alias

    public class SceneLoader : MonoBehaviour
    {
        public Slider progressBar;
        public Text progressText;

        private static string nextSceneName = "";
        private static readonly string LoadingSceneName = SceneName._99_Loading;

        private float loadingPrecent = 0.0f;

        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public static void LoadSceneAsync(string sceneName)
        {
            nextSceneName = sceneName;
            SceneManager.LoadScene(LoadingSceneName);
        }

        private void Start()
        {
            StartCoroutine(LoadScene());
        }

        private IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(3.0f);

            AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneName);
            operation.allowSceneActivation = false;

            float timer = 0.0f;
            while (!operation.isDone)
            {
                timer += Time.deltaTime;

                if (operation.progress < 0.9f)
                {
                    loadingPrecent = Mathf.Lerp(loadingPrecent, operation.progress, timer);
                    progressBar.value = loadingPrecent;
                    progressText.text = $"{loadingPrecent * 100}%";
                    if (loadingPrecent >= operation.progress)
                    {
                        timer = 0.0f;
                    }
                }
                else
                {
                    loadingPrecent = Mathf.Lerp(loadingPrecent, 1.0f, timer);
                    progressBar.value = loadingPrecent;
                    progressText.text = $"{loadingPrecent * 100}%";
                    if (loadingPrecent == 1.0f)
                    {
                        operation.allowSceneActivation = true;
                        yield break;
                    }
                }
            }
        }
    }
}