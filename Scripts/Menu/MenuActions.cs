using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActions : MonoBehaviour
{
    public Transform Target; // Ссылка на объект

    public enum Actions { None, Move, Rotate } // Список действий

    private GazeDraggable gazeDraggable;
    private HandRotatable handRotatable;

    private void Awake()
    {
        if (Target)
        {
            gazeDraggable = Target.GetComponent<GazeDraggable>();
            handRotatable = Target.GetComponent<HandRotatable>();
        }
    }

    #region Вызываемые методы

    public void Move()
    {
        if (handRotatable)
        {
            handRotatable.IsEnabled = false;
        }

        if (gazeDraggable)
        {
            gazeDraggable.IsEnabled = !gazeDraggable.IsEnabled;
        }
    }

    public void Rotate()
    {
        if (gazeDraggable)
        {
            gazeDraggable.IsEnabled = false;
        }

        if (handRotatable)
        {
            handRotatable.IsEnabled = !handRotatable.IsEnabled;
        }
    }

    #endregion
}
