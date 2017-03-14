// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using System;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloTools.Unity.Menu
{
    /// <summary>
    /// MenuCheckbox - checkbox handler
    /// </summary>
    public class MenuCheckbox : MonoBehaviour, 
                                IInputClickHandler
    {
        #region Public Fields

        public Action OnValueChanged;

        public bool Checked = true;

        [Tooltip("Checkbox dot. Required.")]
        public GameObject Dot;

        public MenuActions.Actions action = MenuActions.Actions.None;

        public bool clickSound = true;

        #endregion

        #region Private Fields

        private AudioSource audioSrc;

        #endregion

        #region Main Methods

        private void Awake()
        {
            if (Dot)
            {
                Dot.SetActive(Checked);
            }

            audioSrc = GetComponent<AudioSource>();
        }

        #endregion

        #region Events

        public void OnInputClicked(InputClickedEventData eventData)
        {
            Checked = !Checked;

            SendMessageUpwards(action.ToString());

            if (OnValueChanged != null)
            {
                OnValueChanged();
            }

            if (Dot)
            {
                Dot.SetActive(Checked);
            }

            if (clickSound && audioSrc)
            {
                audioSrc.Play();
            }
        }

        #endregion
    }
}
