using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IconButton : MonoBehaviour
{
    public StatefulIconScriptableObject icon;
    public string label;
    public Image image;
    public TextMeshProUGUI labelTxt;


    public bool active = false;
    public bool debug_update = false;


    public float animation_secs = 0.5f;
    private void OnValidate()
    {
        if (debug_update)
        {
            debug_update = false;
        }
        UpdateIcon();
    }

    Coroutine transitionAnimationCoroutine = null;

    IEnumerator TransitionAnimation_Coroutine()
    {
        float t = 0;
        float max_scale = 1.1f;
        float c = max_scale - 1f;


        
        while (t < 1)
        {
            t += Time.deltaTime / animation_secs;
            float y_q = 2 * t - 1;
            float y =  -(y_q * y_q) + 1f;
            float scale = 1 + c * y;

            image.transform.localScale = Vector3.one * scale;
            yield return 0;
        }
        image.transform.localScale = Vector3.one;
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
            if (transitionAnimationCoroutine != null)
            {
                StopCoroutine(transitionAnimationCoroutine);
            }
            StartCoroutine(TransitionAnimation_Coroutine());
        }

    }
}