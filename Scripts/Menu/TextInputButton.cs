// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloTools.Unity.Menu
{
    public class TextInputButton : MonoBehaviour,
                                   IInputHandler
    {
        #region Public Fields

        public TextInput.Actions Action;

        #endregion

        #region Private Fields

        private TextInput _textInput;

        #endregion

        #region Private Properties

        private TextInput TextInput
        {
            get
            {
                if (!_textInput)
                {
                    _textInput = GetComponentInParent<TextInput>();
                }

                return _textInput;
            }
        }

        #endregion

        #region Events

        public void OnInputDown(InputEventData eventData) { }

        public void OnInputUp(InputEventData eventData)
        {
            if (TextInput)
            {
                TextInput.Invoke(Action.ToString(), 0);
            }
        }

        #endregion
    }
}
