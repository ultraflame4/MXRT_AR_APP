using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickBounce : MonoBehaviour, IPointerClickHandler
{

    public bool disableClick = false;
    Coroutine transitionAnimationCoroutine = null;
    public float animation_secs = 0.2f;

    protected Transform targetTransform;

    protected virtual void Start() {
        targetTransform = transform;
    }
    IEnumerator TransitionAnimation_Coroutine()
    {
        float t = 0;
        float max_scale = 1.1f;
        float c = max_scale - 1f;



        while (t < 1)
        {
            t += Time.deltaTime / animation_secs;
            float y_q = 2 * t - 1;
            float y = -(y_q * y_q) + 1f;
            float scale = 1 + c * y;

            transform.localScale = Vector3.one * scale;
            yield return 0;
        }
        transform.localScale = Vector3.one;
    }

    public void StartBounceAnimation(bool cancelPrev = true)
    {
        if (transitionAnimationCoroutine != null)
        {
            StopCoroutine(transitionAnimationCoroutine);
        }
        StartCoroutine(TransitionAnimation_Coroutine());
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (disableClick) return;
        StartBounceAnimation();
    }
}