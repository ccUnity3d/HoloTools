// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloTools.Unity.Input
{
    /// <summary>
    /// Simple Input component - using cursor coordinates to move object
    /// If you want more flexibility use HandDraggable instead
    /// </summary>
    public class GazeDraggable : MonoBehaviour, 
                                 IInputHandler
    {
        #region Public Fields

        public bool IsEnabled = true;

        [Tooltip("Transform of Cursor gameobject")]
        public Transform Cursor;

        [Tooltip("Transform of popup menu. Optional.")]
        public Transform popupMenu;

        #endregion

        #region Private Fields

        private Transform popupParent;

        private bool IsPressed;

        private Vector3 defaultPos;

        #endregion

        #region Main Methods

        private void Update()
        {
            if (Cursor && IsEnabled && IsPressed)
            {
                Vector3 newPos = Cursor.position;
                newPos.z = defaultPos.z;

                transform.position = newPos;
            }
        }

        #endregion

        #region Events

        public void OnInputDown(InputEventData eventData)
        {
            IsPressed = true;

            defaultPos = transform.position;

            if (IsEnabled && popupMenu)
            {
                popupParent = popupMenu.parent;
                popupMenu.parent = transform;
                popupMenu.gameObject.SetActive(false);
            }

            if (IsEnabled)
            {
                Debug.Log("Draging Start");
            }
        }

        public void OnInputUp(InputEventData eventData)
        {
            IsPressed = false;

            if (IsEnabled && popupMenu)
            {
                popupMenu.parent = popupParent;
                popupMenu.gameObject.SetActive(true);
            }

            if (IsEnabled)
            {
                Debug.Log("Draging End");
            }
        }

        #endregion
    }
}
