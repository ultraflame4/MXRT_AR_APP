using System;
using System.Collections;
using UnityEngine;

public class InterestPointManager : MonoBehaviour
{
    public InterestPoint[] interestPoints;
    public bool autoFindInterestPoints = true;

    
    public AudioSource audioSource;
    public float selectorRadius = 2f;
    [Tooltip("How long the player must focus on an interest point before it is selected")]
    public float focus_time_secs = 1f;
    public InterestPointSelector interestPointSelectorUI;
    public GameObject interestPointOptionPrefab;
    public Transform interestPointOptionsCtn;
    public bool debug_drawSelectorBeam = false;
    /// <summary>
    /// Counter for how long the player has been focusing on the current interest point
    /// </summary>
    private float focus_time_counter = 1f;
    /// <summary>
    /// The percentage of time the player has been focusing on the current interest point
    /// </summary>
    public float focus_time_percent => focus_time_counter / focus_time_secs;
    /// <summary>
    /// The interest point the player is currently focusing on
    /// </summary>
    private InterestPoint focus_candidate = null;
    private InterestPoint current_focus = null;

    private void Start()
    {
        if (autoFindInterestPoints)
        {
            interestPoints = FindObjectsOfType<InterestPoint>();
        }
    }

    public void ClearFocus()
    {
        current_focus = null;
        focus_candidate = null;
    }
    private InterestPointOption CreateOption(InterestPointOption.OptionType type, string text)
    {
        var option = Instantiate(interestPointOptionPrefab, interestPointOptionsCtn).GetComponent<InterestPointOption>();
        option.optionType = type;
        option.SetText(text);
        return option;
    }

    public void PopulateInterestPointOptions(InterestPoint interestPoint)
    {

        for (int i = 0; i < interestPointOptionsCtn.childCount; i++)
        {
            Destroy(interestPointOptionsCtn.GetChild(i).gameObject);
        }
        var interesttype = interestPoint.establishment.type;

        if (interesttype == InterestPointData.InterestPointType.CONTROL)
        {
            foreach (var x in interestPoint.establishment.controlOptions)
            {
                var option = CreateOption(InterestPointOption.OptionType.None, x);
            }
            foreach (var q in interestPoint.establishment.control_queries_type)
            {
                var option = CreateOption(InterestPointOption.OptionType.Query, q);
                option.establishmentData = interestPoint.establishment;
                option.query_type = q;
            }
        }

        if (!String.IsNullOrEmpty(interestPoint.establishment.website))
        {
            var option = CreateOption(InterestPointOption.OptionType.Link, "Visit Website");
            option.link_url = interestPoint.establishment.website;
        }

        if (interesttype == InterestPointData.InterestPointType.FOOD)
        {
            var option = CreateOption(InterestPointOption.OptionType.Details, "Details");
            option.establishmentData = interestPoint.establishment;
        }

    }

    public void FocusInterestPoint(InterestPoint interestPoint)
    {
        current_focus = interestPoint;
        focus_candidate = null;
        audioSource.Play();
        Handheld.Vibrate();
        PopulateInterestPointOptions(current_focus);
    }


    private InterestPoint FindInterestPointNearCameraCentre()
    {
        var camera = Camera.main;
        var centre = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, camera.nearClipPlane));

        RaycastHit hit;
        if (Physics.SphereCast(centre, selectorRadius, camera.transform.forward, out hit, camera.farClipPlane))
        {
            var point = hit.collider.GetComponent<InterestPoint>();
            return point;
        }
        return null;
    }

    private void FixedUpdate()
    {
        var point = FindInterestPointNearCameraCentre();
        if (point == null)
        {
            focus_candidate = null;
            focus_time_counter = 0f;
            return;
        }

        if (current_focus == point) return;

        if (focus_candidate == point)
        {
            focus_time_counter += Time.fixedDeltaTime;
            if (focus_time_counter >= focus_time_secs)
            {
                FocusInterestPoint(point);
            }
        }
        else
        {
            focus_candidate = point;
            focus_time_counter = 0f;
        }
    }

    private void Update()
    {

        if (focus_candidate != null)
        {
            interestPointOptionsCtn.gameObject.SetActive(false);
            interestPointSelectorUI.gameObject.SetActive(true);
            interestPointSelectorUI.UpdateData(focus_candidate.transform.position, focus_time_percent);
            return;
        }
        else if (current_focus != null)
        {
            interestPointOptionsCtn.gameObject.SetActive(true);
            interestPointSelectorUI.gameObject.SetActive(true);
            interestPointSelectorUI.UpdateData(current_focus.transform.position, 1);
            return;
        }
        else
        {
            interestPointSelectorUI.gameObject.SetActive(false);
            interestPointOptionsCtn.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        if (!debug_drawSelectorBeam) return;
        Gizmos.color = Color.green;
        var start = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane));
        var end = start + Camera.main.transform.forward * Camera.main.farClipPlane;


        for (int i = 0; i < 100; i++)
        {
            float t = i / 100f;
            var point = Vector3.Lerp(start, end, t);
            Gizmos.DrawWireSphere(point, selectorRadius);
        }
    }
}