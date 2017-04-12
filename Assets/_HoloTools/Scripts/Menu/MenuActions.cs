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

        public enum Actions { None, Move, Rotate, Scale, Visible, OpenMenu, CloseMenu, ChangeColor, AboutUs, Settings }

        #endregion

        #region Private Fields

        private HandDraggable _handDraggable;
        private HandRotatable _handRotatable;
        private HandScalable _handScalable;

        private ImageButton _moveButton;
        private ImageButton _rotateButton;

        private MenuWindow _menuWindow;

        #endregion

        #region Private Properties

        private MenuWindow MenuWindow
        {
            get
            {
                if (!_menuWindow)
                {
                    _menuWindow = GetComponent<MenuWindow>();
                }

                return _menuWindow;
            }
        }

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

        private ImageButton MoveButton
        {
            get
            {
                if (!_moveButton)
                {
                    _moveButton = FindButtonWithAction(Actions.Move);
                }

                return _moveButton;
            }
        }

        private ImageButton RotateButton
        {
            get
            {
                if (!_rotateButton)
                {
                    _rotateButton = FindButtonWithAction(Actions.Rotate);
                }

                return _rotateButton;
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
                var newVal = !HandDraggable.IsEnabled;

                // Set button state manually
                if (MoveButton)
                {
                    MoveButton.CanActive = true;
                    MoveButton.SetState(newVal);
                }

                HandDraggable.IsEnabled = newVal;
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
                var newVal = !HandRotatable.IsEnabled;

                // Set button state manually
                if (RotateButton)
                {
                    RotateButton.CanActive = true;
                    RotateButton.SetState(newVal);
                }

                HandRotatable.IsEnabled = newVal;
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
            MenuWindow.Open();
        }

        public void CloseMenu()
        {
            MenuWindow.Close();
        }

        public void ChangeColor()
        {
            // just for test
            Color[] colorChoices = new Color[] { Color.green, Color.red, Color.yellow, Color.magenta, Color.gray };

            var meshRend = Target.GetComponent<MeshRenderer>();

            var tempMat = meshRend.material;
            tempMat.color = colorChoices[Random.Range(0, (colorChoices.Length))];
            meshRend.material = tempMat;
        }

        public void AboutUs()
        {
            var aboutUs = MenuWindow.GetChild("AboutUs");

            if (aboutUs != null)
            {
                aboutUs.Open();
            }
        }

        public void Settings()
        {
            var settings = MenuWindow.GetChild("Settings");

            if (settings != null)
            {
                settings.Open();
            }
        }

        #endregion

        #region Utility Methods

        public void ClickSound()
        {
            MenuWindow.ClickSound();
        }

        private ImageButton FindButtonWithAction(Actions action)
        {
            var buttons = GetComponentsInChildren<ImageButton>();

            foreach (var button in buttons)
            {
                if (button.Action == action)
                {
                    return button;
                }
            }

            return null;
        }

        #endregion
    }
}
