﻿namespace BusinessConversation.CHN.Hotel
{
    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    public class Popup : MonoBehaviour
    {
        public Button btn_backgroundPannel;
        public Button btn_close;

        protected bool unhandledAreaSwitcher = false;

        protected void Awake()
        {
            Initialize();
        }

        protected void Initialize()
        {
            SetListeners();
        }

        protected void SetListeners()
        {
            btn_backgroundPannel.onClick.AddListener(() => OnCloseButtonClicked());
            btn_close.onClick.AddListener(() => OnBackgroundButtonClicked());
        }

        protected void SetSortingLayerToHighest()
        {
            int highest = 0;
            Canvas[] canvasArray = GetComponents<Canvas>();
            foreach (Canvas canvas in canvasArray)
            {
                if (canvas.sortingOrder > highest)
                {
                    highest = canvas.sortingOrder;
                }
            }

            GetComponent<Canvas>().sortingOrder = highest + 1;
        }

        protected void OnCloseButtonClicked()
        {
            this.gameObject.SetActive(false);
        }

        protected void OnBackgroundButtonClicked()
        {
            if (unhandledAreaSwitcher)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
