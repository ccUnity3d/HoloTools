// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloTools.Unity.Menu
{
    public class NumInputButton : MonoBehaviour,
                                  IInputHandler
    {
        #region Public Fields

        public NumInput.Actions Action;

        #endregion

        #region Private Fields

        private NumInput _numInput;

        #endregion

        #region Private Properties

        private NumInput NumInput
        {
            get
            {
                if (!_numInput)
                {
                    _numInput = GetComponentInParent<NumInput>();
                }

                return _numInput;
            }
        }

        #endregion

        #region Events

        public void OnInputDown(InputEventData eventData) { }

        public void OnInputUp(InputEventData eventData)
        {
            if (NumInput)
            {
                NumInput.Invoke(Action.ToString(), 0);
            }
        }

        #endregion
    }
}
