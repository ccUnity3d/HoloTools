using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class ScaleOnHover : MonoBehaviour, IFocusable
{
    public Mode scale = Mode.Bigger;

    private Vector3 localScale;

    public enum Mode { Bigger, Smaller };

    public void OnFocusEnter()
    {
        localScale = transform.localScale;

        float mod = (scale == Mode.Bigger ? 1.25f : 0.75f);

        transform.localScale = new Vector3(
            (transform.localScale.x * mod),
            (transform.localScale.y * mod),
            (transform.localScale.z * mod)
        );
    }

    public void OnFocusExit()
    {
        transform.localScale = localScale;
    }
}
