// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using System;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System.Collections.Generic;

namespace HoloTools.Unity.Menu
{
    /// <summary>
    /// ImageButton - Standart button handler, work in pair with MenuActions script
    /// </summary>
    public class ImageButton : MonoBehaviour,
                               IInputHandler
    {
        #region Public Fields

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

        #endregion

        #region Private Fields

        MenuActions _menuActions;
        Input.HandDraggable[] _draggable;
        List<HandDraggableState> _draggableStates;

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
