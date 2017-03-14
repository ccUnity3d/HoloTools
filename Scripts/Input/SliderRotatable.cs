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

        private MenuSlider menuSlider;

        private Quaternion defaultRotation;

        #endregion

        #region Main Methods

        private void Awake()
        {
            if (Slider)
            {
                menuSlider = Slider.GetComponent<MenuSlider>();

                menuSlider.OnValueChanged += OnValueChanged;
            }

            defaultRotation = transform.rotation;
        }

        private void OnValueChanged()
        {
            if (Slider && menuSlider)
            {
                transform.Rotate(new Vector3(0, 3.6f * menuSlider.Direction, 0));

                if (menuSlider.Value == 0)
                {
                    transform.rotation = defaultRotation;
                }
            }
        }

        #endregion
    }
}
