// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using System;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System.Collections.Generic;
using UnityEngine.UI;

namespace HoloTools.Unity.Menu
{
    /// <summary>
    /// ImageButton - Standart button handler, work in pair with MenuActions script
    /// </summary>
    public class ImageButton : MonoBehaviour,
                               IInputHandler
    {
        #region Public Fields

        public bool Active = false;

        /// <summary>
        /// Additional OnClick handler
        /// </summary>
        public Action OnClick;

        /// <summary>
        /// Action for this Button
        /// </summary>
        public MenuActions.Actions Action = MenuActions.Actions.None;

        /// <summary>
        /// Click sound onClick
        /// </summary>
        public bool ClickSound = true;

        /// <summary>
        /// OnActive button Color
        /// </summary>
        public bool CanActive = false;

        /// <summary>
        /// OnActive button Color
        /// </summary>
        public Color OnActive;

        #endregion

        #region Private Fields

        private MenuActions _menuActions;
        private Input.HandDraggable[] _draggable;
        private List<HandDraggableState> _draggableStates;

        private Image _image;
        private Color _normalColor;
        private ImageButton[] _buttons;

        protected bool fromCheckbox = false;

        #endregion

        #region Private Properties

        private MenuActions MenuActions
        {
            get
            {
                if (!_menuActions)
                {
                    _menuActions = GetComponentInParent<MenuActions>();
                }

                return _menuActions;
            }
        }

        private Input.HandDraggable[] Draggable
        {
            get
            {
                if (_draggable == null || _draggable.Length == 0)
                {
                    _draggable = FindObjectsOfType<Input.HandDraggable>();
                }

                return _draggable;
            }
        }

        private List<HandDraggableState> DraggableStates
        {
            get
            {
                if (_draggableStates == null)
                {
                    _draggableStates = new List<HandDraggableState>();
                }

                return _draggableStates;
            }
        }

        private Image Image
        {
            get
            {
                if (!_image)
                {
                    _image = GetComponent<Image>();
                }

                return _image;
            }
        }

        public ImageButton[] ButtonStates
        {
            get
            {
                if (_buttons == null 
                    || _buttons.Length == 0)
                {
                    _buttons = FindObjectsOfType<ImageButton>();
                }

                return _buttons;
            }
        }

        #endregion

        #region Main Methods

        private void Awake()
        {
            _normalColor = Image.color;
        }

        #endregion

        #region Events

        public void OnInputDown(InputEventData eventData)
        {
            Debug.Log("Down");

            DisableDraggind();
        }

        public void OnInputUp(InputEventData eventData)
        {
            Debug.Log("Up");

            Active = !Active;

            SetState(Active);

            EnableDraggind();

            SendMessageUpwards(Action.ToString());

            if (ClickSound && MenuActions)
            {
                MenuActions.ClickSound();
            }

            if (OnClick != null)
            {
                OnClick();
            }
        }

        #endregion

        #region Utility Methods

        /// <summary>
        /// Disable Draggind all objects in scene
        /// </summary>
        private void DisableDraggind()
        {
            DraggableStates.Clear();

            for (int i = 0; i < Draggable.Length; i++)
            {
                DraggableStates.Add(new HandDraggableState(
                    ref Draggable[i],
                    Draggable[i].IsEnabled));

                Draggable[i].IsEnabled = false;
            }
        }

        /// <summary>
        /// Enable Dragging objects what was enabled before
        /// </summary>
        private void EnableDraggind()
        {
            if (DraggableStates != null)
            {
                foreach (var draggableState in DraggableStates)
                {
                    draggableState.item.IsEnabled = draggableState.IsEnable;
                }
            }
        }

        /// <summary>
        /// Set button state style
        /// </summary>
        public void SetState(bool active)
        {
            if (CanActive 
                && !fromCheckbox)
            {
                // before continue set all Buttons state to normal
                DisableSelection();

                if (Image)
                {
                    Image.color = active ? OnActive : _normalColor;
                }
            }
        }

        /// <summary>
        /// Disable Selection style from all buttons
        /// </summary>
        private void DisableSelection()
        {
            foreach (var state in ButtonStates)
            {
                if (state.Image 
                    && state.CanActive)
                {
                    state.Image.color = _normalColor;
                }
            }
        }

        #endregion

        #region Nested Classes

        private class HandDraggableState
        {
            public Input.HandDraggable item;
            public bool IsEnable = false;

            public HandDraggableState(ref Input.HandDraggable item, bool IsEnable)
            {
                this.item = item;
                this.IsEnable = IsEnable;
            }
        }

        #endregion
    }
}
