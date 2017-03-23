// Copyright (c) HoloGroup (http://holo.group). All rights reserved.


using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class ImageButtonState : MonoBehaviour,
                                IInputClickHandler
{
    #region Public Fields

    public bool Active = false;

    public Color OnActive;

    #endregion

    #region Private Fields

    private Image _image;
    private Color _normalColor;
    private ImageButtonState[] _buttonStates;

    #endregion

    #region Private Properties

    private Image Image
    {
        get
        {
            if (!_image)
            {
                _image = GetComponent<Image>();
            }

            return _image;
        }
    }

    public ImageButtonState[] ButtonStates
    {
        get
        {
            if (_buttonStates == null || _buttonStates.Length == 0)
            {
                _buttonStates = FindObjectsOfType<ImageButtonState>();
            }

            return _buttonStates;
        }
    }

    #endregion

    #region Main Methods

    private void Awake()
    {
        _normalColor = Image.color;
    }

    #endregion

    #region Events

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Active = !Active;

        SetActive(Active);
    }

    #endregion

    #region Utility Methods

    public void SetActive(bool active)
    {
        // before continue return all Buttons state to normal
        DisableSelection();

        if (Image)
        {
            Image.color = active ? OnActive : _normalColor;

            Active = active;
        }
    }

    private void DisableSelection()
    {
        foreach (var state in ButtonStates)
        {
            if (state.Image)
            {
                state.Image.color = _normalColor;
                state.Active = false;
            }
        }
    }

    #endregion
}
