// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using System;
using UnityEngine;
using UnityEngine.UI;

namespace HoloTools.Unity.Menu
{
    public class Toast : MonoBehaviour
    {
        #region Public Fields

        public enum ToastDuration { Short, Long }
        
        /// <summary>
        /// OnEnable Toast Action
        ///  </summary>
        public Action onEnable;

        /// <summary>
        /// OnDisable Toast Action
        ///  </summary>
        public Action onDisable;

        #endregion

        #region Private Fields

        private bool _active = false;

        private Text _text;

        #endregion

        #region Public Properties

        public bool Active
        {
            get
            {
                return _active;
            }
            private set
            {
                _active = value;
            }
        }

        #endregion

        #region Private Properties

        private Text Text
        {
            get
            {
                if (!_text)
                {
                    _text = (Text)GetComponentInChildren(typeof(Text), true);
                }

                return _text;
            }
        }

        #endregion

        #region Main Methods

        public void SetText(string text)
        {
            Text.text = text;
        }

        public void Show(ToastDuration duration)
        {
            gameObject.SetActive(true);

            switch (duration)
            {
                case ToastDuration.Short:
                    Invoke("Hide", 1.5f);
                    break;

                case ToastDuration.Long:
                    Invoke("Hide", 3f);
                    break;
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        #endregion

        #region Events

        public void OnEnable()
        {
            Active = true;

            if (onEnable != null)
            {
                onEnable();
            }
        }

        public void OnDisable()
        {
            Active = false;

            if (onDisable != null)
            {
                onDisable();
            }
        }

        #endregion
    }
}
