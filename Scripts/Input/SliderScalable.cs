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

        public float scaleIncrement = 0.001f;

        public Transform Popup;

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

                menuSliderHandler.ValueUpdated += OnValueUpdate;
            }

            defaultScale = transform.localScale;
        }

        private void OnValueUpdate()
        {
            if (Slider && menuSliderHandler)
            {
                transform.localScale = new Vector3(
                    transform.localScale.x + scaleIncrement * menuSliderHandler.Direction,
                    transform.localScale.y + scaleIncrement * menuSliderHandler.Direction,
                    transform.localScale.z + scaleIncrement * menuSliderHandler.Direction
                    );

                if (menuSliderHandler.Value == 0)
                {
                    transform.localScale = defaultScale;
                }

                if (Popup)
                {
                    Vector3 newPos = Popup.position;
                    newPos.z = newPos.z + ((scaleIncrement * -menuSliderHandler.Direction));

                    Popup.position = newPos;
                }
            }
        }

        #endregion
    }
}
