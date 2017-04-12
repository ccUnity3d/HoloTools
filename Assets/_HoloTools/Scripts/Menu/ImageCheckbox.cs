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

        private Image _iconImage;

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

        private Image IconImage
        {
            get
            {
                if (!_iconImage)
                {
                    _iconImage = Icon.GetComponent<Image>();
                }

                return _iconImage;
            }
        }

        #endregion

        #region Main Methods

        private void Awake()
        {
            _unchecked = IconImage.sprite;

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

            fromCheckbox = true;
            base.OnInputUp(eventData);
            fromCheckbox = false;
        }

        #endregion

        #region Utility Methods

        private void SetChecked(bool active)
        {
            IconImage.sprite = active ? _checked : _unchecked;
        }

        #endregion
    }
}
