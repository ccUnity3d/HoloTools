// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

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

        public bool Checked = true;

        [Tooltip("Checkbox dot. Required.")]
        public GameObject Dot;

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

            if (Dot)
            {
                Dot.SetActive(Checked);
            }

            if (audioSrc)
            {
                audioSrc.Play();
            }
        }

        #endregion
    }
}
