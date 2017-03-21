// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloTools.Unity.Input
{
    public class HandScalable : MonoBehaviour,
                                IManipulationHandler
    {
        #region Public Fields

        public bool IsEnabled = true;

        public float sensitivity = 10.0f;

        #endregion

        #region Private Fields

        private float scaleFactor;

        #endregion

        #region Events

        public void OnManipulationStarted(ManipulationEventData eventData) { }

        public void OnManipulationUpdated(ManipulationEventData eventData)
        {
            if (IsEnabled)
            {
                scaleFactor = eventData.CumulativeDelta.x * sensitivity;

                transform.localScale = new Vector3(transform.localScale.x + scaleFactor,
                    transform.localScale.y + scaleFactor, transform.localScale.z + scaleFactor);
            }
        }

        public void OnManipulationCompleted(ManipulationEventData eventData) { }

        public void OnManipulationCanceled(ManipulationEventData eventData) { }

        #endregion
    }
}
