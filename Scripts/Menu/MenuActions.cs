// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloTools.Unity.Input;
using HoloTools.Unity.Other;

namespace HoloTools.Unity.Menu
{
    /// <summary>
    /// MenuActions - collection of Methods, which called from menu components
    /// </summary>
    public class MenuActions : MonoBehaviour
    {
        #region Public Fields

        [Tooltip("Target gameobject. Required.")]
        public Transform Target;

        public enum Actions { None, Move, Rotate, Scale, Visible, OpenMenu, CloseMenu }

        #endregion

        #region Private Fields

        private HandDraggable _handDraggable;
        private HandRotatable _handRotatable;
        private HandScalable _handScalable;

        private AudioSource _audioSrc;

        private HideSelf _container;

        private Transform _floatingButton;

        #endregion

        #region Private Properties

        private HandDraggable HandDraggable
        {
            get
            {
                if (Target && !_handDraggable)
                {
                    _handDraggable = Target.GetComponent<HandDraggable>();
                }

                return _handDraggable;
            }
        }

        private HandRotatable HandRotatable
        {
            get
            {
                if (Target && !_handRotatable)
                {
                    _handRotatable = Target.GetComponent<HandRotatable>();
                }

                return _handRotatable;
            }
        }

        private HandScalable HandScalable
        {
            get
            {
                if (Target && !_handScalable)
                {
                    _handScalable = Target.GetComponent<HandScalable>();
                }

                return _handScalable;
            }
        }

        private AudioSource AudioSrc
        {
            get
            {
                if (!_audioSrc)
                {
                    _audioSrc = GetComponent<AudioSource>();
                }

                return _audioSrc;
            }
        }

        private HideSelf Container
        {
            get
            {
                if (!_container)
                {
                    _container = GetComponentInChildren<HideSelf>();
                }

                return _container;
            }
        }

        private bool Active
        {
            get
            {
                return Container.Active;
            }
            set
            {
                Container.Active = value;
            }
        }

        private Transform FloatingButton
        {
            get
            {
                if (!_floatingButton)
                {
                    _floatingButton = transform.FindChild("FloatingButton");
                }

                return _floatingButton;
            }
        }

        #endregion

        #region Actions Methods

        public void None() { }

        public void Move()
        {
            if (HandRotatable)
            {
                HandRotatable.IsEnabled = false;
            }

            if (HandDraggable)
            {
                HandDraggable.IsEnabled = !HandDraggable.IsEnabled;
            }
        }

        public void Rotate()
        {
            if (HandDraggable)
            {
                HandDraggable.IsEnabled = false;
            }

            if (HandRotatable)
            {
                HandRotatable.IsEnabled = !HandRotatable.IsEnabled;
            }
        }

        public void Scale()
        {
            if (HandDraggable)
            {
                HandDraggable.IsEnabled = false;
            }

            if (HandRotatable)
            {
                HandRotatable.IsEnabled = false;
            }

            if (HandScalable)
            {
                HandScalable.IsEnabled = !HandScalable.IsEnabled;
            }
        }

        public void Visible()
        {
            Target.gameObject.SetActive(!Target.gameObject.activeSelf);
        }

        public void OpenMenu()
        {
            Active = true;

            FloatingButton.gameObject.SetActive(false);
        }

        public void CloseMenu()
        {
            Active = false;

            FloatingButton.gameObject.SetActive(true);
        }

        #endregion

        #region Utility Methods

        public void ClickSound()
        {
            if (AudioSrc)
            {
                AudioSrc.Play();
            }
        }

        #endregion
    }
}
