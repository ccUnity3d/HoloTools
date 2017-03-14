// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloTools.Unity.Input;

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

        public enum Actions { None, Move, Visible }

        #endregion

        #region Private Fields

        private HandDraggable handDraggable;

        #endregion

        #region Main Methods

        private void Awake()
        {
            if (Target)
            {
                handDraggable = Target.GetComponent<HandDraggable>();
            }
        }

        #endregion

        #region Actions Methods

        public void None() { }

        public void Move()
        {
            if (handDraggable)
            {
                handDraggable.IsEnabled = !handDraggable.IsEnabled;
            }
        }

        public void Visible()
        {
            Target.gameObject.SetActive(!Target.gameObject.activeSelf);
        }

        #endregion
    }
}
