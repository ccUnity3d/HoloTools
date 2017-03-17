// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloTools.Unity.Menu
{
    /// <summary>
    /// MenuButtonState - button state handler, 
    /// Change button material for Hover and Active states
    /// </summary>
    public class MenuButtonState : MonoBehaviour,
                            IInputClickHandler,
                            IFocusable
    {
        #region Public Fields

        public bool IsActive = false;
        public bool IsFocus = false;

        public Material NormalState;
        public Material HoverState;
        public Material ActiveState;

        [Tooltip("Popup menu link. Optional.")]
        public GameObject Popup;

        [HideInInspector]
        public MeshRenderer meshRend;

        #endregion

        #region Private Fields

        private MenuButtonState[] buttonStates;

        #endregion

        #region Main Methods

        private void Awake()
        {
            meshRend = GetComponent<MeshRenderer>();

            if (Popup)
            {
                buttonStates = Popup.GetComponentsInChildren<MenuButtonState>();
            }
        }

        #endregion

        #region Events

        public void OnInputClicked(InputClickedEventData eventData)
        {
            IsActive = !IsActive;

            SetActive(IsActive);
        }

        public void OnFocusEnter()
        {
            IsFocus = true;
            SetFocus(IsFocus);
        }

        public void OnFocusExit()
        {
            IsFocus = false;
            SetFocus(IsFocus);
        }

        #endregion

        #region Utility Methods

        public void SetActive(bool active)
        {
            // before continue return all Buttons state to normal
            DisableSelection();

            if (meshRend && ActiveState && NormalState)
            {
                meshRend.sharedMaterial = active ? ActiveState : NormalState;
            }
        }

        public void SetFocus(bool active)
        {
            if (!IsActive && meshRend && HoverState && NormalState)
            {
                meshRend.sharedMaterial = active ? HoverState : NormalState;
            }
        }

        private void DisableSelection()
        {
            if (Popup)
            {
                foreach (MenuButtonState state in buttonStates)
                {
                    if (state.meshRend)
                    {
                        state.meshRend.sharedMaterial = state.NormalState;
                    }
                }
            }
        }

        #endregion
    }
}
