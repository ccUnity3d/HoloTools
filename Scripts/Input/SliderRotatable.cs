// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloTools.Unity.Menu;

namespace HoloTools.Unity.Input
{
    /// <summary>
    /// SliderRotatable component - proccess object rotation with slider
    /// </summary>
    public class SliderRotatable : MonoBehaviour
    {
        #region Public Fields

        [Tooltip("Slider gameobject. Required.")]
        public GameObject Slider;

        #endregion

        #region Private Fields

        private MenuSlider menuSliderHandler;

        private Quaternion defaultRotation;

        #endregion

        #region Main Methods

        private void Awake()
        {
            if (Slider)
            {
                menuSliderHandler = Slider.GetComponent<MenuSlider>();

                menuSliderHandler.ValueUpdated += OnValueUpdate;
            }

            defaultRotation = transform.rotation;
        }

        private void OnValueUpdate()
        {
            if (Slider && menuSliderHandler)
            {
                transform.Rotate(new Vector3(0, 3.6f * menuSliderHandler.Direction, 0));

                if (menuSliderHandler.Value == 0)
                {
                    transform.rotation = defaultRotation;
                }
            }
        }

        #endregion
    }
}
