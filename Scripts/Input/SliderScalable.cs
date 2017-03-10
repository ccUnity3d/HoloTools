using UnityEngine;

public class SliderScalable : MonoBehaviour
{
    public float scaleIncrement = 0.001f;

    public GameObject Slider;

    public Transform Popup;

    private MenuSliderHandler menuSliderHandler;

    private Vector3 defaultScale;

    private void Awake()
    {
        if (Slider)
        {
            menuSliderHandler = Slider.GetComponent<MenuSliderHandler>();

            menuSliderHandler.valueUpdated += OnValueUpdate;
        }

        defaultScale = transform.localScale;
    }

    private void OnValueUpdate()
    {
        if (Slider && menuSliderHandler)
        {
            transform.localScale = new Vector3(
                transform.localScale.x + scaleIncrement * menuSliderHandler.Direction,
                transform.localScale.y + scaleIncrement * menuSliderHandler.Direction,
                transform.localScale.z + scaleIncrement * menuSliderHandler.Direction
                );

            if (menuSliderHandler.Value == 0)
            {
                transform.localScale = defaultScale;
            }

            // Отодвигаем меню при масштабировании
            if (Popup)
            {
                Vector3 newPos = Popup.position;
                newPos.z = newPos.z + ((scaleIncrement * -menuSliderHandler.Direction));

                Popup.position = newPos;
            }
        }
    }
}
