// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

namespace HoloTools.Unity.Menu
{
    public class TogglePopup : MonoBehaviour,
                           IInputClickHandler
    {
        #region Public Fields

        [Tooltip("Link to popup menu. Required.")]
        public GameObject Popup;

        public bool clickSound = true;

        #endregion

        #region Private Fields

        private bool IsVisible = false;

        private AudioSource audioSrc;

        #endregion

        #region Main Methods

        private void Awake()
        {
            audioSrc = GetComponent<AudioSource>();

            if (Popup)
            {
                Popup.SetActive(false);
            }
        }

        #endregion

        #region Events

        public void OnInputClicked(InputClickedEventData eventData)
        {
            Toggle();

            if (clickSound && audioSrc)
            {
                audioSrc.Play();
            }
        }

        #endregion

        #region Utility Methods

        public void Toggle()
        {
            if (Popup && !IsVisible)
            {
                Popup.SetActive(true);
                IsVisible = true;
            }
            else if (Popup && IsVisible)
            {
                Popup.SetActive(false);
                IsVisible = false;
            }
        }

        #endregion
    }
}
