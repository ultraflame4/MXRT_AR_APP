using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TestRaycaster : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RaycastManager;
    public GameObject hitIndicator;
    public float range = 10f;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    void Update()
    {
        var origin = Camera.main.transform.position;
        var direction = Camera.main.transform.forward * range;
        var ray = new Ray(origin, direction);
        hitIndicator.SetActive(false);
        if (m_RaycastManager.Raycast(ray, hits, TrackableType.Planes))
        {
            var hitPos = hits[0].pose.position;
            hitIndicator.transform.position = hitPos;
            Debug.DrawRay(origin, hitPos, Color.green);
            hitIndicator.SetActive(true);
        }
    }
}