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

        [Tooltip("Transform of popup menu. Optional.")]
        public Transform popupMenu;

        #endregion

        #region Private Fields

        private Transform popupParent;

        private Vector3 manipulationPreviousPostion;

        private float rotationFactor;

        #endregion

        #region Events

        public void OnNavigationStarted(NavigationEventData eventData)
        {
            hideMenu();
        }

        public void OnNavigationUpdated(NavigationEventData eventData)
        {
            if (IsEnabled)
            {
                rotationFactor = eventData.CumulativeDelta.x * rotationSensitivity;
                transform.Rotate(new Vector3(0, -1 * rotationFactor, 0));
            }
        }

        public void OnNavigationCompleted(NavigationEventData eventData)
        {
            showMenu();
        }

        public void OnNavigationCanceled(NavigationEventData eventData)
        {
            showMenu();
        }

        #endregion

        #region Utility Methods

        private void hideMenu()
        {
            if (IsEnabled && popupMenu)
            {
                popupParent = popupMenu.parent;
                popupMenu.parent = transform;
                popupMenu.gameObject.SetActive(false);
            }
        }

        private void showMenu()
        {
            if (IsEnabled && popupMenu)
            {
                popupMenu.parent = popupParent;
                popupMenu.gameObject.SetActive(true);
            }
        }

        #endregion
    }
}
