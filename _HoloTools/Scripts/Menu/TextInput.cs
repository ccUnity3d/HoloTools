// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using System;
using UnityEngine;
using UnityEngine.UI;

namespace HoloTools.Unity.Menu
{
    public class TextInput : MonoBehaviour
    {
        #region Public Fields

        public enum Actions { Up, Down };

        public int Index;

        public string[] Values;

        public Action OnValueChanged;

        #endregion

        #region Private Fields

        private Text _text;

        #endregion

        #region Private Properties

        private Text Text
        {
            get
            {
                if (!_text)
                {
                    _text = transform.Find("Text").GetComponentInChildren<Text>();
                }

                return _text;
            }
        }

        #endregion

        #region Main Methods

        private void Awake()
        {
            if (Text && Values.Length > 0)
            {
                Text.text = Values[Index].ToString();
            }
        }

        #endregion

        #region Utility Methods

        public void SetValue(int index)
        {
            if (index < 0 || index >= Values.Length)
            {
                return;
            }

            Index = index;
            Text.text = Values[Index];

            if (OnValueChanged != null)
            {
                OnValueChanged();
            }
        }

        #endregion

        #region Action Methods

        public void Up()
        {
            SetValue(Index + 1);
        }

        public void Down()
        {
            SetValue(Index - 1);
        }

        #endregion
    }
}
