using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MenuSliderHandler : MonoBehaviour, IInputHandler, IFocusable
{
    public bool IsEnabled = true;

    public float Value = 0;
    public int Direction = 1;

    public Transform Toddler;
    public Transform Line;
    public Transform Cursor;

    private Vector3 defaultPos;

    private float minPos = 0;
    private float maxPos = 0;
    private float oldVal = 0;

    private bool IsPressed = false;
    private bool cursorInclude = false;

    public Action valueUpdated;

    void Awake()
    {
        minPos = Toddler.localPosition.x;
        maxPos = -minPos;
    }

    public void OnInputDown(InputEventData eventData)
    {
        IsPressed = true;

        defaultPos = Toddler.localPosition;
    }

    public void OnInputUp(InputEventData eventData)
    {
        IsPressed = false;
    }

    private void Update()
    {
        if (Cursor && Toddler && IsPressed && IsEnabled)
        {
            if (!cursorInclude)
            {
                Cursor.parent = Line;
                cursorInclude = true;
            }

            Vector3 newPos = Cursor.localPosition;

            newPos.y = defaultPos.y;
            newPos.z = 0;

            if (newPos.x >= minPos && newPos.x <= maxPos)
            {
                Toddler.localPosition = newPos;

                float curPos = newPos.x + Mathf.Abs(minPos);
                float len = maxPos + Mathf.Abs(minPos);

                float ValTemp = (float)Math.Round(curPos / len, 2) * 100;

                if (ValTemp != oldVal)
                {
                    Value = ValTemp;
                    Direction = Value > oldVal ? 1 : -1;
                    oldVal = Value;

                    if (valueUpdated != null)
                    {
                        valueUpdated();
                    }
                }
            }
        }

        if (cursorInclude)
        {
            Cursor.parent = null;
            cursorInclude = false;
        }
    }

    public void OnFocusEnter() {}

    public void OnFocusExit()
    {
        IsPressed = false;
    }
}
