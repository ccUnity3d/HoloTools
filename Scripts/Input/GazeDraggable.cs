using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class GazeDraggable : MonoBehaviour, IInputHandler
{
    public bool IsEnabled = true;

    public Transform Cursor;
    public Transform popupMenu;

    private Transform popupMenuParent;

    private bool IsPressed;

    private Vector3 defaultPos;

    public void OnInputDown(InputEventData eventData)
    {
        IsPressed = true;

        defaultPos = transform.position;

        // Вкладываем меню в объект и скрываем его
        if (IsEnabled && popupMenu)
        {
            popupMenuParent = popupMenu.parent;
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

        // достаем меню из объекта и показываем его
        if (IsEnabled && popupMenu)
        {
            popupMenu.parent = popupMenuParent;
            popupMenu.gameObject.SetActive(true);
        }

        if (IsEnabled)
        {
            Debug.Log("Draging End");
        }
    }

    private void Update()
    {
        if (Cursor && IsEnabled && IsPressed)
        {
            Vector3 newPos = Cursor.position;
            newPos.z = defaultPos.z;

            transform.position = newPos;
        }
    }
}
