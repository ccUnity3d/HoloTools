// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloTools.Unity.Other
{
    public class OpenSite : MonoBehaviour, IInputClickHandler
    {
        public string site = "http://holo.group";

        public void OnInputClicked(InputClickedEventData eventData)
        {
#if WINDOWS_UWP
            Windows.System.Launcher.LaunchUriAsync(new System.Uri(site));
#endif
        }
    }
}
