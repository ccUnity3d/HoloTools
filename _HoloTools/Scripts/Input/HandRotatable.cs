// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloTools.Unity.Input
{
    /// <summary>
    /// HandRotatable component - for object rotation
    /// </summary>
    public class HandRotatable : MonoBehaviour,
        INavigationHandler
    {
        #region Public Fields

        public bool IsEnabled = true;

        public float rotationSensitivity = 10.0f;

        #endregion

        #region Private Fields

        private float rotationFactor;

        #endregion

        #region Events

        public void OnNavigationStarted(NavigationEventData eventData) { }

        public void OnNavigationUpdated(NavigationEventData eventData)
        {
            if (IsEnabled)
            {
                rotationFactor = eventData.CumulativeDelta.x * rotationSensitivity;
                transform.Rotate(new Vector3(0, -1 * rotationFactor, 0));
            }
        }

        public void OnNavigationCompleted(NavigationEventData eventData) { }

        public void OnNavigationCanceled(NavigationEventData eventData) { }

        #endregion
    }
}
