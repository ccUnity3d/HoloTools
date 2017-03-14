// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloTools.Unity.Menu;

namespace HoloTools.Unity.Input
{
    /// <summary>
    /// SliderScalable component - proccess object scaling with slider
    /// </summary>
    public class SliderScalable : MonoBehaviour
    {
        #region Public Fields

        [Tooltip("Slider gameobject. Required.")]
        public GameObject Slider;

        public float scaleIncrement = 1f;

        #endregion

        #region Private Fields

        private MenuSlider menuSliderHandler;

        private Vector3 defaultScale;

        #endregion

        #region Main Methods

        private void Awake()
        {
            if (Slider)
            {
                menuSliderHandler = Slider.GetComponent<MenuSlider>();

                menuSliderHandler.OnValueChanged += OnValueChanged;
            }

            defaultScale = transform.localScale;
        }

        private void OnValueChanged()
        {
            if (Slider && menuSliderHandler)
            {
                float scaleIncNew = scaleIncrement / 1000;

                transform.localScale = new Vector3(
                    transform.localScale.x + scaleIncNew * menuSliderHandler.Direction,
                    transform.localScale.y + scaleIncNew * menuSliderHandler.Direction,
                    transform.localScale.z + scaleIncNew * menuSliderHandler.Direction
                    );

                if (menuSliderHandler.Value == 0)
                {
                    transform.localScale = defaultScale;
                }
            }
        }

        #endregion
    }
}
