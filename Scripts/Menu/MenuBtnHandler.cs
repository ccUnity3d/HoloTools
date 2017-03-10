using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MenuBtnHandler : MonoBehaviour, IInputClickHandler
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

    public void OnInputClicked(InputClickedEventData eventData)
    {
        switch (action)
        {
            case MenuActions.Actions.None:
                break;

            case MenuActions.Actions.Move:
                SendMessageUpwards("Move");
                break;
        }

        if (audioSrc)
        {
            audioSrc.Play();
        }
    }
}
