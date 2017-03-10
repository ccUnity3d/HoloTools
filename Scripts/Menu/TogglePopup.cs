using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class TogglePopup : MonoBehaviour, IInputHandler
{
    public GameObject Popup; // Ссылка на меню

    private bool IsVisible = false;

    private AudioSource audioSrc; // Звук клика

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();

        if (Popup)
        {
            Popup.SetActive(false);
        }
    }

    public void OnInputDown(InputEventData eventData)
    {
        Toggle();

        if (audioSrc)
        {
            audioSrc.Play();
        }
    }

    public void OnInputUp(InputEventData eventData) {}

    public void Toggle()
    {
        if (Popup && !IsVisible)
        {
            Popup.SetActive(true);
            IsVisible = true;
        }
        else if (Popup && IsVisible)
        {
            Popup.SetActive(false);
            IsVisible = false;
        }
    }
}
