using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MenuBtnState : MonoBehaviour, IInputClickHandler, IFocusable
{
    public bool IsActive = false;
    public bool IsFocus = false;

    public Material NormalState;
    public Material HoverState;
    public Material ActiveState;

    public GameObject Popup;

    [HideInInspector]
    public MeshRenderer meshRend;

    private MenuBtnState[] buttonStates;

    private void Awake()
    {
        meshRend = GetComponent<MeshRenderer>();

        if (Popup)
        {
            buttonStates = Popup.GetComponentsInChildren<MenuBtnState>();
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        IsActive = !IsActive;

        SetActive(IsActive);
    }

    public void SetActive(bool active)
    {
        // Снимаем фокус со всех кнопок
        if (Popup)
        {
            foreach (MenuBtnState state in buttonStates)
            {
                if (state.meshRend)
                {
                    state.meshRend.sharedMaterial = state.NormalState;
                }
            }
        }

        if (meshRend && ActiveState && NormalState)
        {
            meshRend.sharedMaterial = active ? ActiveState : NormalState;
        }
    }

    public void SetFocus(bool active)
    {
        if (!IsActive && meshRend && HoverState && NormalState)
        {
            meshRend.sharedMaterial = active ? HoverState : NormalState;
        }
    }

    public void OnFocusEnter()
    {
        IsFocus = true;
        SetFocus(IsFocus);
    }

    public void OnFocusExit()
    {
        IsFocus = false;
        SetFocus(IsFocus);
    }
}
