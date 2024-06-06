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
    [field: SerializeField]
    public bool active {get; private set;}= false;
    public bool debug_update = false;
    public bool disabled = false;

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
        if (disabled)
        {
            state = icon.disabled_state;
        }

        image.sprite = state.sprite;
        image.color = state.tint;
        if (labelTxt != null)
        {
            labelTxt.text = label;
            labelTxt.color = state.tint;
        }

        if (Application.isPlaying && !disabled)
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
    public void SetDisabled(bool disabled = true, bool force = false)
    {
        if (this.disabled == disabled && !force) return;
        this.disabled = disabled;
        UpdateIcon();
    }



    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!override_click_behavior) SetActive(!active);
        
        Clicked?.Invoke(this);
    }
}