// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloTools.Unity.Menu;
using HoloToolkit.Unity.InputModule;

namespace HoloTools.Unity.Other
{
    public class ShowToast : MonoBehaviour,
                             IInputClickHandler
    {
        #region Public Fields

        public Toast toast;

        [Tooltip("Leave field empty if you don't want use this feature")]
        public string toastText = "";

        #endregion

        #region Events

        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (!toast)
            {
                return;
            }

            if (!toast.Active)
            {
                if (toastText.Length > 0)
                {
                    toast.SetText(toastText);
                }

                toast.Show(Toast.ToastDuration.Short);
            }
        }

        #endregion
    }
}
