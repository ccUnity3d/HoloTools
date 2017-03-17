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

        #endregion

        #region Private Fields

        private MeshRenderer _meshRend;

        private MenuButtonState[] _buttonStates;

        #endregion

        #region Private Properties

        public MeshRenderer MeshRend
        {
            get
            {
                if (!_meshRend)
                {
                    _meshRend = GetComponent<MeshRenderer>();
                }

                return _meshRend;
            }
        }

        public MenuButtonState[] ButtonStates
        {
            get
            {
                if (_buttonStates == null || _buttonStates.Length == 0)
                {
                    _buttonStates = transform.parent.GetComponentsInChildren<MenuButtonState>();
                }

                return _buttonStates;
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
            SetFocus(true);
        }

        public void OnFocusExit()
        {
            SetFocus(false);
        }

        #endregion

        #region Utility Methods

        public void SetActive(bool active)
        {
            // before continue return all Buttons state to normal
            DisableSelection();

            if (MeshRend && ActiveState && NormalState)
            {
                MeshRend.sharedMaterial = active ? ActiveState : NormalState;
                IsActive = active;
            }
        }

        public void SetFocus(bool active)
        {
            if (!IsActive && MeshRend && HoverState && NormalState)
            {
                MeshRend.sharedMaterial = active ? HoverState : NormalState;
            }

            IsFocus = active;
        }

        private void DisableSelection()
        {
            foreach (MenuButtonState state in ButtonStates)
            {
                if (state.MeshRend)
                {
                    state.MeshRend.sharedMaterial = state.NormalState;
                    state.IsActive = false;
                }
            }
        }

        #endregion
    }
}
