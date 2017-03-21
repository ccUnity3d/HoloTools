// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.UI;

namespace HoloTools.Unity.Menu
{
    /// <summary>
    /// ImageCheckbox - Standart checkbox handler, work in pair with MenuActions script
    /// </summary>
    public class ImageCheckbox : ImageButton,
                                 IInputHandler
    {
        #region Public Fields
        
        public Sprite _checked;

        public bool Checked = false;

        #endregion

        #region Private Fields

        private Sprite _unchecked;

        private Image _image;

        private Transform _icon;

        #endregion

        #region Private Properties

        private Transform Icon
        {
            get
            {
                if (!_icon)
                {
                    _icon = transform.Find("icon");
                }

                return _icon;
            }
        }

        private Image Image
        {
            get
            {
                if (!_image)
                {
                    _image = Icon.GetComponent<Image>();
                }

                return _image;
            }
        }

        #endregion

        #region Main Methods

        private void Awake()
        {
            _unchecked = Image.sprite;

            SetChecked(Checked);
        }

        #endregion

        #region Events

        public new void OnInputDown(InputEventData eventData)
        {
            base.OnInputDown(eventData);
        }

        public new void OnInputUp(InputEventData eventData)
        {
            Debug.Log("here");

            Checked = !Checked;
            SetChecked(Checked);

            base.OnInputUp(eventData);
        }

        #endregion

        #region Utility Methods

        private void SetChecked(bool active)
        {
            Image.sprite = active ? _checked : _unchecked;
        }

        #endregion
    }
}
