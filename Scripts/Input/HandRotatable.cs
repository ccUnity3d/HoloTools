using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class HandRotatable : MonoBehaviour, INavigationHandler
{
    public bool IsEnabled = true;

    public float rotationSensitivity = 10.0f;

    public Transform popupMenu;

    private Transform popupMenuParent;

    private Vector3 manipulationPreviousPostion;
    private float rotationFactor;

    public void OnNavigationStarted(NavigationEventData eventData)
    {
        hideMenu();
    }

    public void OnNavigationUpdated(NavigationEventData eventData)
    {
        if (IsEnabled)
        { 
            rotationFactor = eventData.CumulativeDelta.x * rotationSensitivity;
            transform.Rotate(new Vector3(0, -1 * rotationFactor, 0));
        }
    }

    public void OnNavigationCompleted(NavigationEventData eventData)
    {
        showMenu();
    }

    public void OnNavigationCanceled(NavigationEventData eventData)
    {
        showMenu();
    }

    private void hideMenu()
    {
        // Вкладываем меню в объект и скрываем его
        if (IsEnabled && popupMenu)
        {
            popupMenuParent = popupMenu.parent;
            popupMenu.parent = transform;
            popupMenu.gameObject.SetActive(false);
        }
    }

    private void showMenu()
    {
        // достаем меню из объекта и показываем его
        if (IsEnabled && popupMenu)
        {
            popupMenu.parent = popupMenuParent;
            popupMenu.gameObject.SetActive(true);
        }
    }
}
