// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloTools.Unity.Menu;

namespace HoloTools.Unity.Other
{
    public class ChangeColor : MonoBehaviour
    {
        #region Public Fields

        [Tooltip("TextInput required")]
        public TextInput TextInput;

        public Color[] Colors;

        #endregion

        #region Private Fields

        private MeshRenderer _meshRend;

        #endregion

        #region Private Properties

        private MeshRenderer MeshRend
        {
            get
            {
                if (!_meshRend)
                {
                    _meshRend = GetComponent<MeshRenderer>();
                }

                return _meshRend;
            }
        }

        #endregion

        #region Main Methods

        private void Awake()
        {
            if (TextInput)
            {
                TextInput.OnValueChanged += OnValueChanged;
            }
        }

        #endregion

        #region Utility Methods

        private void OnValueChanged()
        {
            if (TextInput.Index >= 0 
                && TextInput.Index < Colors.Length)
            {
                var tempMat = MeshRend.material;
                tempMat.color = Colors[TextInput.Index];
                MeshRend.material = tempMat;
            }
        }

        #endregion
    }
}
