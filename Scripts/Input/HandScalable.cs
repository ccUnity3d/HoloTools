// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace HoloTools.Unity.Input
{
    public class HandScalable : MonoBehaviour,
        INavigationHandler
    {
        #region Public Fields

        public bool IsEnabled = true;

        public float sensitivity = 10.0f;

        #endregion

        #region Private Fields

        private float scaleFactor;

        #endregion

        #region Events

        public void OnNavigationStarted(NavigationEventData eventData) { }

        public void OnNavigationUpdated(NavigationEventData eventData)
        {
            if (IsEnabled)
            {
                scaleFactor = eventData.CumulativeDelta.x * sensitivity;
                
                transform.localScale = new Vector3((transform.localScale.x + (-1 * scaleFactor)),
                    (transform.localScale.y + (-1 * scaleFactor)),
                    (transform.localScale.z + (-1 * scaleFactor)));

                //transform.Rotate(new Vector3(0, -1 * scaleFactor, 0));
            }
        }

        public void OnNavigationCompleted(NavigationEventData eventData) { }

        public void OnNavigationCanceled(NavigationEventData eventData) { }

        #endregion
    }
}
