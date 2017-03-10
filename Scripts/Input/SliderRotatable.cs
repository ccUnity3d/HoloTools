using UnityEngine;

public class SliderRotatable : MonoBehaviour
{
    public GameObject Slider;

    private MenuSliderHandler menuSliderHandler;

    private Quaternion defaultRotation;

    private void Awake()
    {
        if (Slider)
        {
            menuSliderHandler = Slider.GetComponent<MenuSliderHandler>();

            menuSliderHandler.valueUpdated += OnValueUpdate;
        }

        defaultRotation = transform.rotation;
    }

    private void OnValueUpdate()
    {
        if (Slider && menuSliderHandler)
        {
            transform.Rotate(new Vector3(0, 3.6f * menuSliderHandler.Direction, 0));

            if (menuSliderHandler.Value == 0)
            {
                transform.rotation = defaultRotation;
            }
        }
    }
}
