// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloTools.Unity.Other
{
    /// <summary>
    /// ScaleOnHover component - position gameobject towards to camera
    /// </summary>
    public class ScaleOnHover : MonoBehaviour,
                            IFocusable
    {
        #region Public Fields

        public enum Mode { Bigger, Smaller };

        public Mode scale = Mode.Bigger;

        public float scaleModifier = 0.25f;

        #endregion

        #region Private Fields

        private Vector3 localScale;

        #endregion

        #region Events

        public void OnFocusEnter()
        {
            localScale = transform.localScale;

            float mod = (scale == Mode.Bigger 
                ? 1 + scaleModifier 
                : 1 - scaleModifier);

            transform.localScale = new Vector3(
                (transform.localScale.x * mod),
                (transform.localScale.y * mod),
                (transform.localScale.z * mod)
            );
        }

        public void OnFocusExit()
        {
            transform.localScale = localScale;
        }

        #endregion
    }
}
