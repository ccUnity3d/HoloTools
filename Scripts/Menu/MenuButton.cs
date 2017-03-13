// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloTools.Unity.Menu
{
    /// <summary>
    /// MenuButton - button handler
    /// </summary>
    public class MenuButton : MonoBehaviour,
                              IInputClickHandler
    {
        #region Public Fields

        [Tooltip("MenuActions link. Optional.")]
        public MenuActions menuActions;

        public MenuActions.Actions action = MenuActions.Actions.None;

        #endregion

        #region Private Fields

        private AudioSource audioSrc;

        #endregion

        #region Main Methods 

        private void Awake()
        {
            audioSrc = GetComponent<AudioSource>();

            if (!menuActions)
            {
                menuActions = transform.parent.gameObject.GetComponent<MenuActions>();
            }
        }

        #endregion

        #region Events

        public void OnInputClicked(InputClickedEventData eventData)
        {
            SendMessageUpwards(action.ToString());

            if (audioSrc)
            {
                audioSrc.Play();
            }
        }

        #endregion
    }
}
