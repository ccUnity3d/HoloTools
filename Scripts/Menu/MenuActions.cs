using UnityEngine;

public class MenuActions : MonoBehaviour
{
    public Transform Target; // Ссылка на объект

    public enum Actions { None, Move } // Список действий

    private GazeDraggable gazeDraggable;

    private void Awake()
    {
        if (Target)
        {
            gazeDraggable = Target.GetComponent<GazeDraggable>();
        }
    }

    #region Вызываемые методы

    public void Move()
    {
        if (gazeDraggable)
        {
            gazeDraggable.IsEnabled = !gazeDraggable.IsEnabled;
        }
    }

    #endregion
}
