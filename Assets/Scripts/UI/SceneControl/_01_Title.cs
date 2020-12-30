﻿namespace BusinessConversation.CHN.Hotel
{
    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    public class _01_Title : MonoBehaviour
    {
        public Button btn_start;
        public Button btn_quit;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            Screen.NotifySceneLoaded();
            SetListeners();
        }

        private void SetListeners()
        {
            btn_start.onClick.AddListener(() => OnStartButtonClicked());
            btn_quit.onClick.AddListener(() => OnQuitButtonClicked());
        }

        private void OnStartButtonClicked()
        {
            Screen.FadeOut(() =>
            {
                SceneLoader.LoadScene(SceneName._02_Menu);
            });
        }

        private void OnQuitButtonClicked()
        {
            // TODO : Show Popup
        }
    }
}
