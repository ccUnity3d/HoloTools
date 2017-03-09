using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MenuBtnHandler : MonoBehaviour, IInputHandler
{
    public MenuActions menuActions;

    public MenuActions.Actions action = MenuActions.Actions.None;

    private AudioSource audioSrc;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();

        if (!menuActions)
        {
            menuActions = transform.parent.gameObject.GetComponent<MenuActions>();
        }
    }

    public void OnInputDown(InputEventData eventData)
    {
        switch (action)
        {
            case MenuActions.Actions.None:
                break;

            case MenuActions.Actions.Move:
                SendMessageUpwards("Move");
                break;

            case MenuActions.Actions.Rotate:
                SendMessageUpwards("Rotate");
                break;
        }

        if (audioSrc)
        {
            audioSrc.Play();
        }
    }

    public void OnInputUp(InputEventData eventData) {}
}
