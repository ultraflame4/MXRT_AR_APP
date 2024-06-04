using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IconButton : ClickBounce, IPointerClickHandler
{
    public StatefulIconScriptableObject icon;
    public string label;
    public Image image;
    public TextMeshProUGUI labelTxt;

    public Action<IconButton> Clicked;
    [SerializeField]
    private bool active = false;
    public bool debug_update = false;

    /// <summary>
    /// If true, the button will not change its state or play an animation when clicked.
    /// </summary>
    public bool override_click_behavior = false;

    protected override void Start()
    {
        targetTransform = image.transform;
        disableClick = true;
    }

    private void OnValidate()
    {
        if (debug_update)
        {
            debug_update = false;
        }
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (icon == null) return;
        var state = active ? icon.active_state : icon.normal_state;

        image.sprite = state.sprite;
        image.color = state.tint;
        labelTxt.text = label;
        labelTxt.color = state.tint;

        if (Application.isPlaying)
        {
            StartBounceAnimation();
        }
    }

    public void SetActive(bool active, bool force = false)
    {
        if (this.active == active && !force) return;
        this.active = active;
        UpdateIcon();
    }


    public override void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke(this);
        if (override_click_behavior) return;
        SetActive(!active);
    }
}