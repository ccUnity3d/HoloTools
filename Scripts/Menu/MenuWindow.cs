// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloTools.Unity.Other;

namespace HoloTools.Unity.Menu
{
    public class MenuWindow : MonoBehaviour
    {
        #region Public Fields

        public string Name;

        public MenuWindow ParentWindow;

        public MenuWindow[] Childs;

        #endregion

        #region Private Fields

        private Sprite _icon;

        private string _title;

        private HideSelf _container;

        private Transform _floatingButton;

        private AudioSource _audioSrc;

        #endregion

        #region Public Properties

        #endregion

        #region Private Properties

        private bool Active
        {
            get
            {
                return Container.Active;
            }
            set
            {
                Container.Active = value;
            }
        }

        private Transform FloatingButton
        {
            get
            {
                if (!_floatingButton)
                {
                    _floatingButton = transform.FindChild("FloatingButton");
                }

                return _floatingButton;
            }
        }

        private HideSelf Container
        {
            get
            {
                if (!_container)
                {
                    _container = (HideSelf)GetComponentInChildren(typeof(HideSelf), true);
                }

                return _container;
            }
        }

        private AudioSource AudioSrc
        {
            get
            {
                if (!_audioSrc)
                {
                    _audioSrc = GetComponent<AudioSource>();
                }

                return _audioSrc;
            }
        }

        #endregion

        #region Utility Methods

        public void Open()
        {
            Active = true;

            if (!ParentWindow)
            {
                FloatingButton.gameObject.SetActive(false);
            }
            else
            {
                transform.position = ParentWindow.transform.position;

                ParentWindow.Close();
                ParentWindow.FloatingButton.gameObject.SetActive(false);
            }
        }

        public void Close()
        {
            Active = false;

            if (!ParentWindow)
            {
                FloatingButton.gameObject.SetActive(true);
            }
            else
            {
                ParentWindow.transform.position = transform.position;

                ParentWindow.Open();
            }
        }

        public void ClickSound()
        {
            if (AudioSrc)
            {
                AudioSrc.Play();
            }
        }

        public MenuWindow GetChild(string name)
        {
            foreach (var child in Childs)
            {
                if (child.Name == name)
                {
                    return child;
                }
            }

            return null;
        }

        #endregion
    }
}
