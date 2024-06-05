using UnityEngine;

public class FaceCamera : MonoBehaviour
{

    public bool debug_update = false;
    private void Update()
    {
        UpdateRotation();
    }

    void UpdateRotation()
    {
        Vector3 to_camera = (transform.position - Camera.main.transform.position).normalized;
        transform.LookAt(transform.position + to_camera);
    }

    private void OnValidate() {
        if (debug_update) {
            debug_update = false;
            UpdateRotation();
        }
    }
}