// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;

namespace HoloTools.Unity.Other
{
    /// <summary>
    /// Billboard component - position gameobject towards to camera
    /// </summary>
    public class Billboard : MonoBehaviour
    {
        private void OnEnable()
        {
            Update();
        }

        private void Update()
        {
            if (!Camera.main)
            {
                return;
            }

            Vector3 directionToTarget = Camera.main.transform.position - transform.position;

            if (directionToTarget.sqrMagnitude < 0.001f)
            {
                return;
            }

            transform.rotation = Quaternion.LookRotation(-directionToTarget);
        }
    }
}
