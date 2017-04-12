// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class ButtonObjectScaler : MonoBehaviour
    {
        [SerializeField]
        private TestButton button = null;

        [SerializeField]
        private GameObject ObjectToScale = null;

        [SerializeField]
        private float ScaleIncrement = 1.0f;

        [SerializeField]
        private buttonAction ButtonAction = buttonAction.Reset;

        private enum buttonAction { Move, Rotate, Bigger, Smaller, Reset };

        private Vector3 InitialScale;

        private HandDraggable handDraggable;

        private HandRotatable handRotatable;

        private void Start()
        {
            if (ObjectToScale)
            {
                InitialScale = ObjectToScale.transform.localScale;
                handDraggable = ObjectToScale.GetComponent<HandDraggable>();
                handRotatable = ObjectToScale.GetComponent<HandRotatable>();
            }
        }

        private void OnEnable()
        {
            button.Activated += OnButtonPressed;
        }

        private void OnDisable()
        {
            button.Activated -= OnButtonPressed;
        }

        private void OnButtonPressed(TestButton source)
        {
            if (ObjectToScale)
            {
                switch (ButtonAction)
                {
                    case buttonAction.Move:
                        if (handRotatable)
                        {
                            handRotatable.IsRotationEnabled = false;
                        }
                        if (handDraggable)
                        {
                            handDraggable.IsDraggingEnabled = !handDraggable.IsDraggingEnabled;
                        }
                        break;

                    case buttonAction.Rotate:
                        if (handDraggable)
                        {
                            handDraggable.IsDraggingEnabled = false;
                        }
                        if (handRotatable)
                        {
                            handRotatable.IsRotationEnabled = !handRotatable.IsRotationEnabled;
                        }
                        break;

                    case buttonAction.Bigger:
                        ObjectToScale.transform.localScale = new Vector3((ObjectToScale.transform.localScale.x + ScaleIncrement), (ObjectToScale.transform.localScale.y + ScaleIncrement), (ObjectToScale.transform.localScale.z + ScaleIncrement));
                        break;

                    case buttonAction.Smaller:
                        if ((ObjectToScale.transform.localScale.x - ScaleIncrement) < 0.0f)
                        {
                            ObjectToScale.transform.localScale = new Vector3(0, 0, 0);
                        }
                        else
                        {
                            ObjectToScale.transform.localScale = new Vector3((ObjectToScale.transform.localScale.x - ScaleIncrement), (ObjectToScale.transform.localScale.y - ScaleIncrement), (ObjectToScale.transform.localScale.z - ScaleIncrement));
                        }
                        break;

                    case buttonAction.Reset:
                        Debug.Log(InitialScale);
                        ObjectToScale.transform.localScale = InitialScale;
                        break;
                }
            }

            button.Selected = false;
        }
    }
}