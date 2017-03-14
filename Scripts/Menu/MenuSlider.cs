// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace HoloTools.Unity.Menu
{
    /// <summary>
    /// MenuCheckbox - slider handler
    /// </summary>
    public class MenuSlider : MonoBehaviour
    {
        #region Public Fields

        public bool IsEnabled = true;

        public enum SliderType { Horizontal, Vertical };

        public SliderType sliderType = SliderType.Horizontal;

        public float Value = 0;
        public int Direction = 1;

        public Transform Line;
        public Transform Toddler;

        public Action ValueUpdated;

        #endregion

        #region Private Fields

        private Vector3 defaultPos;

        private float minPos = 0;
        private float maxPos = 0;
        private float oldVal = 0;

        #endregion

        #region Main Methods

        void Awake()
        {
            minPos = Toddler.localPosition.x;
            maxPos = -minPos;

            defaultPos = Toddler.localPosition;
        }

        private void Update()
        {
            if (IsEnabled && Toddler)
            {
                Vector3 newPos = Toddler.localPosition;

                newPos.y = defaultPos.y;
                newPos.z = 0;

                if (newPos.x >= minPos && newPos.x <= maxPos)
                {
                    float curPos = newPos.x + Mathf.Abs(minPos);
                    float len = maxPos + Mathf.Abs(minPos);

                    float ValTemp = (float)Math.Round(curPos / len, 2) * 100;

                    if (ValTemp != oldVal)
                    {
                        Value = ValTemp;
                        Direction = Value > oldVal ? 1 : -1;
                        oldVal = Value;

                        if (ValueUpdated != null)
                        {
                            ValueUpdated();
                        }
                    }
                }
            }
        }

        #endregion
    }
}
