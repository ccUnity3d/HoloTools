// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using System;
using UnityEngine;
using UnityEngine.UI;

namespace HoloTools.Unity.Menu
{
    public class NumInput : MonoBehaviour
    {
        #region Public Fields

        public enum Actions { Up, Down };

        public float Value;

        public float Step = 1;

        public float Min = 0;

        public float Max = 100;

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
            if (Text)
            {
                Text.text = Value.ToString();
            }
        }

        #endregion

        #region Utility Methods

        public void SetValue(float value)
        {
            if (value < Min)
            {
                value = Min;
            }
            else if (value > Max)
            {
                value = Max;
            }

            Value = value;
            Text.text = Math.Round(Value, 2).ToString();

            if (OnValueChanged != null)
            {
                OnValueChanged();
            }
        }

        #endregion

        #region Action Methods

        public void Up()
        {
            SetValue(Value + Step);
        }

        public void Down()
        {
            SetValue(Value - Step);
        }

        #endregion
    }
}
