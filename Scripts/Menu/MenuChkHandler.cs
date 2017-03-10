using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MenuChkHandler : MonoBehaviour, IInputClickHandler
{
    public bool Checked = true;

    public GameObject Dot;

    private AudioSource audioSrc;

    private void Awake()
    {
        if (Dot)
        {
            Dot.SetActive(Checked);
        }

        audioSrc = GetComponent<AudioSource>();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Checked = !Checked;

        if (Dot)
        {
            Dot.SetActive(Checked);
        }

        if (audioSrc)
        {
            audioSrc.Play();
        }
    }
}
